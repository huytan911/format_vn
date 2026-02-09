using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderPaymentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "VnpayTransactionId",
                table: "Orders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
                columns: new[] { "CreatedAt", "OrderDate", "PaymentMethod", "PaymentStatus", "UpdatedAt", "VnpayTransactionId" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(419), new DateTime(2026, 1, 10, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(427), "COD", "Pending", new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(425), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "PaymentMethod", "PaymentStatus", "UpdatedAt", "VnpayTransactionId" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(442), new DateTime(2026, 1, 20, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(444), "COD", "Pending", new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(443), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "PaymentMethod", "PaymentStatus", "UpdatedAt", "VnpayTransactionId" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(447), new DateTime(2026, 1, 25, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(449), "COD", "Pending", new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(448), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "PaymentMethod", "PaymentStatus", "UpdatedAt", "VnpayTransactionId" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(450), new DateTime(2026, 1, 30, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(453), "COD", "Pending", new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(451), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "PaymentMethod", "PaymentStatus", "UpdatedAt", "VnpayTransactionId" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(454), new DateTime(2026, 2, 4, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(457), "COD", "Pending", new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(455), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "PaymentMethod", "PaymentStatus", "UpdatedAt", "VnpayTransactionId" },
                values: new object[] { new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(458), new DateTime(2026, 2, 7, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(460), "COD", "Pending", new DateTime(2026, 2, 9, 11, 28, 54, 286, DateTimeKind.Local).AddTicks(459), null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VnpayTransactionId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 9, 10, 53, 27, 237, DateTimeKind.Local).AddTicks(4613), "$2a$11$AUTnEJASDT22KhNq8nXPS.cPGvycq1x3VMDGhLeUfyh7i6ZX44YRq", new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5457) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 53, 27, 409, DateTimeKind.Local).AddTicks(5372), "$2a$11$S30yIFxby2FwxDcuLQTbBuy82l38tiICXQDMjxWm8qf/xg/bXQoiW", new DateTime(2026, 2, 9, 10, 53, 27, 237, DateTimeKind.Local).AddTicks(4654) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 10, 53, 27, 587, DateTimeKind.Local).AddTicks(2127), "$2a$11$POZnGl5REbG3Z2CMcMZYSOLTDeOvOFcUFqAEw5A24X6gMwMliM17K", new DateTime(2026, 2, 9, 10, 53, 27, 409, DateTimeKind.Local).AddTicks(5414) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7590), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7606) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7612), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7615) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7618), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 9, 10, 53, 26, 261, DateTimeKind.Local).AddTicks(1765), "$2a$11$vqNsj5AYlYiRXPrws9FqLuI9yQeEQtbqpe9AfJWoG5bTo8AcKd67C", new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 10, 53, 26, 436, DateTimeKind.Local).AddTicks(6742), "$2a$11$p6syve8zoKqXdSCx.3Ijk.c7ToYI9mJw3YoEEkn7Uj9d9eauOCZA2", new DateTime(2026, 2, 9, 10, 53, 26, 261, DateTimeKind.Local).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 9, 10, 53, 26, 639, DateTimeKind.Local).AddTicks(6137), "$2a$11$QNxMNzcf9ftpXOU4i3q8.ugwDcAc8ZS99bo1J/2zlbVbhKZBVb1l.", new DateTime(2026, 2, 9, 10, 53, 26, 436, DateTimeKind.Local).AddTicks(6788) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 9, 10, 53, 26, 885, DateTimeKind.Local).AddTicks(4455), "$2a$11$zi/ENFkTBCT42TfClbpqDeqdCiGKh0sO1TbD8zEtUlOIuKH1gTjlC", new DateTime(2026, 2, 9, 10, 53, 26, 639, DateTimeKind.Local).AddTicks(6204) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(3626), "$2a$11$XZX2cyqt/fKF8tCxluZqjef4wchdAH0jrurSiWe8KSD5ZqwxRV3W2", new DateTime(2026, 2, 9, 10, 53, 26, 885, DateTimeKind.Local).AddTicks(4515) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5111), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5119), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5120) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5308), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5314), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5315) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5317), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5318) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5321), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5322) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5325), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5329), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4931), new DateTime(2026, 1, 10, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4938), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4956), new DateTime(2026, 1, 20, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4958), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4957) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4964), new DateTime(2026, 1, 25, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4967), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4965) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4971), new DateTime(2026, 1, 30, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4974), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4978), new DateTime(2026, 2, 4, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4981), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4985), new DateTime(2026, 2, 7, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4988), new DateTime(2026, 2, 9, 10, 53, 27, 66, DateTimeKind.Local).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(8129), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(8138), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(8134) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(8146), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(8143) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7888), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7861) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7898), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7894) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7906), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7914), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7911) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7922), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7970), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7978), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7975) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7986), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7983) });
        }
    }
}
