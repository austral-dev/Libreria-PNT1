using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_PNT1.Models
{
    [Table("Categorias")]
    public class CategoriaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<LibroEntity> Libros { get; set; } = new List<LibroEntity>();
    }
}
