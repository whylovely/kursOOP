using kursOOP.Data.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using kursOOP.Utils;
using kursOOP.Services;

namespace kursOOP.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        private readonly PaymentService _paymentService;
        public ObservableCollection<Payment> Payments { get; set; }
        public ICommand RecordPaymentCommand { get; }

        public PaymentViewModel(PaymentService paymentService)
        {
            _paymentService = paymentService;
            Payments = new ObservableCollection<Payment>();

            RecordPaymentCommand = new RelayCommand(RecordPayment);

            LoadPaymentsAsync();
        }

        private async Task LoadPaymentsAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            foreach (var payment in payments)
            {
                Payments.Add(payment);
            }
        }

        private void RecordPayment()
        {
            // Логика для записи платежа
        }
    }
}
