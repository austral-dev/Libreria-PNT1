using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_PNT1.Models
{
    [Table("Clientes")]
    public class ClienteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string? Telefono { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string? Direccion { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Ciudad { get; set; } = string.Empty;

        [Required, StringLength(10)]
        public string CodigoPostal { get; set; } = string.Empty;

    }
}
