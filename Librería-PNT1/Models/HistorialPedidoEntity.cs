using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_PNT1.Models
{
    [Table("HistorialPedidos")]
    public class HistorialPedidoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        // FK a Cliente
        [Required]
        public int IdCliente { get; set; }
        public ClienteEntity Cliente { get; set; } = null!;

        // Relación 1-N con Items
        public ICollection<ItemPedidoEntity> Items { get; set; } = new List<ItemPedidoEntity>();
    }
}
