// Ruta sugerida: Models/CheckoutViewModel.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Libreria_PNT1.Controllers.CartController;

namespace Libreria_PNT1.Models
{
    public class CheckoutViewModel
    {
        // Datos del cliente
        [Required]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = string.Empty;

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; } = string.Empty;

        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; } = string.Empty;

        // Resumen del carrito
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal Subtotal { get; set; }
    }
}
