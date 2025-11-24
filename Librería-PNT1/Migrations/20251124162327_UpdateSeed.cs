using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libreria_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "CategoriaId", "Descripcion", "Disponible", "Imagen", "Precio", "Stock", "Titulo" },
                values: new object[,]
                {
                    { 3, "JK Rowling", 1, "Fantasia", true, null, 16999.00m, 7, "Harry Potter y la Piedra Filosofal" },
                    { 4, "JK Rowling", 1, "Fantasia", true, null, 16999.00m, 7, "Harry Potter y la Camara Secreta" },
                    { 5, "JK Rowling", 1, "Fantasia", true, null, 16999.00m, 7, "Harry Potter y el Prisionero de Azkaban" },
                    { 6, "JK Rowling", 1, "Fantasia", true, null, 16999.00m, 7, "Harry Potter y el Caliz de Fuego" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 6);
        }
    }
}
