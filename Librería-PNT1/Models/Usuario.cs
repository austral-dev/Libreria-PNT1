using System;

using System.ComponentModel.DataAnnotations;

namespace ProyectoLibros.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(160)]
        public string Email { get; set; } = string.Empty;

        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}

