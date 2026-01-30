using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 30, 9, 32, 34, 348, DateTimeKind.Local).AddTicks(9521), "$2a$11$hLVyLBh74WWxxAoazuVJveiBYsUw906sD2tO.ayu5nyyb64Bndj8i" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 30, 9, 32, 34, 517, DateTimeKind.Local).AddTicks(5032), "$2a$11$G1A6FwiRhIjwTh4GIWAT1eHNHB0tuGWasnVr3zL1DiiKNUUzZu6CS" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 32, 34, 685, DateTimeKind.Local).AddTicks(5475), "$2a$11$L3dxYyMWqHwIlfRwPF5W.OwBOps0LchVwjNKLfobchsP2XSZ2k4Fq" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 12, 31, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2026, 1, 10, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2026, 1, 15, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2026, 1, 20, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2026, 1, 25, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2026, 1, 28, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 30, 9, 32, 34, 182, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 29, 16, 25, 5, 812, DateTimeKind.Local).AddTicks(8607), "$2a$11$x261l.G2CrhEqUNXgztG/OdKBpCM/Msm5Uq.vz06WdWlAshKPXyqK" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 29, 16, 25, 6, 50, DateTimeKind.Local).AddTicks(2292), "$2a$11$lGctgYwMnGI7ZOypi2JM2OhnTXg8fU2TKMKAHpEQ8zWfX2/RrVNAm" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 29, 16, 25, 6, 265, DateTimeKind.Local).AddTicks(7486), "$2a$11$YUl45ZaoaVOj7zjFlXMAxuT0mWnFhEzYAHAwwAU40dbJyJEIAOz2S" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 12, 30, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2026, 1, 9, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2026, 1, 14, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2026, 1, 19, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2026, 1, 24, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2026, 1, 27, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 16, 25, 5, 593, DateTimeKind.Local).AddTicks(8075));
        }
    }
}
