using kursOOP.Data.Models;
using kursOOP.Data.Repository;
using System;
using kursOOP.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalSystem.Services
{
    public class AgreementService
    {
        private readonly IRepository<RentalAgreement> _agreementRepository;
        public IEnumerable<RentalAgreement> RentalAgreements { get; private set; }

        public AgreementService(IRepository<RentalAgreement> agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }

        public IEnumerable<RentalAgreement> GetAll()
        {
            return _agreementRepository.GetAll();
        }

        public void LoadAgreements()
        {
            // Вызов метода GetAll() через экземпляр AgreementService
            RentalAgreements = _agreementRepository.GetAll();
        }

        public async Task<RentalAgreement> CreateAgreementAsync(Property property, Tenant tenant, DateTime startDate, decimal monthlyRent)
        {
            var agreement = new RentalAgreement
            {
                Property = property,
                Tenant = tenant,
                StartDate = startDate,
                MonthlyRent = monthlyRent,
                Status = AgreementStatus.Active
            };

            await _agreementRepository.AddAsync(agreement);
            return agreement;
        }

        public async Task TerminateAgreementAsync(int agreementId)
        {
            var agreement = await _agreementRepository.GetByIdAsync(agreementId);
            if (agreement != null)
            {
                agreement.Status = AgreementStatus.Terminated;
                await _agreementRepository.UpdateAsync(agreement);
            }
        }

        public async Task ExtendAgreementAsync(int agreementId, DateTime newEndDate)
        {
            var agreement = await _agreementRepository.GetByIdAsync(agreementId);
            if (agreement != null)
            {
                agreement.EndDate = newEndDate;
                await _agreementRepository.UpdateAsync(agreement);
            }
        }
    }
}
