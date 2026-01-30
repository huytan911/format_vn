using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVariantImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductVariants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8002), null, new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(7988) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8010), null, new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8007) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8018), null, new DateTime(2026, 1, 30, 17, 10, 20, 699, DateTimeKind.Local).AddTicks(8015) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductVariants");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 16, 54, 32, 672, DateTimeKind.Local).AddTicks(5516), "$2a$11$T.zclEHZOh8J0Fz.tnRlAuLLlfgsAfTqW81Y0YHLiqQyot32F2sD2", new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7213) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 16, 54, 32, 860, DateTimeKind.Local).AddTicks(5479), "$2a$11$6mfP8f9CcxTSM13iRygNsuWNKBaSjYBtxk7kQTCzcWd7jPkwh9Bmi", new DateTime(2026, 1, 30, 16, 54, 32, 672, DateTimeKind.Local).AddTicks(5579) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 16, 54, 33, 32, DateTimeKind.Local).AddTicks(3122), "$2a$11$N6cmI7N0sqxkZz2m7W6gAe4Q8U3UvfPJKBhVzEXLh9YEyhjGY2tNW", new DateTime(2026, 1, 30, 16, 54, 32, 860, DateTimeKind.Local).AddTicks(5523) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9253), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9282), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9290), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 16, 54, 31, 781, DateTimeKind.Local).AddTicks(2282), "$2a$11$cExFD4nWk3nYwQqU796GlOMGNFIfwvtiAv1Dguu5hVKGNFi4gGZm.", new DateTime(2026, 1, 30, 16, 54, 31, 573, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 16, 54, 31, 953, DateTimeKind.Local).AddTicks(7226), "$2a$11$T7tU54xypM1jNu0mnrIjG.0OKbOGukixqL86oYPT557nETbYJpFru", new DateTime(2026, 1, 30, 16, 54, 31, 781, DateTimeKind.Local).AddTicks(2549) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 16, 54, 32, 144, DateTimeKind.Local).AddTicks(1020), "$2a$11$tVFuDPDyUo0L1ph1r7CYBOoIZ9Jqma/nkmMvz.b.bmNeAtc7mVDdG", new DateTime(2026, 1, 30, 16, 54, 31, 953, DateTimeKind.Local).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 54, 32, 318, DateTimeKind.Local).AddTicks(5115), "$2a$11$slYqM.6rYi1bbpgwpxcGH.TXRGGgZjCJ7dC.Fg.VyCptns0m.Ox8.", new DateTime(2026, 1, 30, 16, 54, 32, 144, DateTimeKind.Local).AddTicks(1067) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(3983), "$2a$11$gKBVE7J.ISytKGaZJaFO6us/zgKVlMsetZaWxmZsExpkxPI98ceTW", new DateTime(2026, 1, 30, 16, 54, 32, 318, DateTimeKind.Local).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6599), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6764), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6765) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7063), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7068) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7070), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7074), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7080), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7086), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7091), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6424), new DateTime(2025, 12, 31, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6434), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6426) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6471), new DateTime(2026, 1, 10, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6473), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6472) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6477), new DateTime(2026, 1, 15, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6481), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6483), new DateTime(2026, 1, 20, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6488), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6487) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6490), new DateTime(2026, 1, 25, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6492), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6494), new DateTime(2026, 1, 28, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6496), new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 573, DateTimeKind.Local).AddTicks(104), new DateTime(2026, 1, 30, 16, 54, 31, 573, DateTimeKind.Local).AddTicks(97) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 573, DateTimeKind.Local).AddTicks(116), new DateTime(2026, 1, 30, 16, 54, 31, 573, DateTimeKind.Local).AddTicks(112) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 573, DateTimeKind.Local).AddTicks(126), new DateTime(2026, 1, 30, 16, 54, 31, 573, DateTimeKind.Local).AddTicks(122) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9702), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9668) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9716), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9729), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9724) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9742), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9736) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9754), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9817), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9767) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9829), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9840), new DateTime(2026, 1, 30, 16, 54, 31, 572, DateTimeKind.Local).AddTicks(9836) });
        }
    }
}
