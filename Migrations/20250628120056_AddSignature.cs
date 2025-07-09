using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IISMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddSignature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "customerSignature",
                table: "Orders",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customerSignature",
                table: "Orders");
        }
    }
}
