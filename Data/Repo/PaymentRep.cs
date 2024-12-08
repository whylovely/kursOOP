using kursOOP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursOOP.Data.Repository
{
    public class PaymentRepository : IRepository<Payment>
    {
        private readonly DatabaseContext _context;

        public PaymentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments.ToList(); // Возвращаем все платежи из базы данных
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Agreement) // Включаем договор аренды
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .Include(p => p.Agreement)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> FindAsync(System.Linq.Expressions.Expression<System.Func<Payment, bool>> predicate)
        {
            return await _context.Payments
                .Include(p => p.Agreement)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await GetByIdAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
