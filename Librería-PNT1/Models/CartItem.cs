namespace Libreria_PNT1.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public int Cantidad { get; set; }
    }
}
