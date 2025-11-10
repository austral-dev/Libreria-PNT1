using Microsoft.EntityFrameworkCore;
using Libreria_PNT1.Models;

namespace Libreria_PNT1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LibroEntity> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed de prueba
            modelBuilder.Entity<LibroEntity>().HasData(
                new LibroEntity { IdLibro = 1, Titulo = "El Quijote", Autor = "Cervantes", Descripcion = "Clásico", Precio = 19999.99m, Stock = 5, Disponible = true },
                new LibroEntity { IdLibro = 2, Titulo = "Fundación", Autor = "Isaac Asimov", Descripcion = "Sci-Fi", Precio = 15999.00m, Stock = 3, Disponible = true }
            );
        }
    }
}
