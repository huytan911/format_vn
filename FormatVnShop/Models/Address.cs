using System.ComponentModel.DataAnnotations;

namespace FormatVnShop.Models;

public class Address : BaseEntity
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; }

    [Required]
    public required string ReceiverName { get; set; }
    
    [Required]
    public required string PhoneNumber { get; set; }
    
    [Required]
    public required string AddressLine { get; set; }
    
    [Required]
    public required string City { get; set; }
    
    [Required]
    public required string District { get; set; }
    
    [Required]
    public required string Ward { get; set; }
    
    public string? Note { get; set; }
    
    public bool IsDefault { get; set; }

    // Navigation property
    public Customer? Customer { get; set; }
}
