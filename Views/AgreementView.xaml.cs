using System.Windows;

namespace kursOOP.Views
{
    public partial class AgreementView : Window
    {
        public AgreementView()
        {
            InitializeComponent();
        }

        private void CreateAgreement(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создание договора аренды");
        }

        private void EditAgreement(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Редактирование договора аренды");
        }

        private void TerminateAgreement(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Завершение договора аренды");
        }
    }
}
