using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsletterSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductVariants",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItems",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "Customers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 9, 15, 33, 35, 728, DateTimeKind.Local).AddTicks(9664), "$2a$11$2itJ2IeHy8CTgn.Grk/DUOdT2dxLZC8Q0aQUNmXT8uulXwq8AfbGW", new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8568) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 15, 33, 35, 892, DateTimeKind.Local).AddTicks(5256), "$2a$11$9EJGV5Y0WsNyfWk/Yg7VRexfI9ssMFahh8qCmeztK/77m0CTOrlYK", new DateTime(2026, 2, 9, 15, 33, 35, 728, DateTimeKind.Local).AddTicks(9693) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 15, 33, 36, 55, DateTimeKind.Local).AddTicks(3290), "$2a$11$1rh4bM9nWDVZTi3HN0DxAeEojAnXeU/OQi5tLKV1tKU5ffJJjWEkq", new DateTime(2026, 2, 9, 15, 33, 35, 892, DateTimeKind.Local).AddTicks(5290) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7026), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7044) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7054), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7056) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7060), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7062) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsSubscribed", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 9, 15, 33, 34, 894, DateTimeKind.Local).AddTicks(1118), false, "$2a$11$2n4cuUbTq2aK.1w609XCIO.01makWytzOEeM4t7Zlvb/FK.XHaBTS", new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7601) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsSubscribed", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 15, 33, 35, 59, DateTimeKind.Local).AddTicks(5628), false, "$2a$11$jRAsOZiPUMACuwcFh0nEKuy1JWDyCUjnTxsyWjyI1U/aonwx15NFu", new DateTime(2026, 2, 9, 15, 33, 34, 894, DateTimeKind.Local).AddTicks(1241) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsSubscribed", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 15, 33, 35, 236, DateTimeKind.Local).AddTicks(3953), false, "$2a$11$Yb09brVGMap6v.gc0rh7DeUq7v7KdMEMBKsFsCEQlKMpu/CvsSE1u", new DateTime(2026, 2, 9, 15, 33, 35, 59, DateTimeKind.Local).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsSubscribed", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 9, 15, 33, 35, 403, DateTimeKind.Local).AddTicks(4813), false, "$2a$11$OEmLX2H2Yelp3xsZzYB.vez3TmwbqIEhZB/a5tMppnDHlEksDUf6y", new DateTime(2026, 2, 9, 15, 33, 35, 236, DateTimeKind.Local).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsSubscribed", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(7002), false, "$2a$11$kRsg3G0pVH3GgYc0xhRYeOQVgLsJWV1yKfDHX3Lsy0se3HKHjp3Bi", new DateTime(2026, 2, 9, 15, 33, 35, 403, DateTimeKind.Local).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8341), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8348), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8465), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8466) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8468), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8468) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8470), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8472), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8473) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8474), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8475) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8476), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8477) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8128), new DateTime(2026, 1, 10, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8134), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8131) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8149), new DateTime(2026, 1, 20, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8151), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8154), new DateTime(2026, 1, 25, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8157), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8156) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8159), new DateTime(2026, 1, 30, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8161), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8160) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8163), new DateTime(2026, 2, 4, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8165), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8168), new DateTime(2026, 2, 7, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8169), new DateTime(2026, 2, 9, 15, 33, 35, 566, DateTimeKind.Local).AddTicks(8168) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7531), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7540), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7547), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7544) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7290), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7313), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7321), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7318) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7328), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7326) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7336), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7333) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7377), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7384), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7392), new DateTime(2026, 2, 9, 15, 33, 34, 724, DateTimeKind.Local).AddTicks(7389) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "Customers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductVariants",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItems",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 9, 11, 28, 54, 454, DateTimeKind.Local).AddTicks(8708), "$2a$11$evZsQ8JUqErA1bKufTcK4eS1NZ9x1lEKcXMh6ebDC2.FIDhrF/smy", new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 11, 28, 54, 630, DateTimeKind.Local).AddTicks(667), "$2a$11$bWZowgQsBQdItKFqMmpTfOCFoRAeWhSiR0wir0mzoymSG8d.fQHl.", new DateTime(2026, 2, 9, 11, 28, 54, 454, DateTimeKind.Local).AddTicks(8747) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 11, 28, 54, 800, DateTimeKind.Local).AddTicks(1548), "$2a$11$IBojtDR5RexXzo1WJ6fpy.RRgb3XC1sOuv4TQPLemxmjIeFACT8Ty", new DateTime(2026, 2, 9, 11, 28, 54, 630, DateTimeKind.Local).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(982), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1008), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1014), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1016) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 9, 11, 28, 53, 599, DateTimeKind.Local).AddTicks(7183), "$2a$11$fOwvkWb4slLY3FDWL9VSeueSHmCMOBKxaEUE8WYQ0YtoSp3Y0mo/i", new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 11, 28, 53, 771, DateTimeKind.Local).AddTicks(2098), "$2a$11$msVH9fq8pA9wsbmwdv3OCOl3I9PNmtzITOxnkH1vA5Tjoh5oVKcr6", new DateTime(2026, 2, 9, 11, 28, 53, 599, DateTimeKind.Local).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 11, 28, 53, 943, DateTimeKind.Local).AddTicks(8299), "$2a$11$VroU.Ozhk1FVL//rbw/UWO91UDH4gwE0U2askJWHwiDIiYQaeBeYi", new DateTime(2026, 2, 9, 11, 28, 53, 771, DateTimeKind.Local).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 9, 11, 28, 54, 116, DateTimeKind.Local).AddTicks(6652), "$2a$11$9Gp.z79vp8c8FU0ryzqdAuzolSi9BUXtD5vAImxnBSlurni1E360W", new DateTime(2026, 2, 9, 11, 28, 53, 943, DateTimeKind.Local).AddTicks(8351) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 11, 28, 54, 285, DateTimeKind.Local).AddTicks(9280), "$2a$11$jt6JQkkyRZREby/0Q7oMgeIrKWPxsguZIsMhnzFF9WR8g0/zGCnzC", new DateTime(2026, 2, 9, 11, 28, 54, 116, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(639), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(640) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(645), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(760), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(763), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(765), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(769), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(772), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(775), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(419), new DateTime(2026, 1, 10, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(427), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(425) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(442), new DateTime(2026, 1, 20, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(444), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(443) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(447), new DateTime(2026, 1, 25, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(449), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(450), new DateTime(2026, 1, 30, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(453), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(451) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(454), new DateTime(2026, 2, 4, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(457), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(455) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(458), new DateTime(2026, 2, 7, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(460), new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(459) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1538), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1532) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1547), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1543) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1555), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1552) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1268), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1241) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1291), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1288) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1301), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1296) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1309), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1306) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1318), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1380), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1390), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1386) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1398), new DateTime(2026, 2, 9, 11, 28, 53, 428, DateTimeKind.Local).AddTicks(1395) });
        }
    }
}
