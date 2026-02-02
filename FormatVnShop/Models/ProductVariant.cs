namespace FormatVnShop.Models;

public class ProductVariant : BaseEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    public string? Color { get; set; }
    public string? Material { get; set; }
    public string? Size { get; set; }
    public string? SKU { get; set; }
    public decimal? Price { get; set; } 
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsDefault { get; set; }
}
