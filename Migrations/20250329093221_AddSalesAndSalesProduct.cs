using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IISMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesAndSalesProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    salesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    totalCartPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    totalCartQuantity = table.Column<int>(type: "integer", nullable: false),
                    salesTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.salesId);
                });

            migrationBuilder.CreateTable(
                name: "SalesProduct",
                columns: table => new
                {
                    salesProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    salesId = table.Column<int>(type: "integer", nullable: false),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    salesQuantity = table.Column<int>(type: "integer", nullable: false),
                    unitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    totalUnitPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProduct", x => x.salesProductId);
                    table.ForeignKey(
                        name: "FK_SalesProduct_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesProduct_Sales_salesId",
                        column: x => x.salesId,
                        principalTable: "Sales",
                        principalColumn: "salesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesProduct_productId",
                table: "SalesProduct",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProduct_salesId",
                table: "SalesProduct",
                column: "salesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesProduct");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
