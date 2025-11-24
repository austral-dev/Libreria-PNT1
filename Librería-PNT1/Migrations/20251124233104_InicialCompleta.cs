using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libreria_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class InicialCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria");
                });

            migrationBuilder.CreateTable(
                name: "HistorialPedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialPedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_HistorialPedidos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsPedido",
                columns: table => new
                {
                    IdItemPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdLibro = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsPedido", x => x.IdItemPedido);
                    table.ForeignKey(
                        name: "FK_ItemsPedido_HistorialPedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "HistorialPedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsPedido_Libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ficción" },
                    { 2, "No Ficción" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "CategoriaId", "Descripcion", "Disponible", "Imagen", "Precio", "Stock", "Titulo" },
                values: new object[,]
                {
                    { 1, "Cervantes", 1, "Clásico de la literatura.", true, "EL QUIJOTE.jpg", 19999.99m, 5, "El Quijote" },
                    { 2, "Isaac Asimov", 1, "Obra maestra de Sci-Fi.", true, "FUNDACION.jpg", 15999.00m, 3, "Fundación" },
                    { 3, "JK Rowling", 1, "El inicio de la saga.", true, "HARRY POTTER 1.jpg", 20000.00m, 7, "Harry Potter y la Piedra Filosofal" },
                    { 4, "JK Rowling", 1, "Segundo año en Hogwarts.", true, "HARRY POTTER 2.jpg", 20000.00m, 7, "Harry Potter y la Cámara Secreta" },
                    { 5, "JK Rowling", 1, "Tercer año en Hogwarts.", true, "HARRY POTTER 3.jpg", 20000.00m, 7, "Harry Potter y el Prisionero de Azkaban" },
                    { 6, "JK Rowling", 1, "El torneo de los tres magos.", true, "HARRY POTTER 4.jpg", 20000.00m, 7, "Harry Potter y el Caliz de Fuego" },
                    { 7, "JK Rowling", 1, "La rebelión comienza.", true, "HARRY POTTER 5.jpg", 20000.00m, 7, "Harry Potter y la Orden del Fenix" },
                    { 8, "JK Rowling", 1, "Secretos oscuros revelados.", true, "HARRY POTTER 6.jpg", 20000.00m, 7, "Harry Potter y el Misterio del Principe" },
                    { 9, "JK Rowling", 1, "El final épico.", true, "HARRY POTTER 7.jpg", 20000.00m, 7, "Harry Potter y las Reliquias de la Muerte" },
                    { 10, "Stephenie Meyer", 1, "Romance y vampiros.", true, "CREPUSCULO.jpg", 39999.00m, 10, "Crepusculo" },
                    { 13, "George Orwell", 1, "Ciencia Ficción distópica.", true, "1984.jpg", 20000.00m, 15, "1984" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialPedidos_IdCliente",
                table: "HistorialPedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPedido_IdLibro",
                table: "ItemsPedido",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPedido_IdPedido",
                table: "ItemsPedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriaId",
                table: "Libros",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsPedido");

            migrationBuilder.DropTable(
                name: "HistorialPedidos");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
