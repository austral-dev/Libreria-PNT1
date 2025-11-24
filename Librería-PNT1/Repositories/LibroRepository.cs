using Libreria_PNT1.Data;
using Libreria_PNT1.Models;
using Libreria_PNT1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria_PNT1.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly AppDbContext _context;

        public LibroRepository(AppDbContext context)
        {
            _context = context;
        }

        // ======================================================
        // GET ALL
        // ======================================================
        public async Task<IEnumerable<Libro>> GetAllAsync()
        {
            var entities = await _context.Libros
                                         .Include(l => l.Categoria)
                                         .AsNoTracking()
                                         .ToListAsync();

            return entities.Select(entity =>
            {
                var libro = new Libro(
                    entity.IdLibro.ToString(),
                    entity.Titulo,
                    entity.Autor,
                    entity.Descripcion ?? string.Empty,
                    (double)entity.Precio,
                    entity.Stock,
                    Categoria.NOVELA
                );

                libro.Disponible = entity.Disponible;
                libro.CategoriaId = entity.CategoriaId;
                libro.CategoriaNombre = entity.Categoria?.Nombre;

                // 👉 IMPORTANTE: asignar la imagen desde la base
                libro.Imagen = entity.Imagen;

                return libro;
            });
        }

        // ======================================================
        // GET BY ID
        // ======================================================
        public async Task<Libro?> GetByIdAsync(int id)
        {
            var entity = await _context.Libros
                                       .Include(l => l.Categoria)
                                       .FirstOrDefaultAsync(l => l.IdLibro == id);

            if (entity == null) return null;

            var libro = new Libro(
                entity.IdLibro.ToString(),
                entity.Titulo,
                entity.Autor,
                entity.Descripcion ?? string.Empty,
                (double)entity.Precio,
                entity.Stock,
                Categoria.NOVELA
            );

            libro.Disponible = entity.Disponible;
            libro.CategoriaId = entity.CategoriaId;
            libro.CategoriaNombre = entity.Categoria?.Nombre;

            // 👉 IMPORTANTE
            libro.Imagen = entity.Imagen;

            return libro;
        }

        // ======================================================
        // ADD
        // ======================================================
        public async Task AddAsync(Libro entity)
        {
            var libroEntity = new LibroEntity
            {
                IdLibro = int.TryParse(entity.IdLibro, out var id) ? id : 0,
                Titulo = entity.Titulo,
                Autor = entity.Autor,
                Descripcion = entity.Descripcion,
                Precio = (decimal)entity.Precio,
                Stock = entity.Stock,
                Disponible = entity.Disponible,
                CategoriaId = entity.CategoriaId,

                // 👉 IMPORTANTE
                Imagen = entity.Imagen
            };

            await _context.Libros.AddAsync(libroEntity);
        }

        // ======================================================
        // UPDATE
        // ======================================================
        public Task UpdateAsync(Libro entity)
        {
            if (!int.TryParse(entity.IdLibro, out var id))
                throw new ArgumentException("El IdLibro no es un número válido.");

            var libroEntity = new LibroEntity
            {
                IdLibro = id,
                Titulo = entity.Titulo,
                Autor = entity.Autor,
                Descripcion = entity.Descripcion,
                Precio = (decimal)entity.Precio,
                Stock = entity.Stock,
                Disponible = entity.Disponible,
                CategoriaId = entity.CategoriaId,

                // 👉 IMPORTANTE
                Imagen = entity.Imagen
            };

            _context.Libros.Update(libroEntity);
            return Task.CompletedTask;
        }

        // ======================================================
        // DELETE
        // ======================================================
        public async Task DeleteAsync(int id)
        {
            var libroEntity = await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == id);
            if (libroEntity != null)
                _context.Libros.Remove(libroEntity);
        }

        // ======================================================
        // EXISTS
        // ======================================================
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Libros.AnyAsync(l => l.IdLibro == id);
        }

        // ======================================================
        // SAVE CHANGES
        // ======================================================
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
