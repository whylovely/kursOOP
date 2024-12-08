using kursOOP.Data.Models;
using kursOOP.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace kursOOP.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        public ObservableCollection<Payment> Payments { get; set; }
        public ICommand AddPaymentCommand { get; }
        public ICommand DeletePaymentCommand { get; }

        public PaymentViewModel()
        {
            Payments = new ObservableCollection<Payment>(PaymentService.GetAll());
            AddPaymentCommand = new RelayCommand(AddPayment);
            DeletePaymentCommand = new RelayCommand(DeletePayment, CanDelete);
        }

        private void AddPayment()
        {
            // Логика добавления платежа
        }

        private void DeletePayment()
        {
            // Логика удаления платежа
        }

        private bool CanDelete() => SelectedPayment != null;

        public Payment SelectedPayment { get; set; }
    }
}
