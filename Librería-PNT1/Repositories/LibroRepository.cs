using System;

using Librería_PNT1.Data;
using Librería_PNT1.Models;
using Librería_PNT1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Librería_PNT1.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly AppDbContext _context;
        public LibroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Libro>> GetAllAsync()
        {
            return await _context.Libros.AsNoTracking().ToListAsync();
        }

        public async Task<Libro?> GetByIdAsync(int id)
        {
            return await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == id);
        }

        public async Task AddAsync(Libro entity)
        {
            await _context.Libros.AddAsync(entity);
        }

        public async Task UpdateAsync(Libro entity)
        {
            _context.Libros.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var libro = await GetByIdAsync(id);
            if (libro != null)
                _context.Libros.Remove(libro);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Libros.AnyAsync(l => l.IdLibro == id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

