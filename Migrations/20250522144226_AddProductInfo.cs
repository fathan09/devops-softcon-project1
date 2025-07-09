using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IISMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddProductInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "manufactureDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productDescription",
                table: "Products",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "manufactureDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productDescription",
                table: "Products");
        }
    }
}
