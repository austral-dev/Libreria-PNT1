using System;

using libreria_PNT1.Models;
using libreria_PNT1.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace libreria_PNT1.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroRepository _repo;

        public LibrosController(ILibroRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var libros = await _repo.GetAllAsync();
            return View(libros);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro model)
        {
            if (!ModelState.IsValid) return View(model);
            await _repo.AddAsync(model);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var libro = await _repo.GetByIdAsync(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro model)
        {
            if (id.ToString() != model.IdLibro) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            await _repo.UpdateAsync(model);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var libro = await _repo.GetByIdAsync(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

