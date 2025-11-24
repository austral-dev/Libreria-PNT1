using Microsoft.EntityFrameworkCore;
using Libreria_PNT1.Models;

namespace Libreria_PNT1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LibroEntity> Libros { get; set; }

        public DbSet<ClienteEntity> Clientes { get; set; }

        public DbSet<HistorialPedidoEntity> HistorialPedidos { get; set; }
        public DbSet<ItemPedidoEntity> ItemsPedido { get; set; }

        public DbSet<CategoriaEntity> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // si querés ser explícito con las relaciones:
            modelBuilder.Entity<HistorialPedidoEntity>()
                .HasOne(p => p.Cliente)
                .WithMany()                     // un cliente puede tener muchos pedidos (si querés después podés agregar ICollection en ClienteEntity)
                .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<ItemPedidoEntity>()
                .HasOne(i => i.Pedido)
                .WithMany(p => p.Items)
                .HasForeignKey(i => i.IdPedido);

            modelBuilder.Entity<ItemPedidoEntity>()
                .HasOne(i => i.Libro)
                .WithMany()                     // un libro puede aparecer en muchos items
                .HasForeignKey(i => i.IdLibro);


            modelBuilder.Entity<CategoriaEntity>().HasData(
            new CategoriaEntity { IdCategoria = 1, Nombre = "Ficción" },
            new CategoriaEntity { IdCategoria = 2, Nombre = "No Ficción" }
);

            // Seed de prueba
            modelBuilder.Entity<LibroEntity>().HasData(
                    new LibroEntity { IdLibro = 1, Titulo = "El Quijote", Autor = "Cervantes", Descripcion = "Clásico de la literatura.", Precio = 19999.99m, Stock = 5, Disponible = true, CategoriaId = 1, Imagen = "EL QUIJOTE.jpg" },
                    new LibroEntity { IdLibro = 2, Titulo = "Fundación", Autor = "Isaac Asimov", Descripcion = "Obra maestra de Sci-Fi.", Precio = 15999.00m, Stock = 3, Disponible = true, CategoriaId = 1, Imagen = "FUNDACION.jpg" },
                    new LibroEntity { IdLibro = 3, Titulo = "Harry Potter y la Piedra Filosofal", Autor = "JK Rowling", Descripcion = "El inicio de la saga.", Precio = 20000.00m, Stock = 7, Disponible = true, CategoriaId = 1, Imagen = "HARRY POTTER 1.jpg" },
                    new LibroEntity { IdLibro = 4, Titulo = "Harry Potter y la Cámara Secreta", Autor = "JK Rowling", Descripcion = "Segundo año en Hogwarts.", Precio = 20000.00m, Stock = 7, Disponible = true, CategoriaId = 1, Imagen = "HARRY POTTER 2.jpg" },
                    new LibroEntity { IdLibro = 5, Titulo = "Harry Potter y el Prisionero de Azkaban", Autor = "JK Rowling", Descripcion = "Tercer año en Hogwarts.", Precio = 20000.00m, Stock = 7, Disponible = true, CategoriaId = 1, Imagen = "HARRY POTTER 3.jpg" },
                    new LibroEntity { IdLibro = 6, Titulo = "Harry Potter y el Caliz de Fuego", Autor = "JK Rowling", Descripcion = "El torneo de los tres magos.", Precio = 20000.00m, Stock = 7, Disponible = true, CategoriaId = 1, Imagen = "HARRY POTTER 4.jpg" },
                    new LibroEntity { IdLibro = 7, Titulo = "Harry Potter y la Orden del Fenix", Autor = "JK Rowling", Descripcion = "La rebelión comienza.", Precio = 20000.00m, Stock = 7, Disponible = true, CategoriaId = 1, Imagen = "HARRY POTTER 5.jpg" },
                    new LibroEntity { IdLibro = 8, Titulo = "Harry Potter y el Misterio del Principe", Autor = "JK Rowling", Descripcion = "Secretos oscuros revelados.", Precio = 20000.00m, Stock = 7, Disponible = true, CategoriaId = 1, Imagen = "HARRY POTTER 6.jpg" },
                    new LibroEntity { IdLibro = 9, Titulo = "Harry Potter y las Reliquias de la Muerte", Autor = "JK Rowling", Descripcion = "El final épico.", Precio = 20000.00m, Stock = 7, Disponible = true, CategoriaId = 1, Imagen = "HARRY POTTER 7.jpg" },
                    new LibroEntity { IdLibro = 10, Titulo = "Crepusculo", Autor = "Stephenie Meyer", Descripcion = "Romance y vampiros.", Precio = 39999.00m, Stock = 10, Disponible = true, CategoriaId = 1, Imagen = "CREPUSCULO.jpg" },
                    new LibroEntity { IdLibro = 13, Titulo = "1984", Autor = "George Orwell", Descripcion = "Ciencia Ficción distópica.", Precio = 20000.00m, Stock = 15, Disponible = true, CategoriaId = 1, Imagen = "1984.jpg" }
                );
        }
    }
}
