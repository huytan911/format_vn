using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Migrations
{
    /// <inheritdoc />
    public partial class AddCartAndWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 11, 33, 12, 196, DateTimeKind.Local).AddTicks(4422), "$2a$11$QYt93BhY8B71qj6pv7QIy.vLqmbunRXxnpxZO5m8KZ1vVx7OOa9.K", new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 11, 33, 12, 396, DateTimeKind.Local).AddTicks(6667), "$2a$11$iHYA04wFO3UsyTPJj2ojS.PbF23uZfJkAq3wfJcIjpD0HWi0/M1ze", new DateTime(2026, 1, 30, 11, 33, 12, 196, DateTimeKind.Local).AddTicks(4462) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 11, 33, 12, 578, DateTimeKind.Local).AddTicks(1144), "$2a$11$/R1DMSm1ozsWXn2p1feB/.Tl2c.Z1CCMIv9qDWITdfx4Hm8blRDM6", new DateTime(2026, 1, 30, 11, 33, 12, 396, DateTimeKind.Local).AddTicks(6703) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4360), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4377) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4384), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4390), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4392) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 11, 33, 11, 310, DateTimeKind.Local).AddTicks(8960), "$2a$11$8TuTli4OHcvEqanychjU8.3D9cxm6fUrc0aAS7JkwUuBHXf2oLSL2", new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4849) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 11, 33, 11, 490, DateTimeKind.Local).AddTicks(9426), "$2a$11$PHT.DTYTATz22sp4jQDASOnU0lrLhKm2WaNzWfOWZenJdMhZRLOPW", new DateTime(2026, 1, 30, 11, 33, 11, 310, DateTimeKind.Local).AddTicks(9217) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 11, 33, 11, 662, DateTimeKind.Local).AddTicks(8879), "$2a$11$BQbOjeVJFgyQbk6mDfBthux54FFB2rbFeT.S4N1aBhL7NFEooTppC", new DateTime(2026, 1, 30, 11, 33, 11, 490, DateTimeKind.Local).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 11, 33, 11, 838, DateTimeKind.Local).AddTicks(1257), "$2a$11$Lag9wlsYd80.6T2w/0OgF.JnHn0Op.WXY8hqqotQi7vJG5V4vdyoe", new DateTime(2026, 1, 30, 11, 33, 11, 662, DateTimeKind.Local).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 11, 33, 12, 22, DateTimeKind.Local).AddTicks(9387), "$2a$11$1hsAWEafPFA1od9gx36CDOqdwKQW7pjjIsCGQS/VFfl38KPC.tiRi", new DateTime(2026, 1, 30, 11, 33, 11, 838, DateTimeKind.Local).AddTicks(1324) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(570), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(574), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(575) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(698), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(699) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(701), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(702) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(703), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(706), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(708), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(709) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(710), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(460), new DateTime(2025, 12, 31, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(465), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(462) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(482), new DateTime(2026, 1, 10, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(484), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(483) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(487), new DateTime(2026, 1, 15, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(489), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(491), new DateTime(2026, 1, 20, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(494), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(493) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(498), new DateTime(2026, 1, 25, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(500), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(501), new DateTime(2026, 1, 28, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(503), new DateTime(2026, 1, 30, 11, 33, 12, 23, DateTimeKind.Local).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4612), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4621), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4618) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4629), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4639), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4649), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4699), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4659) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4707), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4704) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4715), new DateTime(2026, 1, 30, 11, 33, 11, 140, DateTimeKind.Local).AddTicks(4712) });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CustomerId",
                table: "CartItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_CustomerId",
                table: "WishlistItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_ProductId",
                table: "WishlistItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "WishlistItems");

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
        }
    }
}
