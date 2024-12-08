using System.Windows;

namespace kursOOP.Views
{
    public partial class OwnerView : Window
    {
        public OwnerView()
        {
            InitializeComponent();
        }

        private void AddOwner(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добавление владельца");
        }

        private void EditOwner(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Редактирование владельца");
        }

        private void DeleteOwner(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление владельца");
        }
    }
}
