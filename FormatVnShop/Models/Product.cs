namespace FormatVnShop.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string? ImageUrl { get; set; }
    public int Stock { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Navigation property
    public Category? Category { get; set; }
}
