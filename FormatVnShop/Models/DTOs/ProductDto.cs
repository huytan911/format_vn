namespace FormatVnShop.Models.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public int Stock { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<CategoryDto> Categories { get; set; } = new();
    public List<ProductVariantDto> Variants { get; set; } = new();
}

public class ProductVariantDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? Color { get; set; }
    public string? Material { get; set; }
    public string? Size { get; set; }
    public string? SKU { get; set; }
    public decimal? Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsDefault { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
