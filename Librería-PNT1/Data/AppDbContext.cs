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
                new Libro { IdLibro = "1", Titulo = "El Quijote", Autor = "Cervantes", Descripcion = "Clásico", Precio = 19999.99, Stock = 5, Disponible = true},
                new Libro { IdLibro = "2", Titulo = "Fundación", Autor = "Isaac Asimov", Descripcion = "Sci-Fi", Precio = 15999.00, Stock = 3, Disponible = true}
            );
        }
    }
}
