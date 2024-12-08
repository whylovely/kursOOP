using kursOOP.Services;
using kursOOP.Utils;
using System.Windows.Input;

namespace kursOOP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly OwnerService _ownerService;
        private readonly PaymentService _paymentService;
        private readonly PropertyService _propertyService;
        private readonly TenantService _tenantService;  // Добавляем зависимость для TenantService

        public ICommand OpenPropertyViewCommand { get; }
        public ICommand OpenOwnerViewCommand { get; }
        public ICommand OpenTenantViewCommand { get; }
        public ICommand OpenAgreementViewCommand { get; }
        public ICommand OpenPaymentViewCommand { get; }

        // Конструктор для внедрения зависимостей
        public MainViewModel(OwnerService ownerService, PaymentService paymentService, PropertyService propertyService, TenantService tenantService)
        {
            _ownerService = ownerService;
            _paymentService = paymentService;
            _propertyService = propertyService;
            _tenantService = tenantService;  // Инициализируем зависимость

            OpenPropertyViewCommand = new RelayCommand(OpenPropertyView);
            OpenOwnerViewCommand = new RelayCommand(OpenOwnerView);
            OpenTenantViewCommand = new RelayCommand(OpenTenantView);
            OpenAgreementViewCommand = new RelayCommand(OpenAgreementView);
            OpenPaymentViewCommand = new RelayCommand(OpenPaymentView);
        }

        private void OpenPropertyView() => Navigator.Navigate(new PropertyViewModel(_propertyService));  // Передаем зависимость

        // Передаем OwnerService в конструктор OwnerViewModel
        private void OpenOwnerView() => Navigator.Navigate(new OwnerViewModel(_ownerService));

        private void OpenTenantView() => Navigator.Navigate(new TenantViewModel(_tenantService));  // Передаем TenantService в конструктор TenantViewModel

        private void OpenAgreementView() => Navigator.Navigate(new AgreementViewModel());

        // Передаем PaymentService в конструктор PaymentViewModel
        private void OpenPaymentView() => Navigator.Navigate(new PaymentViewModel(_paymentService));
    }
}
