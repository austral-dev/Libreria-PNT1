using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_PNT1.Models
{
    [Table("Libros")]
    public class LibroEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }

        [Required, StringLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Autor { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 999999)]
        public decimal Precio { get; set; }

        [Range(0, 10000)]
        public int Stock { get; set; }

        public bool Disponible { get; set; } = true;

        //public int? CategoriaId { get; set; }
        //Categoria? Categoria { get; set; }

        public int? CategoriaId { get; set; }
        public CategoriaEntity? Categoria { get; set; }

        // NUEVO → Nombre del archivo de imagen
        public string? Imagen { get; set; }

        public LibroEntity() { }

        public bool EstaEnStock() => Stock > 0;
    }
}
