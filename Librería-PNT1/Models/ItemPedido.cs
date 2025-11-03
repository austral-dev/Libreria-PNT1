using System;

public class ItemPedido
{
    // Atributos
    public int Cant { get; set; }
    public double Precio { get; set; } // Precio unitario al momento del pedido

    // Asociación con Libro (Cardinalidad 1)
    public Libro Libro { get; set; }

    // Constructor
    public ItemPedido(Libro libro, int cantidad)
    {
        Libro = libro;
        Cant = cantidad;
        Precio = libro.Precio; // Captura el precio actual del libro
    }

    // Método
    public double CalcularPrecio()
    {
        return Cant * Precio;
    }
}