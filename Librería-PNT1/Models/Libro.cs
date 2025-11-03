using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLibros.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required, StringLength(160)]
        public string Titulo { get; set; } = string.Empty;

        [Required, StringLength(13, MinimumLength = 10)]
        public string Isbn { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 999999)]
        public decimal Precio { get; set; }

        [Range(0, 100000)]
        public int Stock { get; set; }

        [Display(Name = "Fecha de publicación")]
        public DateTime? FechaPublicacion { get; set; }

        // FK → Editorial
        public int? EditorialId { get; set; }
        public Editorial? Editorial { get; set; }

        // N:N Autores / Categorías
        public ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}

