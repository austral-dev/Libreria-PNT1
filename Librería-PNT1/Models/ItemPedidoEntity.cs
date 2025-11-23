using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_PNT1.Models
{
    [Table("ItemsPedido")]
    public class ItemPedidoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdItemPedido { get; set; }

        // FK al Pedido
        [Required]
        public int IdPedido { get; set; }
        public HistorialPedidoEntity Pedido { get; set; } = null!;

        // FK al Libro
        [Required]
        public int IdLibro { get; set; }
        public LibroEntity Libro { get; set; } = null!;

        [Range(1, 1000)]
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        // Propiedad calculada (no se mapea a la tabla)
        [NotMapped]
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
