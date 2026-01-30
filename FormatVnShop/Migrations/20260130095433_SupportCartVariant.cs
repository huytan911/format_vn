using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormatVnShop.Migrations
{
    /// <inheritdoc />
    public partial class SupportCartVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductVariantId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductVariantId",
                table: "CartItems",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6599), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6764), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(6765) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7063), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7068) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7070), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7074), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7080), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7086), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ProductVariantId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7091), null, new DateTime(2026, 1, 30, 16, 54, 32, 495, DateTimeKind.Local).AddTicks(7093) });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductVariantId",
                table: "CartItems",
                column: "ProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ProductVariants_ProductVariantId",
                table: "CartItems",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductVariants_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ProductVariants_ProductVariantId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductVariants_ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductVariantId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductVariantId",
                table: "CartItems");

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

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9302), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9310), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9307) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9317), new DateTime(2026, 1, 30, 16, 51, 56, 775, DateTimeKind.Local).AddTicks(9314) });

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
        }
    }
}
