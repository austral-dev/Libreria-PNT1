using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_PNT1.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IdLibro { get; set; } = string.Empty;  // <- volvemos a string

        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // podés dejar double si ya está usado así en todos lados
        public double Precio { get; set; }

        public int Stock { get; set; }
        public bool Disponible { get; set; }

        // NUEVA propiedad para la portada
        public string? Imagen { get; set; }

        // FK / Navegación
        public int? CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; }
        public Categoria Categoria { get; set; }

        public Libro() { }

        public Libro(string idLibro, string titulo, string autor,
                     string descripcion, double precio, int stock, Categoria categoria)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Autor = autor;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
            Disponible = stock > 0;
        }

        public bool EstaEnStock() => Stock > 0;
        public void SetDisponible(bool estado) => Disponible = estado;
    }
}
