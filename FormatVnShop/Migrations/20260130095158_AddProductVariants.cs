using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FormatVnShop.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Material = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SKU = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
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
                values: new object[] { new DateTime(2025, 7, 30, 16, 51, 57, 807, DateTimeKind.Local).AddTicks(313), "$2a$11$7526BhDrpgSnH9exqCBrq.SzhdIzgS5Jj4fk74kXGyqi6tYGQ3MyG", new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(2061) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 16, 51, 57, 973, DateTimeKind.Local).AddTicks(9621), "$2a$11$N6FDaTjIYWRQc69x9StcGetSMC9mIK2evBcPaVpH21mJuz9fCznKO", new DateTime(2026, 1, 30, 16, 51, 57, 807, DateTimeKind.Local).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 16, 51, 58, 142, DateTimeKind.Local).AddTicks(959), "$2a$11$P10hi.FyENP17BWJddPCPO6MVWUnd.ci.wqNnk1AppuH6xqYklGCy", new DateTime(2026, 1, 30, 16, 51, 57, 973, DateTimeKind.Local).AddTicks(9655) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(8805), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(8830), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(8836), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 30, 16, 51, 56, 947, DateTimeKind.Local).AddTicks(5436), "$2a$11$GGaBVLC1t.4YHMk6NN9Ca.It2vXhduPiZoloIk9nq9XV7r/jKazf2", new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9371) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 30, 16, 51, 57, 126, DateTimeKind.Local).AddTicks(4898), "$2a$11$o3txVB4UPvklFMdM8MbpKO2ONAmkKjEd/Es4iRR3TfTsG9UTTP5ra", new DateTime(2026, 1, 30, 16, 51, 56, 947, DateTimeKind.Local).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 30, 16, 51, 57, 298, DateTimeKind.Local).AddTicks(3068), "$2a$11$9bguAa2i0RqTtXhw9/7v6eXbFWfKCrAzLUOJoFnBkaT6w52VIjehG", new DateTime(2026, 1, 30, 16, 51, 57, 126, DateTimeKind.Local).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 51, 57, 468, DateTimeKind.Local).AddTicks(6095), "$2a$11$FjdtATboz6DWTegw0s.x..1JKGBF8NgihEffEjTGj.Cga34TvnZmq", new DateTime(2026, 1, 30, 16, 51, 57, 298, DateTimeKind.Local).AddTicks(3119) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 30, 16, 51, 57, 635, DateTimeKind.Local).AddTicks(9656), "$2a$11$c5LeAZE52EDQMKA2c8q5ouYvlwf/NpH7fE08Y.T6zZtH7g8FqFw6y", new DateTime(2026, 1, 30, 16, 51, 57, 468, DateTimeKind.Local).AddTicks(6186) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1769), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1775), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1957), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1959), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1963), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1964) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1968), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1969) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1970), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1971) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1973), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1973) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1617), new DateTime(2025, 12, 31, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1623), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1650), new DateTime(2026, 1, 10, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1652), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1654), new DateTime(2026, 1, 15, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1656), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1658), new DateTime(2026, 1, 20, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1660), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1662), new DateTime(2026, 1, 25, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1667), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1666) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1670), new DateTime(2026, 1, 28, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1671), new DateTime(2026, 1, 30, 16, 51, 57, 636, DateTimeKind.Local).AddTicks(1670) });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Color", "CreatedAt", "Material", "Price", "ProductId", "SKU", "Size", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Cam", new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9302), "Dạ", null, 1, "AMT-CAM-S", "S", 5, new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9298) },
                    { 2, "Cam", new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9310), "Dạ", null, 1, "AMT-CAM-M", "M", 5, new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9307) },
                    { 3, "Cam", new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9317), "Dạ", null, 1, "AMT-CAM-L", "L", 5, new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9314) }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9062), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9070), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9067) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9079), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9075) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9088), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9083) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9096), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9141), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9106) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9149), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9146) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9156), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9153) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

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
        }
    }
}
