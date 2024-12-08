using kursOOP.Data.Models;
using kursOOP.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using kursOOP.Utils;
using System.Threading.Tasks;

namespace kursOOP.ViewModels
{
    public class OwnerViewModel : BaseViewModel
    {
        private readonly OwnerService _ownerService;

        public ObservableCollection<Owner> Owners { get; set; }
        public ICommand AddOwnerCommand { get; }
        public ICommand EditOwnerCommand { get; }
        public ICommand DeleteOwnerCommand { get; }

        public OwnerViewModel(OwnerService ownerService)
        {
            _ownerService = ownerService;
            Owners = new ObservableCollection<Owner>();
            AddOwnerCommand = new RelayCommand(AddOwner);
            EditOwnerCommand = new RelayCommand(EditOwner, CanEditOrDelete);
            DeleteOwnerCommand = new RelayCommand(DeleteOwner, CanEditOrDelete);

            // Загрузка данных владельцев при создании ViewModel
            LoadOwners();
        }

        private async void LoadOwners()
        {
            var owners = await _ownerService.GetAllOwnersAsync();
            foreach (var owner in owners)
            {
                Owners.Add(owner);
            }
        }

        private void AddOwner()
        {
            // Логика добавления владельца
        }

        private void EditOwner()
        {
            // Логика редактирования владельца
        }

        private void DeleteOwner()
        {
            // Логика удаления владельца
        }

        private bool CanEditOrDelete() => SelectedOwner != null;

        public Owner SelectedOwner { get; set; }
    }
}
