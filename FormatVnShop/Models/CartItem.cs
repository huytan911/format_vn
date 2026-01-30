using System.ComponentModel.DataAnnotations;

namespace FormatVnShop.Models;

public class CartItem : BaseEntity
{
    public int Id { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
    // Navigation properties
    public Customer? Customer { get; set; }
    public Product? Product { get; set; }
}
