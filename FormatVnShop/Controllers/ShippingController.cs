using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormatVnShop.Data;
using FormatVnShop.Models;
using FormatVnShop.Services;

namespace FormatVnShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShippingController : ControllerBase
{
    private readonly IGhtkService _ghtkService;
    private readonly ApplicationDbContext _context;

    public ShippingController(IGhtkService ghtkService, ApplicationDbContext context)
    {
        _ghtkService = ghtkService;
        _context = context;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> CalculateShippingFee([FromBody] ShippingRequest request)
    {
        try
        {
            // 1. Get Address details if AddressId is provided, otherwise use raw details
            string province, district, ward, address;

            if (request.AddressId.HasValue)
            {
                var addr = await _context.Addresses.FindAsync(request.AddressId.Value);
                if (addr == null) return NotFound("Address not found");
                province = addr.City;
                district = addr.District;
                ward = addr.Ward;
                address = addr.AddressLine;
            }
            else if (request.RawAddress != null)
            {
                province = request.RawAddress.City;
                district = request.RawAddress.District;
                ward = request.RawAddress.Ward;
                address = request.RawAddress.AddressLine;
            }
            else
            {
                return BadRequest("Address details are required");
            }

            // 2. Calculate Total Weight and Total Value
            int totalWeight = 0;
            decimal totalValue = 0;

            foreach (var item in request.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null)
                {
                    totalWeight += (product.Weight > 0 ? product.Weight : 200) * item.Quantity; // Default 200g if not set
                    totalValue += product.Price * item.Quantity;
                }
            }

            // 3. Call GHTK Service
            Console.WriteLine($"[Shipping] Calculating fee to {province}, {district}, {ward}. Weight: {totalWeight}g, Value: {totalValue}");
            var fee = await _ghtkService.CalculateFeeAsync(province, district, ward, address, totalWeight, totalValue);

            return Ok(new { success = true, fee });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shipping] ERROR: {ex.Message}");
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}

public class ShippingRequest
{
    public int? AddressId { get; set; }
    public AddressDto? RawAddress { get; set; }
    public List<ShippingItem> Items { get; set; } = new();
}

public class AddressDto
{
    public string City { get; set; } = "";
    public string District { get; set; } = "";
    public string Ward { get; set; } = "";
    public string AddressLine { get; set; } = "";
}

public class ShippingItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
