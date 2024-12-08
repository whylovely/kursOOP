using System;
using System.Collections.Generic;

namespace kursOOP.Data.Models
{
    public class RentalAgreement
    {
        public int Id { get; set; }
        public int PropertyId { get; set; } // ID недвижимости
        public Property Property { get; set; }
        public int TenantId { get; set; } // ID арендатора
        public Tenant Tenant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Дата окончания (опционально)
        public decimal MonthlyRent { get; set; } // Стоимость аренды в месяц
        public AgreementStatus Status { get; set; } = AgreementStatus.Active; // Статус договора
        public ICollection<Payment> Payments { get; set; } = new List<Payment>(); // Платежи

        public void TerminateAgreement()
        {
            Status = AgreementStatus.Terminated;
            EndDate = DateTime.Now;
        }

        public void ExtendAgreement(DateTime newEndDate)
        {
            EndDate = newEndDate;
        }
    }
}
