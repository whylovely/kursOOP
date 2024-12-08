using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Input;

namespace kursOOP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand OpenPropertyViewCommand { get; }
        public ICommand OpenOwnerViewCommand { get; }
        public ICommand OpenTenantViewCommand { get; }
        public ICommand OpenAgreementViewCommand { get; }
        public ICommand OpenPaymentViewCommand { get; }

        public MainViewModel()
        {
            OpenPropertyViewCommand = new RelayCommand(OpenPropertyView);
            OpenOwnerViewCommand = new RelayCommand(OpenOwnerView);
            OpenTenantViewCommand = new RelayCommand(OpenTenantView);
            OpenAgreementViewCommand = new RelayCommand(OpenAgreementView);
            OpenPaymentViewCommand = new RelayCommand(OpenPaymentView);
        }

        private void OpenPropertyView() => Navigator.Navigate(new PropertyViewModel());
        private void OpenOwnerView() => Navigator.Navigate(new OwnerViewModel());
        private void OpenTenantView() => Navigator.Navigate(new TenantViewModel());
        private void OpenAgreementView() => Navigator.Navigate(new AgreementViewModel());
        private void OpenPaymentView() => Navigator.Navigate(new PaymentViewModel());
    }
}
