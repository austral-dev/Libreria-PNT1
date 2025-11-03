using System;
using System.Collections.Generic;

namespace Libreria_PNT1.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public List<CartItem> Items { get; set; }
        public decimal Total { get; set; }
    }
}
