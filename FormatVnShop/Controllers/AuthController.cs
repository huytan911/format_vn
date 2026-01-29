using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FormatVnShop.Data;
using FormatVnShop.Models;
using FormatVnShop.Models.DTOs;
using BCrypt.Net;

namespace FormatVnShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginDto loginDto)
    {
        var user = await _context.AdminUsers
            .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.IsActive);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        // Update last login time
        user.LastLoginAt = DateTime.Now;
        await _context.SaveChangesAsync();

        var token = GenerateJwtToken(user);
        var expiresAt = DateTime.Now.AddHours(24);

        return Ok(new AuthResponse
        {
            Token = token,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role.ToString(),
            ExpiresAt = expiresAt
        });
    }

    // POST: api/auth/register (SuperAdmin only)
    [HttpPost("register")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<ActionResult<AuthResponse>> Register(RegisterDto registerDto)
    {
        // Check if user already exists
        if (await _context.AdminUsers.AnyAsync(u => u.Email == registerDto.Email || u.Username == registerDto.Username))
        {
            return BadRequest(new { message = "User with this email or username already exists" });
        }

        // Parse role
        if (!Enum.TryParse<AdminRole>(registerDto.Role, out var role))
        {
            return BadRequest(new { message = "Invalid role specified" });
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var newUser = new AdminUser
        {
            Username = registerDto.Username,
            Email = registerDto.Email,
            PasswordHash = hashedPassword,
            Role = role,
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        _context.AdminUsers.Add(newUser);
        await _context.SaveChangesAsync();

        var token = GenerateJwtToken(newUser);
        var expiresAt = DateTime.Now.AddHours(24);

        return Created($"/api/auth/user/{newUser.Id}", new AuthResponse
        {
            Token = token,
            Username = newUser.Username,
            Email = newUser.Email,
            Role = newUser.Role.ToString(),
            ExpiresAt = expiresAt
        });
    }

    // GET: api/auth/me
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<object>> GetCurrentUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (email == null)
        {
            return Unauthorized();
        }

        var user = await _context.AdminUsers.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            user.Id,
            user.Username,
            user.Email,
            Role = user.Role.ToString(),
            user.LastLoginAt
        });
    }

    private string GenerateJwtToken(AdminUser user)
    {
        var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
        var jwtIssuer = _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer not configured");
        var jwtAudience = _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience not configured");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
