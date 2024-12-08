using kursOOP.Data.Models;
using System;

namespace kursOOP.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int AgreementId { get; set; } // ID договора аренды
        public RentalAgreement Agreement { get; set; }
        public decimal Amount { get; set; } // Сумма оплаты
        public DateTime PaymentDate { get; set; } // Дата оплаты
        public PaymentMethod PaymentMethod { get; set; } // Метод оплаты

        public void ProcessPayment()
        {
            // Логика обработки платежа, если необходимо
        }
    }
}
