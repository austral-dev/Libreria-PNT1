using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Libro
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // Vos manejás el Id (string "1", "2", etc.)
    public string IdLibro { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public double Precio { get; set; }
    public int Stock { get; set; }
    public bool Disponible { get; set; }

    // Asociación con el enumerado Categoria (Cardinalidad 1)
    public Categoria Categoria { get; set; }

    //Constructor vacío obligatorio para EF
    public Libro() { }

    public Libro(string idLibro, string titulo, string autor, string descripcion, double precio, int stock, Categoria categoria)
    {
        IdLibro = idLibro;
        Titulo = titulo;
        Autor = autor;
        Descripcion = descripcion;
        Precio = precio;
        Stock = stock;
        Categoria = categoria;
        Disponible = (stock > 0);
    }

    public bool EstaEnStock()
    {
        return Stock > 0;
    }

    public void SetDisponible(bool estado)
    {
        Disponible = estado;
    }
}