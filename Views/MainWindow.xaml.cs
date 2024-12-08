using System.Windows;

namespace kursOOP.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenPropertyView(object sender, RoutedEventArgs e)
        {
            var propertyView = new PropertyView();
            propertyView.Show();
        }

        private void OpenOwnerView(object sender, RoutedEventArgs e)
        {
            var ownerView = new OwnerView();
            ownerView.Show();
        }

        private void OpenTenantView(object sender, RoutedEventArgs e)
        {
            var tenantView = new TenantView();
            tenantView.Show();
        }

        private void OpenAgreementView(object sender, RoutedEventArgs e)
        {
            var agreementView = new AgreementView();
            agreementView.Show();
        }

        private void OpenPaymentView(object sender, RoutedEventArgs e)
        {
            var paymentView = new PaymentView();
            paymentView.Show();
        }
    }
}
