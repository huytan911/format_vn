using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDefaultToProductVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ProductVariants",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedAt", "IsDefault", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4930), false, new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4925) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDefault", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4937), false, new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDefault", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4945), false, new DateTime(2026, 2, 2, 13, 46, 53, 262, DateTimeKind.Local).AddTicks(4942) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ProductVariants");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 17, 10, 21, 778, DateTimeKind.Local).AddTicks(6293), "$2a$11$6WypvsLj9Dw8qaG14HUqguyaU8mhxAaeXOGeltqhIdHd6Fjpk/UAm", new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(375) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 17, 10, 21, 966, DateTimeKind.Local).AddTicks(5406), "$2a$11$O6/ogyYGFCff1dWkR34qPOFrybwa4je.h2XAkJK6Uc.KxloEitnbW", new DateTime(2026, 1, 30, 17, 10, 21, 778, DateTimeKind.Local).AddTicks(6373) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 10, 22, 164, DateTimeKind.Local).AddTicks(5473), "$2a$11$.hYuYKsC8/7FvCX087PE2u7eimW6bwRnnsM/1FSbc9zRETX3ThsZi", new DateTime(2026, 1, 30, 17, 10, 21, 966, DateTimeKind.Local).AddTicks(5445) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(6782), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(6837), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(6848), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 17, 10, 20, 886, DateTimeKind.Local).AddTicks(4107), "$2a$11$oKKBVXfRkqf0Eu.URev36u9m34qidgqd2gJFkJF6STLJcAm4NA9ZC", new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 17, 10, 21, 66, DateTimeKind.Local).AddTicks(2795), "$2a$11$iCtFktyhoveAwnob.ECcl.v1s7hvUuX2pgop1re2CYyYXdDwv7DHu", new DateTime(2026, 1, 30, 17, 10, 20, 886, DateTimeKind.Local).AddTicks(4594) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 17, 10, 21, 243, DateTimeKind.Local).AddTicks(4478), "$2a$11$gP.KAU3jFQAsx.XF0VjoNOMorDqUktwH5922zaauBPB901o/wA8R2", new DateTime(2026, 1, 30, 17, 10, 21, 66, DateTimeKind.Local).AddTicks(2859) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 17, 10, 21, 420, DateTimeKind.Local).AddTicks(4643), "$2a$11$GgBoEfH5lCd/4tTm396aDOiaW8/oi23xr.dZFilzB7Hjy9UT61wRu", new DateTime(2026, 1, 30, 17, 10, 21, 243, DateTimeKind.Local).AddTicks(4539) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(8493), "$2a$11$JhjYQ2i4ksvIQ9r7XObH4.ts3Dn5IXG4GSnQL3uIuWNZF5qmUJKS6", new DateTime(2026, 1, 30, 17, 10, 21, 420, DateTimeKind.Local).AddTicks(4698) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9963), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(81), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(84) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(110), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(114) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(117), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(123), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(125) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(129), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(240), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(242) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(246), new DateTime(2026, 1, 30, 17, 10, 21, 594, DateTimeKind.Local).AddTicks(248) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9671), new DateTime(2025, 12, 31, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9687), new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9782), new DateTime(2026, 1, 10, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9788), new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9784) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9798), new DateTime(2026, 1, 15, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9804), new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9801) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9808), new DateTime(2026, 1, 20, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9814), new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9811) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9818), new DateTime(2026, 1, 25, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9824), new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9828), new DateTime(2026, 1, 28, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9832), new DateTime(2026, 1, 30, 17, 10, 21, 593, DateTimeKind.Local).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8002), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7988) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8010), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8007) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8018), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8015) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7620), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7578) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7630), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7638), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7646), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7643) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7658), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7652) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7760), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7768), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7765) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7776), new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7773) });
        }
    }
}
