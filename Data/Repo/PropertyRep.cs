using Microsoft.EntityFrameworkCore;
using kursOOP.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursOOP.Data.Repository
{
    public class PropertyRepository : IRepository<Property>
    {
        private readonly DatabaseContext _context;

        public PropertyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetAll()
        {
            return _context.Properties.ToList();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.Owner) // Включаем владельца для получения полной информации
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _context.Properties
                .Include(p => p.Owner)
                .ToListAsync();
        }

        public async Task<IEnumerable<Property>> FindAsync(System.Linq.Expressions.Expression<System.Func<Property, bool>> predicate)
        {
            return await _context.Properties
                .Include(p => p.Owner)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var property = await GetByIdAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();
            }
        }
    }
}
