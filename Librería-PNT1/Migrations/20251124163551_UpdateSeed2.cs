using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libreria_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 3,
                column: "Precio",
                value: 20000.00m);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 4,
                column: "Precio",
                value: 20000.00m);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 5,
                column: "Precio",
                value: 20000.00m);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 6,
                column: "Precio",
                value: 20000.00m);

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "CategoriaId", "Descripcion", "Disponible", "Imagen", "Precio", "Stock", "Titulo" },
                values: new object[,]
                {
                    { 7, "JK Rowling", 1, "Fantasia", true, null, 20000.00m, 7, "Harry Potter y la Orden del Fenix" },
                    { 8, "JK Rowling", 1, "Fantasia", true, null, 20000.00m, 7, "Harry Potter y el Misterio del Principe" },
                    { 9, "JK Rowling", 1, "Fantasia", true, null, 20000.00m, 7, "Harry Potter y las Reliquias de la Muerte" },
                    { 10, "Stephenie Meyer", 1, "Fantasia", true, null, 12999.00m, 10, "Crepusculo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 3,
                column: "Precio",
                value: 16999.00m);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 4,
                column: "Precio",
                value: 16999.00m);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 5,
                column: "Precio",
                value: 16999.00m);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 6,
                column: "Precio",
                value: 16999.00m);
        }
    }
}
