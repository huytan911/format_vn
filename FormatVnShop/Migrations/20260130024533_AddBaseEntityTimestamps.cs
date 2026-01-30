using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntityTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AdminUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 9, 45, 32, 331, DateTimeKind.Local).AddTicks(86), "$2a$11$TJl58ocVb0LAXOQb0uJVl.X5hTQbed5WYnr3MZbiRb1y2LQk8Ayau", new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7560) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 9, 45, 32, 509, DateTimeKind.Local).AddTicks(9241), "$2a$11$khqbbC5jHfr5.F3AwPYaXeMS2cMqwRES.uzBSKnArJpCFUztUzYiq", new DateTime(2026, 1, 30, 9, 45, 32, 331, DateTimeKind.Local).AddTicks(329) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 45, 32, 679, DateTimeKind.Local).AddTicks(5254), "$2a$11$qXZ6Yx2DM9bBgmA4jl9CNeRFWn0tHSDYwRqaRWsQqhAg4x6wKEuPe", new DateTime(2026, 1, 30, 9, 45, 32, 509, DateTimeKind.Local).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6342), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6383), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6385) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6389), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6391) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7083), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7101), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7112), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7107) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7121), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7131), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7397), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7406), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7413), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7419), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7425), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7431), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7434) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7437), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7459), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7223), new DateTime(2025, 12, 31, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7230), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7250), new DateTime(2026, 1, 10, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7257), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7262), new DateTime(2026, 1, 15, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7267), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7272), new DateTime(2026, 1, 20, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7278), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7283), new DateTime(2026, 1, 25, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7288), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7293), new DateTime(2026, 1, 28, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7299), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6759), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6771), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6781), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6776) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6790), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6786) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6804), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6856), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6816) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6865), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6875), new DateTime(2026, 1, 30, 9, 45, 32, 160, DateTimeKind.Local).AddTicks(6872) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AdminUsers");

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
        }
    }
}
