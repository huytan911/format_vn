using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FormatVnShop.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategoriesManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShippingAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "LastLoginAt", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 29, 16, 25, 5, 812, DateTimeKind.Local).AddTicks(8607), "admin@format.vn", true, null, "$2a$11$x261l.G2CrhEqUNXgztG/OdKBpCM/Msm5Uq.vz06WdWlAshKPXyqK", 0, "admin" },
                    { 2, new DateTime(2025, 10, 29, 16, 25, 6, 50, DateTimeKind.Local).AddTicks(2292), "manager@format.vn", true, null, "$2a$11$lGctgYwMnGI7ZOypi2JM2OhnTXg8fU2TKMKAHpEQ8zWfX2/RrVNAm", 1, "manager" },
                    { 3, new DateTime(2025, 12, 29, 16, 25, 6, 265, DateTimeKind.Local).AddTicks(7486), "staff@format.vn", true, null, "$2a$11$YUl45ZaoaVOj7zjFlXMAxuT0mWnFhEzYAHAwwAU40dbJyJEIAOz2S", 2, "staff" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Thời trang nữ", "/images/categories/nu.jpg", "NỮ" },
                    { 2, "Thời trang nam", "/images/categories/nam.jpg", "NAM" },
                    { 3, "Phụ kiện thời trang", "/images/categories/phukien.jpg", "PHỤ KIỆN" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Nguyễn Huệ, Q1, TP.HCM", new DateTime(2025, 7, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8315), "nguyenvanan@gmail.com", "Nguyễn Văn An", "0901234567" },
                    { 2, "456 Lê Lợi, Q3, TP.HCM", new DateTime(2025, 9, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8333), "tranthibinh@gmail.com", "Trần Thị Bình", "0912345678" },
                    { 3, "789 Trần Hưng Đạo, Q5, TP.HCM", new DateTime(2025, 10, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8338), "leminhcuong@gmail.com", "Lê Minh Cường", "0923456789" },
                    { 4, "321 Võ Văn Tần, Q10, TP.HCM", new DateTime(2025, 11, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8342), "phamthudung@gmail.com", "Phạm Thu Dung", "0934567890" },
                    { 5, "654 Hai Bà Trưng, Q1, Hà Nội", new DateTime(2025, 12, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8378), "hoangquocviet@gmail.com", "Hoàng Quốc Việt", "0945678901" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsFeatured", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(7988), "Masterpiece by FORMAT. Kỹ thuật khâu tay thủ công tỉ mỉ, chất liệu dạ ấm áp (80% wool). Dáng suông dài, cổ hai ve.", "https://format.vn/media/catalog/product/1/0/10000752.jpg", true, "Áo măng tô dạ khâu tay dây lưng rời", 1827000m, 15 },
                    { 2, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8038), "Quần ống suông chất liệu dạ cao cấp, đi kèm dây lưng rời. Phong cách lịch lãm cho phái nữ.", "https://format.vn/media/catalog/product/1/0/10005601.jpg", true, "Quần ống suông dạ dây lưng rời", 1290000m, 25 },
                    { 3, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8046), "Thiết kế 2 lớp dày dặn, không cổ trẻ trung. Chất liệu dạ mịn, giữ ấm tốt.", "https://format.vn/media/catalog/product/1/0/10005588.jpg", false, "Áo Gile dạ 2 lớp không cổ", 1290000m, 30 },
                    { 4, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8052), "Chân váy dạ 2 lớp, thiết kế cạp chun thoải mái, lịch sự cho công sở.", "https://format.vn/media/catalog/product/1/0/10005515.jpg", true, "Chân váy dạ 2 lớp cạp liền chun", 1590000m, 20 },
                    { 5, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8058), "Công nghệ không đường may hiện đại, chất liệu cotton cao cấp, thoáng khí và bền màu.", "https://format.vn/media/catalog/product/1/0/10005496.jpg", true, "Áo polo nam không đường may cổ đức", 1014000m, 40 },
                    { 6, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8064), "Áo khoác nam thiết kế sang trọng, chất liệu cao cấp, giữ ấm hiệu quả cho mùa đông.", "https://format.vn/media/catalog/product/1/0/10005390.jpg", false, "Áo khoác tay dài nam", 3570000m, 35 },
                    { 7, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8069), "Quần nỉ nam năng động, cạp chun có dây rút, phù hợp cho phong cách thể thao/dạo phố.", "https://format.vn/media/catalog/product/1/0/10004947.jpg", true, "Quần ống bó nỉ cạp chun luồn dây", 750000m, 18 },
                    { 8, new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8075), "Công nghệ giữ nhiệt WarmMax độc quyền, mỏng nhẹ, giữ ấm cơ thể tối ưu.", "https://format.vn/media/catalog/product/1/0/10000183.jpg", true, "Áo giữ nhiệt WarmMax Light cổ tròn", 245000m, 12 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "OrderNumber", "ShippingAddress", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 12, 30, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8501), "ORD-2026-0001", "123 Nguyễn Huệ, Q1, TP.HCM", "Delivered", 3117000m },
                    { 2, 2, new DateTime(2026, 1, 9, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8519), "ORD-2026-0002", "456 Lê Lợi, Q3, TP.HCM", "Delivered", 2580000m },
                    { 3, 3, new DateTime(2026, 1, 14, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8529), "ORD-2026-0003", "789 Trần Hưng Đạo, Q5, TP.HCM", "Shipped", 1827000m },
                    { 4, 4, new DateTime(2026, 1, 19, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8535), "ORD-2026-0004", "321 Võ Văn Tần, Q10, TP.HCM", "Processing", 4320000m },
                    { 5, 5, new DateTime(2026, 1, 24, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8539), "ORD-2026-0005", "654 Hai Bà Trưng, Q1, Hà Nội", "Pending", 1014000m },
                    { 6, 1, new DateTime(2026, 1, 27, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8549), "ORD-2026-0006", "123 Nguyễn Huệ, Q1, TP.HCM", "Pending", 1590000m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1827000m },
                    { 2, 1, 2, 1, 1290000m },
                    { 3, 2, 3, 2, 1290000m },
                    { 4, 3, 1, 1, 1827000m },
                    { 5, 4, 6, 1, 3570000m },
                    { 6, 4, 7, 1, 750000m },
                    { 7, 5, 5, 1, 1014000m },
                    { 8, 6, 4, 1, 1590000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
