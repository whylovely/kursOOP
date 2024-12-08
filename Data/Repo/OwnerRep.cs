using kursOOP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursOOP.Data.Repository
{
    public class OwnerRepository : IRepository<Owner>
    {
        private readonly DatabaseContext _context;

        public OwnerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList(); // Возвращаем список всех владельцев из базы данных
        }

        public async Task<Owner> GetByIdAsync(int id)
        {
            return await _context.Owners
                .Include(o => o.Properties) // Включаем объекты недвижимости владельца
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners
                .Include(o => o.Properties)
                .ToListAsync();
        }

        public async Task<IEnumerable<Owner>> FindAsync(System.Linq.Expressions.Expression<System.Func<Owner, bool>> predicate)
        {
            return await _context.Owners
                .Include(o => o.Properties)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var owner = await GetByIdAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
