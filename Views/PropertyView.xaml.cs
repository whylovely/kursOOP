using System.Windows;

namespace kursOOP.Views
{
    public partial class PropertyView : Window
    {
        public PropertyView()
        {
            InitializeComponent();
        }

        private void AddProperty(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добавление недвижимости");
        }

        private void EditProperty(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Редактирование недвижимости");
        }

        private void DeleteProperty(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление недвижимости");
        }
    }
}
