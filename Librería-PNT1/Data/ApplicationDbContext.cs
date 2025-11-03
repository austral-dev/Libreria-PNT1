using Libreria_PNT1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Libreria_PNT1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tablas
        public DbSet<Libro> Libros { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
