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
public class CartController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    private async Task<Customer?> GetCurrentCustomer()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    // GET: api/cart
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetCart()
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var cartItems = await _context.CartItems
            .Include(c => c.Product)
            .Where(c => c.CustomerId == customer.Id)
            .Select(c => new CartItemDto
            {
                Id = c.Id,
                ProductId = c.ProductId,
                ProductName = c.Product!.Name,
                Price = c.Product.Price,
                ImageUrl = c.Product.ImageUrl,
                Quantity = c.Quantity
            })
            .ToListAsync();

        return Ok(cartItems);
    }

    // POST: api/cart
    [HttpPost]
    public async Task<ActionResult<CartItemDto>> AddToCart(AddCartItemDto dto)
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var product = await _context.Products.FindAsync(dto.ProductId);
        if (product == null) return NotFound(new { message = "Sản phẩm không tồn tại" });

        var cartItem = await _context.CartItems
            .FirstOrDefaultAsync(c => c.CustomerId == customer.Id && c.ProductId == dto.ProductId);

        if (cartItem != null)
        {
            cartItem.Quantity += dto.Quantity;
        }
        else
        {
            cartItem = new CartItem
            {
                CustomerId = customer.Id,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                CreatedAt = DateTime.Now
            };
            _context.CartItems.Add(cartItem);
        }

        await _context.SaveChangesAsync();

        return Ok(new CartItemDto
        {
            Id = cartItem.Id,
            ProductId = cartItem.ProductId,
            ProductName = product.Name,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Quantity = cartItem.Quantity
        });
    }

    // PUT: api/cart/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateQuantity(int id, UpdateCartItemDto dto)
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var cartItem = await _context.CartItems
            .FirstOrDefaultAsync(c => c.Id == id && c.CustomerId == customer.Id);

        if (cartItem == null) return NotFound();

        if (dto.Quantity <= 0)
        {
            _context.CartItems.Remove(cartItem);
        }
        else
        {
            cartItem.Quantity = dto.Quantity;
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/cart/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveFromCart(int id)
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var cartItem = await _context.CartItems
            .FirstOrDefaultAsync(c => c.Id == id && c.CustomerId == customer.Id);

        if (cartItem == null) return NotFound();

        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/cart/clear
    [HttpDelete("clear")]
    public async Task<ActionResult> ClearCart()
    {
        var customer = await GetCurrentCustomer();
        if (customer == null) return Unauthorized();

        var cartItems = await _context.CartItems
            .Where(c => c.CustomerId == customer.Id)
            .ToListAsync();

        _context.CartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
