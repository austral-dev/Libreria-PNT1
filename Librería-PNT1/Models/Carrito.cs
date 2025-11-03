using System;
public class Carrito

{
    private List<ItemPedido> _items;

    public Cliente Cliente { get; private set; }

    public Carrito(Cliente cliente)
    {
        _items = new List<ItemPedido>();
        Cliente = cliente;
    }

    // Métodos
    public void MostrarCarrito()
    {
        // Lógica para mostrar los items y sus precios
    }

    public void AnadirAlCarrito(Libro libro, int cantidad)
    {
        // Lógica para agregar un item al carrito.
        // Podría buscar si el libro ya está y sumar la cantidad.
        _items.Add(new ItemPedido(libro, cantidad));
    }

    public void QuitarDelCarrito(Libro libro)
    {
        // Lógica para quitar un item del carrito
    }

    public HistorialPedido ConfirmarCompra()
    {
        // Lógica para finalizar la compra, crear un HistorialPedido y vaciar el carrito
        double total = 0;
        foreach (var item in _items)
        {
            total += item.CalcularPrecio();
        }

        HistorialPedido nuevoPedido = new HistorialPedido(DateTime.Now, total, _items);
        Cliente.Historial.Add(nuevoPedido);
        _items.Clear(); // Vaciar el carrito
        return nuevoPedido;
    }
}