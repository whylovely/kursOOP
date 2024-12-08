using kursOOP.Data.Models;
using kursOOP.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kursOOP.Services
{
    public class TenantService
    {
        private readonly IRepository<Tenant> _tenantRepository;

        public TenantService(IRepository<Tenant> tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<IEnumerable<Tenant>> GetAllTenantsAsync()
        {
            return await _tenantRepository.GetAllAsync();
        }

        public async Task AddTenantAsync(Tenant tenant)
        {
            await _tenantRepository.AddAsync(tenant);
        }

        public async Task UpdateTenantAsync(Tenant tenant)
        {
            await _tenantRepository.UpdateAsync(tenant);
        }

        public async Task DeleteTenantAsync(int id)
        {
            await _tenantRepository.DeleteAsync(id);
        }
    }
}
