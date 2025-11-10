using System;
using System.Collections.Generic;
using System.Linq;

namespace Librería_PNT1.Models
{
    public class Carrito
    {
        private List<ItemPedido> _items;

        public Cliente Cliente { get; private set; }

        public Carrito(Cliente cliente)
        {
            _items = new List<ItemPedido>();
            Cliente = cliente;
        }


        /// <summary>
        /// Muestra el contenido del carrito en la consola.
        /// </summary>
        public void MostrarCarrito()
        {
            Console.WriteLine("--- 🛒 Carrito de Compras ---");
            if (_items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            // Recorremos cada item y mostramos sus detalles
            foreach (var item in _items)
            {
                // Usamos el método CalcularPrecio() del item
                Console.WriteLine($"-> {item.Cant}x {item.Libro.Titulo} (${item.Precio} c/u) = Subtotal: ${item.CalcularPrecio()}");
            }

            // Mostramos el total
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"TOTAL: ${CalcularTotal()}");
        }

        /// <summary>
        /// Añade un libro al carrito.
        /// Si el libro ya está, solo incrementa la cantidad.
        /// </summary>
        public void AnadirAlCarrito(Libro libro, int cantidad)
        {
            // 1. Buscamos si el libro ya está en el carrito
            // Comparamos usando el IdLibro, que es un identificador único
            var itemExistente = _items.FirstOrDefault(item => item.Libro.IdLibro == libro.IdLibro);

            if (itemExistente != null)
            {
                // 2. Si existe, solo sumamos la cantidad
                itemExistente.Cant += cantidad;
            }
            else
            {
                // 3. Si no existe, creamos un nuevo ItemPedido y lo añadimos
                _items.Add(new ItemPedido(libro, cantidad));
            }
        }

        /// <summary>
        /// Quita un libro (y toda su cantidad) del carrito.
        /// </summary>
        public void QuitarDelCarrito(Libro libro)
        {
            // 1. Buscamos el item que corresponde a ese libro
            var itemParaQuitar = _items.FirstOrDefault(item => item.Libro.IdLibro == libro.IdLibro);

            // 2. Si lo encontramos (no es null), lo eliminamos de la lista
            if (itemParaQuitar != null)
            {
                _items.Remove(itemParaQuitar);
            }
        }

        /// <summary>
        /// Finaliza la compra, genera un HistorialPedido y vacía el carrito.
        /// </summary>
        public HistorialPedido ConfirmarCompra()
        {
            // 1. Calculamos el total usando nuestro nuevo método
            double total = CalcularTotal();

            // 2. Creamos una copia de la lista de items para el historial.
            //    Esto es importante para que al vaciar el carrito (_items.Clear()),
            //    no se borren los items del pedido histórico.
            List<ItemPedido> itemsDelPedido = new List<ItemPedido>(_items);

            // 3. Creamos el nuevo pedido
            HistorialPedido nuevoPedido = new HistorialPedido(DateTime.Now, total, itemsDelPedido);

            // 4. Lo agregamos al historial del cliente
            Cliente.Historial.Add(nuevoPedido);

            // 5. Vaciamos el carrito actual
            _items.Clear();

            return nuevoPedido;
        }

        // --- MÉTODO AUXILIAR ---

        /// <summary>
        /// Calcula el precio total de todos los items en el carrito.
        /// </summary>
        public double CalcularTotal()
        {
            // Usamos LINQ (.Sum) para sumar el resultado de CalcularPrecio() 
            // de cada item en la lista. Es más limpio que un 'foreach'.
            return _items.Sum(item => item.CalcularPrecio());
        }
    }
}