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
    public class ClientesAdminController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClientesAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: ClientesAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clienteEntity == null)
            {
                return NotFound();
            }

            return View(clienteEntity);
        }

        // GET: ClientesAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nombre,Email,Telefono,Direccion")] ClienteEntity clienteEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteEntity);
        }

        // GET: ClientesAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes.FindAsync(id);
            if (clienteEntity == null)
            {
                return NotFound();
            }
            return View(clienteEntity);
        }

        // POST: ClientesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nombre,Email,Telefono,Direccion")] ClienteEntity clienteEntity)
        {
            if (id != clienteEntity.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteEntityExists(clienteEntity.IdCliente))
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
            return View(clienteEntity);
        }

        // GET: ClientesAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clienteEntity == null)
            {
                return NotFound();
            }

            return View(clienteEntity);
        }

        // POST: ClientesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteEntity = await _context.Clientes.FindAsync(id);
            if (clienteEntity != null)
            {
                _context.Clientes.Remove(clienteEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteEntityExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
