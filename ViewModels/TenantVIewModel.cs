using kursOOP.Services;
using kursOOP.Data.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using kursOOP.Utils;

namespace kursOOP.ViewModels
{
    public class TenantViewModel : BaseViewModel
    {
        private readonly TenantService _tenantService;

        public ObservableCollection<Tenant> Tenants { get; set; }
        public ICommand AddTenantCommand { get; }
        public ICommand EditTenantCommand { get; }
        public ICommand DeleteTenantCommand { get; }

        public TenantViewModel(TenantService tenantService)
        {
            _tenantService = tenantService;

            AddTenantCommand = new RelayCommand(AddTenant);
            EditTenantCommand = new RelayCommand(EditTenant, CanEditOrDelete);
            DeleteTenantCommand = new RelayCommand(DeleteTenant, CanEditOrDelete);

            Tenants = new ObservableCollection<Tenant>();
            LoadTenantsAsync(); // Загружаем данные
        }

        private async void LoadTenantsAsync()
        {
            var tenants = await _tenantService.GetAllTenantsAsync();
            foreach (var tenant in tenants)
            {
                Tenants.Add(tenant);
            }
        }

        private void AddTenant()
        {
            // Логика добавления арендатора
        }

        private void EditTenant()
        {
            // Логика редактирования арендатора
        }

        private void DeleteTenant()
        {
            // Логика удаления арендатора
        }

        private bool CanEditOrDelete() => SelectedTenant != null;

        public Tenant SelectedTenant { get; set; }
    }
}
