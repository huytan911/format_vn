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
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] decimal? minPrice = null,
        [FromQuery] decimal? maxPrice = null,
        [FromQuery] bool? inStock = null,
        [FromQuery] string[]? colors = null,
        [FromQuery] string[]? materials = null,
        [FromQuery] int[]? categoryIds = null)
    {
        var query = _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .Include(p => p.Variants)
            .AsQueryable();

        // Filtering
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(p => p.Name.Contains(searchTerm) || (p.Description != null && p.Description.Contains(searchTerm)));
        }

        if (minPrice.HasValue)
        {
            query = query.Where(p => p.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }

        if (inStock.HasValue && inStock.Value)
        {
            query = query.Where(p => p.Stock > 0);
        }

        if (colors != null && colors.Any())
        {
            query = query.Where(p => p.Variants.Any(v => colors.Contains(v.Color)));
        }

        if (materials != null && materials.Any())
        {
            query = query.Where(p => p.Variants.Any(v => materials.Contains(v.Material)));
        }

        if (categoryIds != null && categoryIds.Any())
        {
            query = query.Where(p => p.ProductCategories.Any(pc => categoryIds.Contains(pc.CategoryId)));
        }

        // Sorting
        query = sortBy switch
        {
            "price_asc" => query.OrderBy(p => p.Price),
            "price_desc" => query.OrderByDescending(p => p.Price),
            "newest" => query.OrderByDescending(p => p.CreatedAt),
            _ => query.OrderByDescending(p => p.Id)
        };

        var products = await query.ToListAsync();
        return products.Select(MapToDto).ToList();
    }
    
    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.Id == id);
            
        if (product == null)
        {
            return NotFound();
        }
        
        return MapToDto(product);
    }
    
    // GET: api/products/category/1
    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(
        int categoryId,
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] decimal? minPrice = null,
        [FromQuery] decimal? maxPrice = null,
        [FromQuery] bool? inStock = null,
        [FromQuery] string[]? colors = null,
        [FromQuery] string[]? materials = null,
        [FromQuery] int[]? categoryIds = null)
    {
        var query = _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .Include(p => p.Variants)
            .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
            .AsQueryable();

        // Filtering
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(p => p.Name.Contains(searchTerm) || (p.Description != null && p.Description.Contains(searchTerm)));
        }

        if (minPrice.HasValue)
        {
            query = query.Where(p => p.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }

        if (inStock.HasValue && inStock.Value)
        {
            query = query.Where(p => p.Stock > 0);
        }

        if (colors != null && colors.Any())
        {
            query = query.Where(p => p.Variants.Any(v => colors.Contains(v.Color)));
        }

        if (materials != null && materials.Any())
        {
            query = query.Where(p => p.Variants.Any(v => materials.Contains(v.Material)));
        }

        // Additional Category filtering (for child categories within this category)
        if (categoryIds != null && categoryIds.Any())
        {
            query = query.Where(p => p.ProductCategories.Any(pc => categoryIds.Contains(pc.CategoryId)));
        }

        // Sorting
        query = sortBy switch
        {
            "price_asc" => query.OrderBy(p => p.Price),
            "price_desc" => query.OrderByDescending(p => p.Price),
            "newest" => query.OrderByDescending(p => p.CreatedAt),
            _ => query.OrderByDescending(p => p.Id)
        };

        var products = await query.ToListAsync();
        return products.Select(MapToDto).ToList();
    }

    // GET: api/products/filters
    [HttpGet("filters")]
    public async Task<ActionResult<FilterOptionsDto>> GetFilterOptions()
    {
        var colors = await _context.ProductVariants
            .Where(v => !string.IsNullOrEmpty(v.Color))
            .Select(v => v.Color!)
            .Distinct()
            .ToListAsync();

        var materials = await _context.ProductVariants
            .Where(v => !string.IsNullOrEmpty(v.Material))
            .Select(v => v.Material!)
            .Distinct()
            .ToListAsync();

        var prices = await _context.Products.Select(p => p.Price).ToListAsync();
        var minPrice = prices.Any() ? prices.Min() : 0;
        var maxPrice = prices.Any() ? prices.Max() : 0;

        var categories = await _context.Categories
            .Where(c => c.ParentId == null)
            .Select(c => new FilterCategoryDto { Id = c.Id, Name = c.Name })
            .ToListAsync();

        return new FilterOptionsDto
        {
            Colors = colors,
            Materials = materials,
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            Categories = categories
        };
    }

    // GET: api/products/category/{categoryId}/filters
    [HttpGet("category/{categoryId}/filters")]
    public async Task<ActionResult<FilterOptionsDto>> GetCategoryFilterOptions(int categoryId)
    {
        var productIds = await _context.ProductCategories
            .Where(pc => pc.CategoryId == categoryId)
            .Select(pc => pc.ProductId)
            .ToListAsync();

        var colors = await _context.ProductVariants
            .Where(v => productIds.Contains(v.ProductId) && !string.IsNullOrEmpty(v.Color))
            .Select(v => v.Color!)
            .Distinct()
            .ToListAsync();

        var materials = await _context.ProductVariants
            .Where(v => productIds.Contains(v.ProductId) && !string.IsNullOrEmpty(v.Material))
            .Select(v => v.Material!)
            .Distinct()
            .ToListAsync();

        var prices = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => p.Price)
            .ToListAsync();
            
        var minPrice = prices.Any() ? prices.Min() : 0;
        var maxPrice = prices.Any() ? prices.Max() : 0;

        var childCategories = await _context.Categories
            .Where(c => c.ParentId == categoryId)
            .Select(c => new FilterCategoryDto { Id = c.Id, Name = c.Name })
            .ToListAsync();

        return new FilterOptionsDto
        {
            Colors = colors,
            Materials = materials,
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            Categories = childCategories
        };
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
            IsFeatured = dto.IsFeatured
        };

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

        // Add Variants
        if (dto.Variants != null && dto.Variants.Any())
        {
            var hasDefault = dto.Variants.Any(v => v.IsDefault);
            for (int i = 0; i < dto.Variants.Count; i++)
            {
                var v = dto.Variants[i];
                product.Variants.Add(new ProductVariant
                {
                    Color = v.Color,
                    Material = v.Material,
                    Size = v.Size,
                    SKU = v.SKU,
                    Price = v.Price,
                    Stock = v.Stock,
                    ImageUrl = v.ImageUrl,
                    IsDefault = hasDefault ? v.IsDefault : (i == 0),
                    CreatedAt = DateTime.Now
                });
            }
        }
        // Calculate total stock from variants if they exist
        if (product.Variants.Any())
        {
            product.Stock = product.Variants.Sum(v => v.Stock);
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
        Console.WriteLine($"[UpdateProduct] Request for ID: {id}, Name: {dto.Name}, CategoryIds: {string.Join(",", dto.CategoryIds ?? new List<int>())}");

        if (id != dto.Id)
        {
            Console.WriteLine("[UpdateProduct] Mismatch ID");
            return BadRequest();
        }

        try {
            var product = await _context.Products
                .Include(p => p.ProductCategories)
                .Include(p => p.Variants)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                Console.WriteLine("[UpdateProduct] Product not found");
                return NotFound();
            }

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.Stock = dto.Stock;
            product.IsFeatured = dto.IsFeatured;
            
            // Update Categories
            var existingCategoryIds = product.ProductCategories.Select(pc => pc.CategoryId).ToList();
            var selectedCategoryIds = dto.CategoryIds ?? new List<int>();
            Console.WriteLine($"[UpdateProduct] Existing Cats: {string.Join(",", existingCategoryIds)}");
            Console.WriteLine($"[UpdateProduct] Selected Cats: {string.Join(",", selectedCategoryIds)}");

            // Identify categories to remove
            var categoriesToRemove = product.ProductCategories
                .Where(pc => !selectedCategoryIds.Contains(pc.CategoryId))
                .ToList();
                
            if (categoriesToRemove.Any())
            {
                Console.WriteLine($"[UpdateProduct] Removing {categoriesToRemove.Count} categories");
                _context.ProductCategories.RemoveRange(categoriesToRemove);
            }

            // Identify categories to add
            var categoriesToAdd = selectedCategoryIds
                .Where(id => !existingCategoryIds.Contains(id))
                .ToList();

            if (categoriesToAdd.Any())
            {
                Console.WriteLine($"[UpdateProduct] Adding {categoriesToAdd.Count} categories");
                foreach (var catId in categoriesToAdd)
                {
                    var category = await _context.Categories.FindAsync(catId);
                    if (category != null)
                    {
                        var newPc = new ProductCategory
                        {
                            ProductId = product.Id,
                            CategoryId = catId
                        };
                        _context.ProductCategories.Add(newPc);
                        // Console.WriteLine($"[UpdateProduct] Added relation Product {product.Id} - Category {catId}");
                    }
                    else 
                    {
                        Console.WriteLine($"[UpdateProduct] Category {catId} not found");
                    }
                }
            }

            // Update Variants
            // Remove variants not in the new list
            var newVariantIds = dto.Variants.Where(v => v.Id > 0).Select(v => v.Id).ToList();
            var variantsToRemove = product.Variants.Where(v => !newVariantIds.Contains(v.Id)).ToList();
            if (variantsToRemove.Any())
            {
                _context.ProductVariants.RemoveRange(variantsToRemove);
            }

            // Update or Add variants
            foreach (var vDto in dto.Variants)
            {
                if (vDto.Id > 0)
                {
                    var existingV = product.Variants.FirstOrDefault(v => v.Id == vDto.Id);
                    if (existingV != null)
                    {
                        existingV.Color = vDto.Color;
                        existingV.Material = vDto.Material;
                        existingV.Size = vDto.Size;
                        existingV.SKU = vDto.SKU;
                        existingV.Price = vDto.Price;
                        existingV.Stock = vDto.Stock;
                        existingV.ImageUrl = vDto.ImageUrl;
                        existingV.IsDefault = vDto.IsDefault;
                    }
                }
                else
                {
                    product.Variants.Add(new ProductVariant
                    {
                        Color = vDto.Color,
                        Material = vDto.Material,
                        Size = vDto.Size,
                        SKU = vDto.SKU,
                        Price = vDto.Price,
                        Stock = vDto.Stock,
                        ImageUrl = vDto.ImageUrl,
                        IsDefault = vDto.IsDefault,
                        CreatedAt = DateTime.Now
                    });
                }
            }

            // Ensure exactly one default if variants exist
            if (product.Variants.Any())
            {
                var defaultVariants = product.Variants.Where(v => v.IsDefault).ToList();
                if (defaultVariants.Count == 0)
                {
                    product.Variants.First().IsDefault = true;
                }
                else if (defaultVariants.Count > 1)
                {
                    // keep only the first one as default
                    for (int i = 1; i < defaultVariants.Count; i++)
                    {
                        defaultVariants[i].IsDefault = false;
                    }
                }

                // Sync total stock
                product.Stock = product.Variants.Sum(v => v.Stock);
            }

            await _context.SaveChangesAsync();
            Console.WriteLine("[UpdateProduct] Save successful");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[UpdateProduct] ERROR: {ex.Message}");
            Console.WriteLine($"[UpdateProduct] Inner Exception: {ex.InnerException?.Message}");
            Console.WriteLine(ex.StackTrace);
            if (!ProductExists(id))
            {
                 Console.WriteLine("[UpdateProduct] Product no longer exists");
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
            UpdatedAt = p.UpdatedAt,
            Categories = p.ProductCategories.Select(pc => new CategoryDto
            {
                Id = pc.Category.Id,
                Name = pc.Category.Name,
                ImageUrl = pc.Category.ImageUrl,
                CreatedAt = pc.Category.CreatedAt,
                UpdatedAt = pc.Category.UpdatedAt
            }).ToList(),
            Variants = p.Variants.Select(v => new ProductVariantDto
            {
                Id = v.Id,
                ProductId = v.ProductId,
                Color = v.Color,
                Material = v.Material,
                Size = v.Size,
                SKU = v.SKU,
                Price = v.Price,
                Stock = v.Stock,
                ImageUrl = v.ImageUrl,
                IsDefault = v.IsDefault,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            }).ToList()
        };
    }
}
