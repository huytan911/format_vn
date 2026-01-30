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

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var token = GenerateJwtToken(claims);
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

    // POST: api/auth/customer/login
    [HttpPost("customer/login")]
    public async Task<ActionResult<CustomerAuthResponse>> CustomerLogin(LoginDto loginDto)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Email == loginDto.Email);

        if (customer == null || string.IsNullOrEmpty(customer.PasswordHash) || !BCrypt.Net.BCrypt.Verify(loginDto.Password, customer.PasswordHash))
        {
            return Unauthorized(new { message = "Email hoặc mật khẩu không đúng" });
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new Claim(ClaimTypes.Name, customer.Name),
            new Claim(ClaimTypes.Email, customer.Email),
            new Claim(ClaimTypes.Role, "Customer")
        };

        var token = GenerateJwtToken(claims);
        var expiresAt = DateTime.Now.AddHours(24);

        return Ok(new CustomerAuthResponse
        {
            Token = token,
            Name = customer.Name,
            Email = customer.Email,
            Role = "Customer",
            ExpiresAt = expiresAt
        });
    }

    // POST: api/auth/customer/register
    [HttpPost("customer/register")]
    public async Task<ActionResult<CustomerAuthResponse>> CustomerRegister(CustomerRegisterDto registerDto)
    {
        if (await _context.Customers.AnyAsync(c => c.Email == registerDto.Email))
        {
            return BadRequest(new { message = "Email đã được sử dụng" });
        }

        var customer = new Customer
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            Phone = registerDto.Phone,
            Address = registerDto.Address
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new Claim(ClaimTypes.Name, customer.Name),
            new Claim(ClaimTypes.Email, customer.Email),
            new Claim(ClaimTypes.Role, "Customer")
        };

        var token = GenerateJwtToken(claims);
        var expiresAt = DateTime.Now.AddHours(24);

        return Ok(new CustomerAuthResponse
        {
            Token = token,
            Name = customer.Name,
            Email = customer.Email,
            Role = "Customer",
            ExpiresAt = expiresAt
        });
    }

    // GET: api/auth/customer/profile
    [HttpGet("customer/profile")]
    [Authorize(Roles = "Customer")]
    public async Task<ActionResult<CustomerProfileDto>> GetCustomerProfile()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);

        if (customer == null) return NotFound();

        return Ok(new CustomerProfileDto
        {
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone,
            Address = customer.Address
        });
    }

    // PUT: api/auth/customer/profile
    [HttpPut("customer/profile")]
    [Authorize(Roles = "Customer")]
    public async Task<ActionResult> UpdateCustomerProfile(CustomerProfileDto profileDto)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);

        if (customer == null) return NotFound();

        customer.Name = profileDto.Name;
        customer.Phone = profileDto.Phone;
        customer.Address = profileDto.Address;

        await _context.SaveChangesAsync();
        return NoContent();
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

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
            new Claim(ClaimTypes.Name, newUser.Username),
            new Claim(ClaimTypes.Email, newUser.Email),
            new Claim(ClaimTypes.Role, newUser.Role.ToString())
        };

        var token = GenerateJwtToken(claims);
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

        // Check Admin
        var admin = await _context.AdminUsers.FirstOrDefaultAsync(u => u.Email == email);
        if (admin != null)
        {
            return Ok(new
            {
                admin.Id,
                admin.Username,
                admin.Email,
                Role = admin.Role.ToString(),
                admin.LastLoginAt
            });
        }

        // Check Customer
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        if (customer != null)
        {
            return Ok(new
            {
                customer.Id,
                Username = customer.Name,
                customer.Email,
                Role = "Customer"
            });
        }

        return NotFound();
    }

    private string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
        var jwtIssuer = _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer not configured");
        var jwtAudience = _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience not configured");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

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
