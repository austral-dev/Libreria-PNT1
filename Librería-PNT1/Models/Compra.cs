using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLibros.Models
{
    public class Compra
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }

        public ICollection<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
    }

    public class DetalleCompra
    {
        public int Id { get; set; }

        public int CompraId { get; set; }
        public Compra? Compra { get; set; }

        public int LibroId { get; set; }
        public Libro? Libro { get; set; }

        [Range(1, 9999)]
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 999999)]
        public decimal PrecioUnitario { get; set; }

        [NotMapped]
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
