using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libreria_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class Add_Categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Libros");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ficción" },
                    { 2, "No Ficción" }
                });

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 1,
                column: "CategoriaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 2,
                column: "CategoriaId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriaId",
                table: "Libros",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Libros_CategoriaId",
                table: "Libros");

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 1,
                columns: new[] { "Categoria", "CategoriaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "IdLibro",
                keyValue: 2,
                columns: new[] { "Categoria", "CategoriaId" },
                values: new object[] { null, null });
        }
    }
}
