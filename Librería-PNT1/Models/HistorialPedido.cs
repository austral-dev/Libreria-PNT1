using System;

public class HistorialPedido
{
    // Atributos
    public DateTime Fecha { get; set; }
    public double PrecioTotal { get; set; }

    // Asociación con ItemPedido (Cardinalidad 1..n, implementada con una lista, ya que un pedido debe tener al menos un item)
    public List<ItemPedido> Items { get; private set; }

    // Asociación con Cliente (Cardinalidad 1, gestionada en la clase Cliente/Carrito)

    // Constructor
    public HistorialPedido(DateTime fecha, double precioTotal, List<ItemPedido> items)
    {
        Fecha = fecha;
        PrecioTotal = precioTotal;
        Items = items;
    }
}