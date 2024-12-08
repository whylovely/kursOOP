using System.Collections.Generic;
using System.Linq;

namespace kursOOP.Data.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; } // Телефон или e-mail
        public ICollection<RentalAgreement> RentalAgreements { get; set; } = new List<RentalAgreement>(); // Активные договоры

        public void AddAgreement(RentalAgreement agreement)
        {
            RentalAgreements.Add(agreement);
        }

        public void RemoveAgreement(int agreementId)
        {
            var agreement = RentalAgreements.FirstOrDefault(a => a.Id == agreementId);
            if (agreement != null)
            {
                RentalAgreements.Remove(agreement);
            }
        }
    }
}
