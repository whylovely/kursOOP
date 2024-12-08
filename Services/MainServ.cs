using kursOOP.Data.Models;
using kursOOP.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalSystem.Services
{
    public class PropertyManager
    {
        private readonly PropertyService _propertyService;
        private readonly OwnerService _ownerService;
        private readonly TenantService _tenantService;
        private readonly AgreementService _agreementService;
        private readonly PaymentService _paymentService;

        public PropertyManager(
            PropertyService propertyService,
            OwnerService ownerService,
            TenantService tenantService,
            AgreementService agreementService,
            PaymentService paymentService)
        {
            _propertyService = propertyService;
            _ownerService = ownerService;
            _tenantService = tenantService;
            _agreementService = agreementService;
            _paymentService = paymentService;
        }

        public async Task<IEnumerable<Property>> FindAvailablePropertiesAsync()
        {
            return await _propertyService.GetAvailablePropertiesAsync();
        }

        public async Task CreateRentalAgreementAsync(Property property, Tenant tenant, decimal monthlyRent)
        {
            await _agreementService.CreateAgreementAsync(property, tenant, System.DateTime.UtcNow, monthlyRent);
        }

        public async Task RecordPaymentAsync(RentalAgreement agreement, decimal amount, string paymentMethod)
        {
            await _paymentService.RecordPaymentAsync(agreement, amount, paymentMethod);
        }
    }
}
