namespace Libreria_PNT1.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
        public string Categoria { get; set; }
    }
}
