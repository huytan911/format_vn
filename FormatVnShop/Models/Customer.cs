namespace FormatVnShop.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Navigation property
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
