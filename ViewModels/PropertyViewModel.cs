using kursOOP.Services;
using kursOOP.Data.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace kursOOP.ViewModels
{
    public class PropertyViewModel : BaseViewModel
    {
        public ObservableCollection<Property> Properties { get; set; }
        public ICommand AddPropertyCommand { get; }
        public ICommand EditPropertyCommand { get; }
        public ICommand DeletePropertyCommand { get; }

        public PropertyViewModel()
        {
            Properties = new ObservableCollection<Property>(PropertyService.GetAll());
            AddPropertyCommand = new RelayCommand(AddProperty);
            EditPropertyCommand = new RelayCommand(EditProperty, CanEditOrDelete);
            DeletePropertyCommand = new RelayCommand(DeleteProperty, CanEditOrDelete);
        }

        private void AddProperty()
        {
            // Логика добавления недвижимости
        }

        private void EditProperty()
        {
            // Логика редактирования недвижимости
        }

        private void DeleteProperty()
        {
            // Логика удаления недвижимости
        }

        private bool CanEditOrDelete() => SelectedProperty != null;

        public Property SelectedProperty { get; set; }
    }
}
