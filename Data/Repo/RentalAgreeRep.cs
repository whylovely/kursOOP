using kursOOP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursOOP.Data.Repository
{
    public class RentalAgreementRepository : IRepository<RentalAgreement>
    {
        private readonly DatabaseContext _context;

        public RentalAgreementRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<RentalAgreement> GetByIdAsync(int id)
        {
            return await _context.RentalAgreements
                .Include(r => r.Property) // Включаем объект недвижимости
                .Include(r => r.Tenant)   // Включаем арендатора
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RentalAgreement>> GetAllAsync()
        {
            return await _context.RentalAgreements
                .Include(r => r.Property)
                .Include(r => r.Tenant)
                .ToListAsync();
        }

        public async Task<IEnumerable<RentalAgreement>> FindAsync(System.Linq.Expressions.Expression<System.Func<RentalAgreement, bool>> predicate)
        {
            return await _context.RentalAgreements
                .Include(r => r.Property)
                .Include(r => r.Tenant)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(RentalAgreement agreement)
        {
            await _context.RentalAgreements.AddAsync(agreement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RentalAgreement agreement)
        {
            _context.RentalAgreements.Update(agreement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agreement = await GetByIdAsync(id);
            if (agreement != null)
            {
                _context.RentalAgreements.Remove(agreement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
