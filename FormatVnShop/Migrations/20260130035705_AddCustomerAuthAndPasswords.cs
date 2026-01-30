using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerAuthAndPasswords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Customers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 10, 57, 3, 947, DateTimeKind.Local).AddTicks(5705), "$2a$11$mUCBGunH9.sVJM.h7y1cYeZEfIpzWgxskla/FfgzEczm.nQZ.VV8O", new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3397) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 10, 57, 4, 125, DateTimeKind.Local).AddTicks(1873), "$2a$11$v04RUdep3blqRTR08Yk4P.uDOEbFwsoRQXitDCfH.C8Pmftj.uixK", new DateTime(2026, 1, 30, 10, 57, 3, 947, DateTimeKind.Local).AddTicks(5747) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 10, 57, 4, 302, DateTimeKind.Local).AddTicks(3599), "$2a$11$kDwubXcjJh6RDmvzISvvq.BmCceogwVeeJ3iOvp4XOD4e7AQVtBWe", new DateTime(2026, 1, 30, 10, 57, 4, 125, DateTimeKind.Local).AddTicks(1917) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(5897), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(5917) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(5925), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(5931), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 10, 57, 3, 81, DateTimeKind.Local).AddTicks(9915), "$2a$11$.thRG2RH1w84x3cWbE6da../w2redeNbo6bVdfu3OpBXskF0xAhla", new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6391) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 10, 57, 3, 262, DateTimeKind.Local).AddTicks(7330), "$2a$11$U45UdTmZbOlzf/M.cd2nYugYNrivs4yyQCMzgcWI1VUyykpQonyjG", new DateTime(2026, 1, 30, 10, 57, 3, 82, DateTimeKind.Local).AddTicks(114) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 10, 57, 3, 438, DateTimeKind.Local).AddTicks(1691), "$2a$11$J0O8T3NM1MMDRG5C7CloAekVrKAzwiH3FMVTMqqUQPXSy.T0Mavti", new DateTime(2026, 1, 30, 10, 57, 3, 262, DateTimeKind.Local).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 10, 57, 3, 604, DateTimeKind.Local).AddTicks(8580), "$2a$11$Vt/WsirFItPn5RBOS9Y.SuYO1LW.ZD/ourbVqcYUzWFM39hl4JGOW", new DateTime(2026, 1, 30, 10, 57, 3, 438, DateTimeKind.Local).AddTicks(1748) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(1650), "$2a$11$VNU1URZOkWJqpkzvKR8BPuHDhmpb2j4B1DAwFeQyuekYwVHYg1ur6", new DateTime(2026, 1, 30, 10, 57, 3, 604, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3277), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3284), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3295), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3298), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3298) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3300), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3303), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3306), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3306) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3308), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2808), new DateTime(2025, 12, 31, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2815), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2813) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2836), new DateTime(2026, 1, 10, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2837), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2836) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2842), new DateTime(2026, 1, 15, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2845), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2844) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2846), new DateTime(2026, 1, 20, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2849), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2848) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2851), new DateTime(2026, 1, 25, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2852), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2851) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2854), new DateTime(2026, 1, 28, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2859), new DateTime(2026, 1, 30, 10, 57, 3, 774, DateTimeKind.Local).AddTicks(2858) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6154), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6163), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6171), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6168) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6179), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6176) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6186), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6230), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6238), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6235) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6246), new DateTime(2026, 1, 30, 10, 57, 2, 916, DateTimeKind.Local).AddTicks(6243) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
