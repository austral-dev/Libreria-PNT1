using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class AddCampoImagenLibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 1,
                column: "Imagen",
                value: null);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 2,
                column: "Imagen",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Libros");
        }
    }
}
