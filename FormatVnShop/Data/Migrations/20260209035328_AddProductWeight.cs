using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7888), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7861), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7898), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7894), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7906), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7903), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7914), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7911), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7922), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7919), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7970), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7932), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7978), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7975), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt", "Weight" },
                values: new object[] { new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7986), new DateTime(2026, 2, 9, 10, 53, 26, 66, DateTimeKind.Local).AddTicks(7983), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "longtext",
                nullable: true)
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
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(932), "/images/categories/nu.jpg", new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(956), "/images/categories/nam.jpg", new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(963), "/images/categories/phukien.jpg", new DateTime(2026, 2, 2, 15, 48, 2, 229, DateTimeKind.Local).AddTicks(965) });

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
        }
    }
}
