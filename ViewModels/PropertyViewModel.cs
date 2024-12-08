using kursOOP.Services;
using kursOOP.Data.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using kursOOP.Utils;

namespace kursOOP.ViewModels
{
    public class PropertyViewModel : BaseViewModel
    {
        private readonly PropertyService _propertyService;

        public ObservableCollection<Property> Properties { get; set; }
        public ICommand AddPropertyCommand { get; }
        public ICommand EditPropertyCommand { get; }
        public ICommand DeletePropertyCommand { get; }

        public PropertyViewModel(PropertyService propertyService)
        {
            _propertyService = propertyService;
            Properties = new ObservableCollection<Property>();

            AddPropertyCommand = new RelayCommand(AddProperty);
            EditPropertyCommand = new RelayCommand(EditProperty, CanEditOrDelete);
            DeletePropertyCommand = new RelayCommand(DeleteProperty, CanEditOrDelete);

            LoadProperties();
        }

        private async void LoadProperties()
        {
            var availableProperties = await _propertyService.GetAvailablePropertiesAsync();
            Properties.Clear();
            foreach (var property in availableProperties)
            {
                Properties.Add(property);
            }
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
