using Libreria_PNT1.Models;
using Libreria_PNT1.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria_PNT1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILibroRepository _libroRepository;

        public ProductsController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        // GET: /Products
        // (si ya tenías búsqueda/filtros, después lo refinamos,
        // de momento que al menos liste todos los libros reales)
        public async Task<IActionResult> Index(string? q)
        {
            var libros = await _libroRepository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var texto = q.ToLower();
                libros = libros.Where(l =>
                    (!string.IsNullOrEmpty(l.Titulo) && l.Titulo.ToLower().Contains(texto)) ||
                    (!string.IsNullOrEmpty(l.Autor) && l.Autor.ToLower().Contains(texto))
                );
            }

            return View(libros.ToList());
        }

        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var libro = await _libroRepository.GetByIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }
    }
}
