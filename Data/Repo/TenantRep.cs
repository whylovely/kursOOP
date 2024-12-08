using kursOOP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursOOP.Data.Repository
{
    public class TenantRepository : IRepository<Tenant>
    {
        private readonly DatabaseContext _context;

        public TenantRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Tenant> GetByIdAsync(int id)
        {
            return await _context.Tenants
                .Include(t => t.RentalAgreements) // Включаем договоры аренды арендатора
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _context.Tenants
                .Include(t => t.RentalAgreements)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tenant>> FindAsync(System.Linq.Expressions.Expression<System.Func<Tenant, bool>> predicate)
        {
            return await _context.Tenants
                .Include(t => t.RentalAgreements)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tenant tenant)
        {
            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tenant = await GetByIdAsync(id);
            if (tenant != null)
            {
                _context.Tenants.Remove(tenant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
