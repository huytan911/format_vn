using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FormatVnShop.Data;
using FormatVnShop.Models;
using FormatVnShop.Models.DTOs;

namespace FormatVnShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .ToListAsync();

        return products.Select(MapToDto).ToList();
    }
    
    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
            
        if (product == null)
        {
            return NotFound();
        }
        
        return MapToDto(product);
    }
    
    // GET: api/products/category/1
    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(int categoryId)
    {
        var products = await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
            .ToListAsync();
            
        return products.Select(MapToDto).ToList();
    }
    
    // GET: api/products/featured
    [HttpGet("featured")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetFeaturedProducts()
    {
        var products = await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .Where(p => p.IsFeatured)
            .Take(6)
            .ToListAsync();
            
        return products.Select(MapToDto).ToList();
    }
    
    // POST: api/products
    [HttpPost]
    [Authorize(Roles = "SuperAdmin,Manager,Staff")]
    public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl,
            Stock = dto.Stock,
            IsFeatured = dto.IsFeatured,
            CreatedAt = DateTime.Now
        };

        // Add Categories
        if (dto.CategoryIds != null && dto.CategoryIds.Any())
        {
            foreach (var catId in dto.CategoryIds)
            {
                var category = await _context.Categories.FindAsync(catId);
                if (category != null)
                {
                    product.ProductCategories.Add(new ProductCategory
                    {
                        Product = product,
                        ProductId = product.Id, // Will be set after save? No, EF handles this graph
                        Category = category,
                        CategoryId = catId
                    });
                }
            }
        }
        
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        
        // Reload to get populated categories
        return await GetProduct(product.Id);
    }

    // PUT: api/products/5
    [HttpPut("{id}")]
    [Authorize(Roles = "SuperAdmin,Manager,Staff")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest();
        }

        var product = await _context.Products
            .Include(p => p.ProductCategories)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.ImageUrl = dto.ImageUrl;
        product.Stock = dto.Stock;
        product.IsFeatured = dto.IsFeatured;
        
        // Update Categories
        // Remove existing
        _context.ProductCategories.RemoveRange(product.ProductCategories);
        
        // Add new
        if (dto.CategoryIds != null)
        {
            foreach (var catId in dto.CategoryIds)
            {
                var category = await _context.Categories.FindAsync(catId);
                if (category != null)
                {
                    _context.ProductCategories.Add(new ProductCategory
                    {
                        ProductId = product.Id,
                        CategoryId = catId
                    });
                }
            }
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
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

    // DELETE: api/products/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "SuperAdmin,Manager")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
    
    private static ProductDto MapToDto(Product p)
    {
        return new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            Stock = p.Stock,
            IsFeatured = p.IsFeatured,
            CreatedAt = p.CreatedAt,
            Categories = p.ProductCategories.Select(pc => new CategoryDto
            {
                Id = pc.Category.Id,
                Name = pc.Category.Name,
                ImageUrl = pc.Category.ImageUrl
            }).ToList()
        };
    }
}
