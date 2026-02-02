using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReceiverName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ward = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 2, 15, 48, 3, 358, DateTimeKind.Local).AddTicks(4477), "$2a$11$uCVyCA1gOI/R7nruzlcHpeIJ9nCsH.War1XHEPiifSVOIg7TMTE7a", new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 15, 48, 3, 536, DateTimeKind.Local).AddTicks(908), "$2a$11$5Sx0vSq/QhlPLSJMyI5A0enSEaQ7nPA9QAuK4JyQ9YES6.n/eaHo2", new DateTime(2026, 2, 2, 15, 48, 3, 358, DateTimeKind.Local).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 15, 48, 3, 708, DateTimeKind.Local).AddTicks(9181), "$2a$11$VoH8MAj0wGcOcInzlpcXs.D2/7JicI.GrHGdBTPvOPGx2paFnQtqe", new DateTime(2026, 2, 2, 15, 48, 3, 536, DateTimeKind.Local).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(932), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(956), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(963), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(965) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 2, 15, 48, 2, 410, DateTimeKind.Local).AddTicks(7105), "$2a$11$nPn678uh2MARywlOuWIlKuVUKYoZOep2WS600hWV8ZItV7NMYun3W", new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1583) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 2, 15, 48, 2, 593, DateTimeKind.Local).AddTicks(5414), "$2a$11$Yvy28qldrhv2Rm2vyGbR1.Hp7vnEnG9GzGd0mxS2X089SCPHQWgea", new DateTime(2026, 2, 2, 15, 48, 2, 410, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 15, 48, 2, 784, DateTimeKind.Local).AddTicks(528), "$2a$11$4CLUVo98YNUYhAqDAsdHkOMJTQHo9Btbiv1MJYlj5hbU8pxq1A7WS", new DateTime(2026, 2, 2, 15, 48, 2, 593, DateTimeKind.Local).AddTicks(5553) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 2, 15, 48, 2, 991, DateTimeKind.Local).AddTicks(6652), "$2a$11$PqhLHSC5mUlCTUKbY7Co0.Kk5rHmQmIKuW5EuPZOdY0cawUZyhAE6", new DateTime(2026, 2, 2, 15, 48, 2, 784, DateTimeKind.Local).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(2670), "$2a$11$r9MpLJQNQjOCzwRcnBkPWuQegUzTDOLq0B5vQ0ILtvxh6SPivaPUa", new DateTime(2026, 2, 2, 15, 48, 2, 991, DateTimeKind.Local).AddTicks(6709) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3988), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3993), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4113), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4115), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4117), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4120), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4122), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4125), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3769), new DateTime(2026, 1, 3, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3775), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3773) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3804), new DateTime(2026, 1, 13, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3806), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3805) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3810), new DateTime(2026, 1, 18, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3813), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3811) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3817), new DateTime(2026, 1, 23, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3819), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3823), new DateTime(2026, 1, 28, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3827), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3830), new DateTime(2026, 1, 31, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3832), new DateTime(2026, 2, 2, 15, 48, 3, 185, DateTimeKind.Local).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1505), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1519), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1513) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1526), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1523) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1267), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1277), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1273) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1285), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1282) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1294), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1302), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1299) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1347), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1313) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1354), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1352) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1362), new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(1359) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 2, 13, 46, 54, 294, DateTimeKind.Local).AddTicks(5669), "$2a$11$6XjYLrjkRYwu2X/hLBK8fewaOBbQx1SZ7e0eLurYT2GIhfmUfDG/2", new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7583) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 13, 46, 54, 469, DateTimeKind.Local).AddTicks(6388), "$2a$11$Mpx/TP2.mEeMvY61KLQvUu.IXQFlrYKw3ap73hjZKWDzBnj.1I/za", new DateTime(2026, 2, 2, 13, 46, 54, 294, DateTimeKind.Local).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 46, 54, 646, DateTimeKind.Local).AddTicks(8561), "$2a$11$JUi6z9bqH.oFLSDlbPOgpe5FINN0aZlTu5Z1gLrTvqEqOYScTPVOm", new DateTime(2026, 2, 2, 13, 46, 54, 469, DateTimeKind.Local).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4377), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4400), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4402) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4406), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4408) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 2, 13, 46, 53, 433, DateTimeKind.Local).AddTicks(3675), "$2a$11$zcgCn8.yLsRExpl2qqWMIuT1IwE6lixvnCFuMRxd7IJg60noex5P6", new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(5001) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 46, 53, 605, DateTimeKind.Local).AddTicks(2536), "$2a$11$KeKNy8nCnwFFsujA9PUgr.0I5ZLJLfCxoZt2HGMgPoCvozm51Rw9a", new DateTime(2026, 2, 2, 13, 46, 53, 433, DateTimeKind.Local).AddTicks(3736) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 2, 13, 46, 53, 775, DateTimeKind.Local).AddTicks(4779), "$2a$11$.7KUSZDb6GpnQ7yWxKmlVOfCi/M9hSDohZ0ApXTvxhhW7FpVTQqCe", new DateTime(2026, 2, 2, 13, 46, 53, 605, DateTimeKind.Local).AddTicks(2653) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 2, 13, 46, 53, 945, DateTimeKind.Local).AddTicks(6904), "$2a$11$NDPncAhqLbRcdPRmHxz5W.3D5uqosFJeLfmhJiMTKcr57TVpPhYOu", new DateTime(2026, 2, 2, 13, 46, 53, 775, DateTimeKind.Local).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(4829), "$2a$11$tGMOl5ZfCl2/qgCDZpLIbOa4dbZD67Cdv5w7OhwZd.9dlxpECPraq", new DateTime(2026, 2, 2, 13, 46, 53, 945, DateTimeKind.Local).AddTicks(6955) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7223), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7229), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7410), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7412) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7414), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7417), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7421), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7425), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7426) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7428), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(6973), new DateTime(2026, 1, 3, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(6983), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7007), new DateTime(2026, 1, 13, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7009), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7008) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7011), new DateTime(2026, 1, 18, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7018), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7012) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7021), new DateTime(2026, 1, 23, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7025), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7024) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7029), new DateTime(2026, 1, 28, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7031), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7034), new DateTime(2026, 1, 31, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7036), new DateTime(2026, 2, 2, 13, 46, 54, 123, DateTimeKind.Local).AddTicks(7035) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4930), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4925) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4937), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4945), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4942) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4664), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4673), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4681), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4678) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4691), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4687) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4700), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4696) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4747), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4756), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4777), new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4774) });
        }
    }
}
