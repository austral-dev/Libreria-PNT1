using System;

using Libreria_PNT1.Models;

namespace Libreria_PNT1.Repositories.Interfaces
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> GetAllAsync();
        Task<Libro?> GetByIdAsync(int id);
        Task AddAsync(Libro entity);
        Task UpdateAsync(Libro entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
