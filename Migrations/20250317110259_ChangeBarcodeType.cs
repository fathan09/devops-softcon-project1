using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IISMSBackend.Migrations
{
    /// <inheritdoc />
     public partial class ChangeBarcodeType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
     
        migrationBuilder.Sql(
            "ALTER TABLE \"Products\" ALTER COLUMN \"productBarcode\" TYPE bytea USING decode(\"productBarcode\", 'escape');"
        );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        
        migrationBuilder.Sql(
            "ALTER TABLE \"Products\" ALTER COLUMN \"productBarcode\" TYPE text USING encode(\"productBarcode\", 'escape');"
        );
    }
}
}
