using Libreria_PNT1.Models; 
using System.Linq;
using System.Collections.Generic;
using System;


namespace Libreria_PNT1.Services
{
    public class LibroService
    {
        // El guion bajo (_) indica que es un campo privado de esta clase
        // Esta será nuestra "base de datos" temporal en memoria
        private List<Libro> _libros;

        // Constructor: Se ejecuta automáticamente cuando creas un 'new LibroService()'
        public LibroService()
        {
            // 1. Inicializamos la lista para que no esté vacía (null)
            _libros = new List<Libro>();

            // 2. (Opcional) Cargamos datos de prueba para que la app tenga algo que mostrar
            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            var libro1 = new Libro("1", "Cien Años de Soledad", "García Márquez", "Realismo mágico", 30.00, 10, Categoria.NOVELA);
            var libro2 = new Libro("2", "El Aleph", "Jorges Luis Borges", "Colección de cuentos", 22.50, 5, Categoria.CUENTO);
            var libro3 = new Libro("3", "Sapiens", "Yuval Noah Harari", "Historia de la humanidad", 28.75, 15, Categoria.NO_FICCION);

            _libros.Add(libro1);
            _libros.Add(libro2);
            _libros.Add(libro3);
        }

        // Devuelve la lista completa de libros
        public List<Libro> MostrarLibros()
        {
            return _libros;
        }

        // Carga un nuevo libro a la lista
        public void CargarLibro(Libro nuevoLibro)
        {
            _libros.Add(nuevoLibro);
        }

        // Busca un libro por su ID
        public Libro? BuscarLibroPorId(string id)
        {
            return _libros.FirstOrDefault(l => l.IdLibro == id);
        }

        public Libro? BuscarLibroPorNombre(string nombre)
        {
            return _libros.FirstOrDefault(l => l.Titulo.Contains(nombre, StringComparison.OrdinalIgnoreCase));
        }

        // Busca libros por categoría
        public List<Libro> BuscarLibrosPorCategoria(Categoria categoria)
        {
            // Usamos 'Where' porque puede haber MÁS de un libro de esa categoría
            return _libros.Where(l => l.Categoria == categoria).ToList();
        }

     

        // Actualiza el stock de un libro
        public void ActualizarStock(string idLibro, int nuevaCantidad)
        {
            // 1. Encontramos el libro
            Libro? libro = BuscarLibroPorId(idLibro);   // ahora nullable

            // 2. Verificamos si existe antes de intentar modificarlo
            if (libro != null)
            {
                libro.Stock = nuevaCantidad;
                // Actualizamos también su disponibilidad
                libro.SetDisponible(nuevaCantidad > 0);
            }
        }

        // Elimina un libro de la lista
        public void EliminarLibro(string idLibro)
        {
            Libro? libro = BuscarLibroPorId(idLibro);   //
            if (libro != null)
            {
                _libros.Remove(libro);
            }
        }


        // Filtra libros que cuesten MENOS O IGUAL al precio dado
        public List<Libro> FiltrarPorPrecio(double maxPrecio)
        {
            return _libros.Where(l => l.Precio <= maxPrecio).ToList();
        }

        public void ModificarLibro(string idLibro, string nuevoTitulo, double nuevoPrecio)
        {
            Libro? libro = BuscarLibroPorId(idLibro);   //
            if (libro != null)
            {
                libro.Titulo = nuevoTitulo;
                libro.Precio = nuevoPrecio;
            }
        }

        public void ActualizarPrecios(string idLibro, double nuevoPrecio)
        {
            Libro? libro = BuscarLibroPorId(idLibro);   //
            if (libro != null)
            {
                libro.Precio = nuevoPrecio;
            }
        }
    }
}