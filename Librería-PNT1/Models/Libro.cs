using System;

public class Libro
{
    // Atributos
    public string IdLibro { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public bool Disponible { get; set; }

    // Asociación con el enumerado Categoria (Cardinalidad 1)
    public Categoria Categoria { get; set; }

    // Constructor (adaptado de los parámetros visibles en el diagrama)
    public Libro(string idLibro, string titulo, string autor, string descripcion, double precio, int stock, Categoria categoria)
    {
        IdLibro = idLibro;
        Titulo = titulo;
        Autor = autor;
        Descripcion = descripcion;
        Precio = precio;
        Stock = stock;
        Categoria = categoria;
        Disponible = (stock > 0); // Inicializar disponible
    }

    // Métodos
    public bool EstaEnStock()
    {
        return Stock > 0;
    }

    public void SetDisponible(bool estado)
    {
        Disponible = estado;
    }
}