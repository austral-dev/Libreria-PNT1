using System;

public class ItemPedido
{
    public int Cant { get; set; }
    public double Precio { get; set; }

    // Asociación con Libro (Cardinalidad 1)
    public Libro Libro { get; set; }

    public ItemPedido(Libro libro, int cantidad)
    {
        Libro = libro;
        Cant = cantidad;
        Precio = libro.Precio;
    }

    public double CalcularPrecio()
    {
        return Cant * Precio;
    }
}