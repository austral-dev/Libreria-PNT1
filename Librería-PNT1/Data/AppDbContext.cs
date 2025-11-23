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
                new LibroEntity { IdLibro = 1, Titulo = "El Quijote", Autor = "Cervantes", Descripcion = "Clásico", Precio = 19999.99m, Stock = 5, Disponible = true, CategoriaId = 1 },
                new LibroEntity { IdLibro = 2, Titulo = "Fundación", Autor = "Isaac Asimov", Descripcion = "Sci-Fi", Precio = 15999.00m, Stock = 3, Disponible = true, CategoriaId = 1 }
            );
        }
    }
}
