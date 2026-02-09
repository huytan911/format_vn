namespace FormatVnShop.Models;

public class Product : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public int Stock { get; set; }
    public int Weight { get; set; } // In grams
    public bool IsFeatured { get; set; }
    
    // Navigation property
    public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
}
