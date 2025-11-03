using System;

using System.ComponentModel.DataAnnotations;

namespace ProyectoLibros.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}