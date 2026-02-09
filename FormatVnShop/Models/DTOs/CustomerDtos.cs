namespace FormatVnShop.Models.DTOs;

public class CustomerRegisterDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool IsSubscribed { get; set; }
}

public class CustomerProfileDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool IsSubscribed { get; set; }
}

public class CustomerAuthResponse
{
    public required string Token { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public DateTime ExpiresAt { get; set; }
}
