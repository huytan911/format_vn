namespace FormatVnShop.Models;

public class Order : BaseEntity
{
    public int Id { get; set; }
    public required string OrderNumber { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public required string Status { get; set; } // Pending, Processing, Shipped, Delivered, Cancelled
    public string? ShippingAddress { get; set; }
    
    // Navigation properties
    public Customer? Customer { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
