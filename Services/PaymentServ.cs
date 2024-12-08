using kursOOP.Data.Models;
using kursOOP.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kursOOP.Services
{
    public class PaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;

        public PaymentService(IRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task RecordPaymentAsync(RentalAgreement agreement, decimal amount, string paymentMethod)
        {
            if (!Enum.TryParse(paymentMethod, true, out PaymentMethod method))
            {
                throw new ArgumentException($"Invalid payment method: {paymentMethod}");
            }

            var payment = new Payment
            {
                Agreement = agreement,
                Amount = amount,
                PaymentDate = DateTime.UtcNow,
                PaymentMethod = method
            };

            await _paymentRepository.AddAsync(payment);
        }

        // Добавляем метод GetAll для получения всех платежей
        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }
    }
}
