using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 2,
                column: "Titulo",
                value: "Fundacion");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 10,
                column: "Precio",
                value: 39999.00m);

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "CategoriaId", "Descripcion", "Disponible", "Imagen", "Precio", "Stock", "Titulo" },
                values: new object[] { 11, "George Orwell", 1, "Sci-Fi", true, null, 9999.00m, 20, "1984" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 2,
                column: "Titulo",
                value: "Fundación");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 10,
                column: "Precio",
                value: 12999.00m);
        }
    }
}
