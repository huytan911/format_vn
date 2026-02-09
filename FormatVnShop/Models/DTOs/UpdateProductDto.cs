using System.ComponentModel.DataAnnotations;

namespace FormatVnShop.Models.DTOs;

public class UpdateProductDto
{
    public int Id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    
    public string? ImageUrl { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [Range(0, int.MaxValue)]
    public int Weight { get; set; } // In grams
    
    public bool IsFeatured { get; set; }
    
    public List<int> CategoryIds { get; set; } = new();
    public List<ProductVariantDto> Variants { get; set; } = new();
}
