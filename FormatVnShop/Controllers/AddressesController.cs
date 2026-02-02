using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FormatVnShop.Data;
using FormatVnShop.Models;

namespace FormatVnShop.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AddressesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AddressesController(ApplicationDbContext context)
    {
        _context = context;
    }

    private int GetCurrentUserId()
    {
        var idClaim = User.FindFirstValue("id"); // Assuming "id" claim contains customer ID from JWT
        if (int.TryParse(idClaim, out int id))
        {
            return id;
        }
        
        // Fallback or explicit check if you use email to find user
        var email = User.FindFirstValue(ClaimTypes.Email);
        var user = _context.Customers.FirstOrDefault(u => u.Email == email);
        return user?.Id ?? 0;
    }

    // GET: api/addresses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
    {
        var userId = GetCurrentUserId();
        if (userId == 0) return Unauthorized();

        return await _context.Addresses
            .Where(a => a.CustomerId == userId)
            .OrderByDescending(a => a.IsDefault)
            .ToListAsync();
    }

    // GET: api/addresses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Address>> GetAddress(int id)
    {
        var userId = GetCurrentUserId();
        if (userId == 0) return Unauthorized();

        var address = await _context.Addresses.FindAsync(id);

        if (address == null)
        {
            return NotFound();
        }

        if (address.CustomerId != userId)
        {
            return Forbid();
        }

        return address;
    }

    // POST: api/addresses
    [HttpPost]
    public async Task<ActionResult<Address>> PostAddress(Address address)
    {
        var userId = GetCurrentUserId();
        if (userId == 0) return Unauthorized();

        address.CustomerId = userId;

        // If this is the first address, make it default
        if (!await _context.Addresses.AnyAsync(a => a.CustomerId == userId))
        {
            address.IsDefault = true;
        }

        // If this one is set to default, unset others
        if (address.IsDefault)
        {
            var existingDefaults = await _context.Addresses
                .Where(a => a.CustomerId == userId && a.IsDefault)
                .ToListAsync();
            
            foreach (var addr in existingDefaults)
            {
                addr.IsDefault = false;
            }
        }

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAddress", new { id = address.Id }, address);
    }

    // PUT: api/addresses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAddress(int id, Address address)
    {
        if (id != address.Id)
        {
            return BadRequest();
        }

        var userId = GetCurrentUserId();
        if (userId == 0) return Unauthorized();

        var existingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if (existingAddress == null) return NotFound();
        if (existingAddress.CustomerId != userId) return Forbid();

        // Update properties
        existingAddress.ReceiverName = address.ReceiverName;
        existingAddress.PhoneNumber = address.PhoneNumber;
        existingAddress.AddressLine = address.AddressLine;
        existingAddress.City = address.City;
        existingAddress.District = address.District;
        existingAddress.Ward = address.Ward;
        existingAddress.Note = address.Note;

        // Handle default status change
        if (address.IsDefault && !existingAddress.IsDefault)
        {
             var existingDefaults = await _context.Addresses
                .Where(a => a.CustomerId == userId && a.IsDefault && a.Id != id)
                .ToListAsync();
            
            foreach (var addr in existingDefaults)
            {
                addr.IsDefault = false;
            }
            existingAddress.IsDefault = true;
        }
        else if (!address.IsDefault && existingAddress.IsDefault)
        {
            // Just unset it? Or force at least one default?
            // For now, let's allow unsetting, but usually you'd want one default.
            existingAddress.IsDefault = false;
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AddressExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/addresses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        var userId = GetCurrentUserId();
        if (userId == 0) return Unauthorized();

        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return NotFound();
        }

        if (address.CustomerId != userId)
        {
            return Forbid();
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AddressExists(int id)
    {
        return _context.Addresses.Any(e => e.Id == id);
    }
}
