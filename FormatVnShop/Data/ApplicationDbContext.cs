using Microsoft.EntityFrameworkCore;
using FormatVnShop.Models;

namespace FormatVnShop.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<AdminUser> AdminUsers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure Many-to-Many
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);
            
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId);
        
        // Configure Category Hierarchy
        modelBuilder.Entity<Category>()
            .HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "NỮ", Description = "Thời trang nữ", ImageUrl = "/images/categories/nu.jpg" },
            new Category { Id = 2, Name = "NAM", Description = "Thời trang nam", ImageUrl = "/images/categories/nam.jpg" },
            new Category { Id = 3, Name = "PHỤ KIỆN", Description = "Phụ kiện thời trang", ImageUrl = "/images/categories/phukien.jpg" }
        );
        
        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            // Women's Fashion (NỮ) - CategoryId = 1
            new Product
            {
                Id = 1,
                Name = "Áo măng tô dạ khâu tay dây lưng rời",
                Description = "Masterpiece by FORMAT. Kỹ thuật khâu tay thủ công tỉ mỉ, chất liệu dạ ấm áp (80% wool). Dáng suông dài, cổ hai ve.",
                Price = 1827000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10000752.jpg",
                Stock = 15,
                IsFeatured = true,
                CreatedAt = DateTime.Now
            },
            new Product
            {
                Id = 2,
                Name = "Quần ống suông dạ dây lưng rời",
                Description = "Quần ống suông chất liệu dạ cao cấp, đi kèm dây lưng rời. Phong cách lịch lãm cho phái nữ.",
                Price = 1290000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10005601.jpg",
                Stock = 25,
                IsFeatured = true,
                CreatedAt = DateTime.Now
            },
            new Product
            {
                Id = 3,
                Name = "Áo Gile dạ 2 lớp không cổ",
                Description = "Thiết kế 2 lớp dày dặn, không cổ trẻ trung. Chất liệu dạ mịn, giữ ấm tốt.",
                Price = 1290000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10005588.jpg",
                Stock = 30,
                IsFeatured = false,
                CreatedAt = DateTime.Now
            },
            new Product
            {
                Id = 4,
                Name = "Chân váy dạ 2 lớp cạp liền chun",
                Description = "Chân váy dạ 2 lớp, thiết kế cạp chun thoải mái, lịch sự cho công sở.",
                Price = 1590000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10005515.jpg",
                Stock = 20,
                IsFeatured = true,
                CreatedAt = DateTime.Now
            },
            
            // Men's Fashion (NAM) - CategoryId = 2
            new Product
            {
                Id = 5,
                Name = "Áo polo nam không đường may cổ đức",
                Description = "Công nghệ không đường may hiện đại, chất liệu cotton cao cấp, thoáng khí và bền màu.",
                Price = 1014000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10005496.jpg",
                Stock = 40,
                IsFeatured = true,
                CreatedAt = DateTime.Now
            },
            new Product
            {
                Id = 6,
                Name = "Áo khoác tay dài nam",
                Description = "Áo khoác nam thiết kế sang trọng, chất liệu cao cấp, giữ ấm hiệu quả cho mùa đông.",
                Price = 3570000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10005390.jpg",
                Stock = 35,
                IsFeatured = false,
                CreatedAt = DateTime.Now
            },
            new Product
            {
                Id = 7,
                Name = "Quần ống bó nỉ cạp chun luồn dây",
                Description = "Quần nỉ nam năng động, cạp chun có dây rút, phù hợp cho phong cách thể thao/dạo phố.",
                Price = 750000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10004947.jpg",
                Stock = 18,
                IsFeatured = true,
                CreatedAt = DateTime.Now
            },
            new Product
            {
                Id = 8,
                Name = "Áo giữ nhiệt WarmMax Light cổ tròn",
                Description = "Công nghệ giữ nhiệt WarmMax độc quyền, mỏng nhẹ, giữ ấm cơ thể tối ưu.",
                Price = 245000,
                // CategoryId removed
                ImageUrl = "https://format.vn/media/catalog/product/1/0/10000183.jpg",
                Stock = 12,
                IsFeatured = true,
                CreatedAt = DateTime.Now
            }
        );
        
        // Seed ProductCategories
        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory { ProductId = 1, CategoryId = 1 },
            new ProductCategory { ProductId = 2, CategoryId = 1 },
            new ProductCategory { ProductId = 3, CategoryId = 1 },
            new ProductCategory { ProductId = 4, CategoryId = 1 },
            new ProductCategory { ProductId = 5, CategoryId = 2 },
            new ProductCategory { ProductId = 6, CategoryId = 2 },
            new ProductCategory { ProductId = 7, CategoryId = 2 },
            new ProductCategory { ProductId = 8, CategoryId = 2 }
        );
        
        // Seed Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                Name = "Nguyễn Văn An",
                Email = "nguyenvanan@gmail.com",
                Phone = "0901234567",
                Address = "123 Nguyễn Huệ, Q1, TP.HCM",
                CreatedAt = DateTime.Now.AddMonths(-6)
            },
            new Customer
            {
                Id = 2,
                Name = "Trần Thị Bình",
                Email = "tranthibinh@gmail.com",
                Phone = "0912345678",
                Address = "456 Lê Lợi, Q3, TP.HCM",
                CreatedAt = DateTime.Now.AddMonths(-4)
            },
            new Customer
            {
                Id = 3,
                Name = "Lê Minh Cường",
                Email = "leminhcuong@gmail.com",
                Phone = "0923456789",
                Address = "789 Trần Hưng Đạo, Q5, TP.HCM",
                CreatedAt = DateTime.Now.AddMonths(-3)
            },
            new Customer
            {
                Id = 4,
                Name = "Phạm Thu Dung",
                Email = "phamthudung@gmail.com",
                Phone = "0934567890",
                Address = "321 Võ Văn Tần, Q10, TP.HCM",
                CreatedAt = DateTime.Now.AddMonths(-2)
            },
            new Customer
            {
                Id = 5,
                Name = "Hoàng Quốc Việt",
                Email = "hoangquocviet@gmail.com",
                Phone = "0945678901",
                Address = "654 Hai Bà Trưng, Q1, Hà Nội",
                CreatedAt = DateTime.Now.AddMonths(-1)
            }
        );
        
        // Seed Orders
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                OrderNumber = "ORD-2026-0001",
                CustomerId = 1,
                OrderDate = DateTime.Now.AddDays(-30),
                TotalAmount = 3117000,
                Status = "Delivered",
                ShippingAddress = "123 Nguyễn Huệ, Q1, TP.HCM"
            },
            new Order
            {
                Id = 2,
                OrderNumber = "ORD-2026-0002",
                CustomerId = 2,
                OrderDate = DateTime.Now.AddDays(-20),
                TotalAmount = 2580000,
                Status = "Delivered",
                ShippingAddress = "456 Lê Lợi, Q3, TP.HCM"
            },
            new Order
            {
                Id = 3,
                OrderNumber = "ORD-2026-0003",
                CustomerId = 3,
                OrderDate = DateTime.Now.AddDays(-15),
                TotalAmount = 1827000,
                Status = "Shipped",
                ShippingAddress = "789 Trần Hưng Đạo, Q5, TP.HCM"
            },
            new Order
            {
                Id = 4,
                OrderNumber = "ORD-2026-0004",
                CustomerId = 4,
                OrderDate = DateTime.Now.AddDays(-10),
                TotalAmount = 4320000,
                Status = "Processing",
                ShippingAddress = "321 Võ Văn Tần, Q10, TP.HCM"
            },
            new Order
            {
                Id = 5,
                OrderNumber = "ORD-2026-0005",
                CustomerId = 5,
                OrderDate = DateTime.Now.AddDays(-5),
                TotalAmount = 1014000,
                Status = "Pending",
                ShippingAddress = "654 Hai Bà Trưng, Q1, Hà Nội"
            },
            new Order
            {
                Id = 6,
                OrderNumber = "ORD-2026-0006",
                CustomerId = 1,
                OrderDate = DateTime.Now.AddDays(-2),
                TotalAmount = 1590000,
                Status = "Pending",
                ShippingAddress = "123 Nguyễn Huệ, Q1, TP.HCM"
            }
        );
        
        // Seed OrderItems
        modelBuilder.Entity<OrderItem>().HasData(
            // Order 1 Items
            new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1827000 },
            new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1290000 },
            
            // Order 2 Items
            new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Quantity = 2, UnitPrice = 1290000 },
            
            // Order 3 Items
            new OrderItem { Id = 4, OrderId = 3, ProductId = 1, Quantity = 1, UnitPrice = 1827000 },
            
            // Order 4 Items
            new OrderItem { Id = 5, OrderId = 4, ProductId = 6, Quantity = 1, UnitPrice = 3570000 },
            new OrderItem { Id = 6, OrderId = 4, ProductId = 7, Quantity = 1, UnitPrice = 750000 },
            
            // Order 5 Items
            new OrderItem { Id = 7, OrderId = 5, ProductId = 5, Quantity = 1, UnitPrice = 1014000 },
            
            // Order 6 Items
            new OrderItem { Id = 8, OrderId = 6, ProductId = 4, Quantity = 1, UnitPrice = 1590000 }
        );
        
        // Seed AdminUsers
        modelBuilder.Entity<AdminUser>().HasData(
            new AdminUser
            {
                Id = 1,
                Username = "admin",
                Email = "admin@format.vn",
                // Password: Admin@123
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                Role = AdminRole.SuperAdmin,
                IsActive = true,
                CreatedAt = DateTime.Now.AddMonths(-6)
            },
            new AdminUser
            {
                Id = 2,
                Username = "manager",
                Email = "manager@format.vn",
                // Password: Manager@123
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Manager@123"),
                Role = AdminRole.Manager,
                IsActive = true,
                CreatedAt = DateTime.Now.AddMonths(-3)
            },
            new AdminUser
            {
                Id = 3,
                Username = "staff",
                Email = "staff@format.vn",
                // Password: Staff@123
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Staff@123"),
                Role = AdminRole.Staff,
                IsActive = true,
                CreatedAt = DateTime.Now.AddMonths(-1)
            }
        );
    }
}
