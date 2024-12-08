using kursOOP.Data.Models;
using kursOOP.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kursOOP.Services
{
    public class OwnerService
    {
        private readonly IRepository<Owner> _ownerRepository;

        public OwnerService(IRepository<Owner> ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _ownerRepository.GetAllAsync();
        }

        public async Task AddOwnerAsync(Owner owner)
        {
            await _ownerRepository.AddAsync(owner);
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            await _ownerRepository.UpdateAsync(owner);
        }

        public async Task DeleteOwnerAsync(int id)
        {
            await _ownerRepository.DeleteAsync(id);
        }
    }
}
