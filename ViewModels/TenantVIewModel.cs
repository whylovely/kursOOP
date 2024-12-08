using kursOOP.Data.Models;
using kursOOP.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace kursOOP.ViewModels
{
    public class TenantViewModel : BaseViewModel
    {
        public ObservableCollection<Tenant> Tenants { get; set; }
        public ICommand AddTenantCommand { get; }
        public ICommand EditTenantCommand { get; }
        public ICommand DeleteTenantCommand { get; }

        public TenantViewModel()
        {
            Tenants = new ObservableCollection<Tenant>(TenantService.GetAll());
            AddTenantCommand = new RelayCommand(AddTenant);
            EditTenantCommand = new RelayCommand(EditTenant, CanEditOrDelete);
            DeleteTenantCommand = new RelayCommand(DeleteTenant, CanEditOrDelete);
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
