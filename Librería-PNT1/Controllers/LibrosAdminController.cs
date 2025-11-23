using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libreria_PNT1.Data;
using Libreria_PNT1.Models;

namespace Libreria_PNT1.Controllers
{
    public class LibrosAdminController : Controller
    {
        private readonly AppDbContext _context;

        public LibrosAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LibrosAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Libros.Include(l => l.Categoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: LibrosAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroEntity = await _context.Libros
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libroEntity == null)
            {
                return NotFound();
            }

            return View(libroEntity);
        }

        // GET: LibrosAdmin/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Set<CategoriaEntity>(), "IdCategoria", "Nombre");
            return View();
        }

        // POST: LibrosAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Titulo,Autor,Descripcion,Precio,Stock,Disponible,CategoriaId")] LibroEntity libroEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libroEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Set<CategoriaEntity>(), "IdCategoria", "Nombre", libroEntity.CategoriaId);
            return View(libroEntity);
        }

        // GET: LibrosAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroEntity = await _context.Libros.FindAsync(id);
            if (libroEntity == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Set<CategoriaEntity>(), "IdCategoria", "Nombre", libroEntity.CategoriaId);
            return View(libroEntity);
        }

        // POST: LibrosAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,Titulo,Autor,Descripcion,Precio,Stock,Disponible,CategoriaId")] LibroEntity libroEntity)
        {
            if (id != libroEntity.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libroEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroEntityExists(libroEntity.IdLibro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Set<CategoriaEntity>(), "IdCategoria", "Nombre", libroEntity.CategoriaId);
            return View(libroEntity);
        }

        // GET: LibrosAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroEntity = await _context.Libros
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libroEntity == null)
            {
                return NotFound();
            }

            return View(libroEntity);
        }

        // POST: LibrosAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libroEntity = await _context.Libros.FindAsync(id);
            if (libroEntity != null)
            {
                _context.Libros.Remove(libroEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroEntityExists(int id)
        {
            return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
