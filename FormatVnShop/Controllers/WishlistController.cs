using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FormatVnShop.Data;
using FormatVnShop.Models;
using FormatVnShop.Models.DTOs;

namespace FormatVnShop.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Customer")]
public class WishlistController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public WishlistController(ApplicationDbContext context)
    {
        _context = context;
    }

    private async Task<Customer?> GetCurrentCustomer()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    // GET: api/wishlist
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WishlistItemDto>>> GetWishlist()
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var wishlistItems = await _context.WishlistItems
            .Include(w => w.Product)
            .Where(w => w.CustomerId == customer.Id)
            .Select(w => new WishlistItemDto
            {
                Id = w.Id,
                ProductId = w.ProductId,
                ProductName = w.Product!.Name,
                Price = w.Product.Price,
                ImageUrl = w.Product.ImageUrl,
                IsInStock = w.Product.Stock > 0
            })
            .ToListAsync();

        return Ok(wishlistItems);
    }

    // POST: api/wishlist
    [HttpPost]
    public async Task<ActionResult<WishlistItemDto>> AddToWishlist(AddWishlistItemDto dto)
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var product = await _context.Products.FindAsync(dto.ProductId);
        if (product == null) return NotFound(new { message = "Sản phẩm không tồn tại" });

        var exists = await _context.WishlistItems
            .AnyAsync(w => w.CustomerId == customer.Id && w.ProductId == dto.ProductId);

        if (exists)
        {
            return BadRequest(new { message = "Sản phẩm đã có trong danh sách yêu thích" });
        }

        var wishlistItem = new WishlistItem
        {
            CustomerId = customer.Id,
            ProductId = dto.ProductId,
            CreatedAt = DateTime.Now
        };

        _context.WishlistItems.Add(wishlistItem);
        await _context.SaveChangesAsync();

        return Ok(new WishlistItemDto
        {
            Id = wishlistItem.Id,
            ProductId = wishlistItem.ProductId,
            ProductName = product.Name,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            IsInStock = product.Stock > 0
        });
    }

    // DELETE: api/wishlist/{productId}
    [HttpDelete("{productId}")]
    public async Task<ActionResult> RemoveFromWishlist(int productId)
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var wishlistItem = await _context.WishlistItems
            .FirstOrDefaultAsync(w => w.CustomerId == customer.Id && w.ProductId == productId);

        if (wishlistItem == null) return NotFound();

        _context.WishlistItems.Remove(wishlistItem);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
