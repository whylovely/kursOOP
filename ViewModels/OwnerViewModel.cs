using kursOOP.Data.Models;
using kursOOP.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace kursOOP.ViewModels
{
    public class OwnerViewModel : BaseViewModel
    {
        public ObservableCollection<Owner> Owners { get; set; }
        public ICommand AddOwnerCommand { get; }
        public ICommand EditOwnerCommand { get; }
        public ICommand DeleteOwnerCommand { get; }

        public OwnerViewModel()
        {
            Owners = new ObservableCollection<Owner>(OwnerService.GetAll());
            AddOwnerCommand = new RelayCommand(AddOwner);
            EditOwnerCommand = new RelayCommand(EditOwner, CanEditOrDelete);
            DeleteOwnerCommand = new RelayCommand(DeleteOwner, CanEditOrDelete);
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
