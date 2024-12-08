using System.Windows;

namespace kursOOP.Views
{
    public partial class PaymentView : Window
    {
        public PaymentView()
        {
            InitializeComponent();
        }

        private void AddPayment(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добавление платежа");
        }

        private void DeletePayment(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление платежа");
        }
    }
}
