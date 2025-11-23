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
    public class HistorialPedidosAdminController : Controller
    {
        private readonly AppDbContext _context;

        public HistorialPedidosAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HistorialPedidosAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HistorialPedidos.Include(h => h.Cliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: HistorialPedidosAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialPedidoEntity = await _context.HistorialPedidos
                .Include(h => h.Cliente)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (historialPedidoEntity == null)
            {
                return NotFound();
            }

            return View(historialPedidoEntity);
        }

        // GET: HistorialPedidosAdmin/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email");
            return View();
        }

        // POST: HistorialPedidosAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,Fecha,Total,IdCliente")] HistorialPedidoEntity historialPedidoEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialPedidoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", historialPedidoEntity.IdCliente);
            return View(historialPedidoEntity);
        }

        // GET: HistorialPedidosAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialPedidoEntity = await _context.HistorialPedidos.FindAsync(id);
            if (historialPedidoEntity == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", historialPedidoEntity.IdCliente);
            return View(historialPedidoEntity);
        }

        // POST: HistorialPedidosAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,Fecha,Total,IdCliente")] HistorialPedidoEntity historialPedidoEntity)
        {
            if (id != historialPedidoEntity.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialPedidoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialPedidoEntityExists(historialPedidoEntity.IdPedido))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", historialPedidoEntity.IdCliente);
            return View(historialPedidoEntity);
        }

        // GET: HistorialPedidosAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialPedidoEntity = await _context.HistorialPedidos
                .Include(h => h.Cliente)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (historialPedidoEntity == null)
            {
                return NotFound();
            }

            return View(historialPedidoEntity);
        }

        // POST: HistorialPedidosAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialPedidoEntity = await _context.HistorialPedidos.FindAsync(id);
            if (historialPedidoEntity != null)
            {
                _context.HistorialPedidos.Remove(historialPedidoEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialPedidoEntityExists(int id)
        {
            return _context.HistorialPedidos.Any(e => e.IdPedido == id);
        }
    }
}
