using Libreria_PNT1.Data;
using Libreria_PNT1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libreria_PNT1.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AppDbContext _db;

        public LibrosController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /Libros
        public async Task<IActionResult> Index()
        {
            var libros = await _db.Libros
                                  .Include(l => l.Categoria)   // si ya agregás CategoriaEntity
                                  .ToListAsync();
            return View(libros); // List<LibroEntity>
        }

        // GET: /Libros/Create
        public IActionResult Create() => View();

        // POST: /Libros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibroEntity model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Libros.Add(model);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Libros/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var libro = await _db.Libros.FindAsync(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        // POST: /Libros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LibroEntity model)
        {
            if (id != model.IdLibro) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Libros/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var libro = await _db.Libros.FindAsync(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        // POST: /Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _db.Libros.FindAsync(id);
            if (libro != null)
            {
                _db.Libros.Remove(libro);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

