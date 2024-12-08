using kursOOP.Data.Repository;
using kursOOP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kursOOP.Services
{
    public class PropertyService
    {
        private readonly IRepository<Property> _propertyRepository;

        public PropertyService(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetAvailablePropertiesAsync()
        {
            return await _propertyRepository.FindAsync(p => p.Status == PropertyStatus.Available);
        }

        public async Task AddPropertyAsync(Property property)
        {
            await _propertyRepository.AddAsync(property);
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            await _propertyRepository.UpdateAsync(property);
        }

        public async Task DeletePropertyAsync(int id)
        {
            await _propertyRepository.DeleteAsync(id);
        }
    }
}
