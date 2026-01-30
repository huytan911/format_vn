namespace FormatVnShop.Models;

public enum AdminRole
{
    SuperAdmin,
    Manager,
    Staff
}

public class AdminUser : BaseEntity
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public AdminRole Role { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }
}
