using System.Windows;

namespace kursOOP.Views
{
    public partial class TenantView : Window
    {
        public TenantView()
        {
            InitializeComponent();
        }

        private void AddTenant(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добавление арендатора");
        }

        private void EditTenant(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Редактирование арендатора");
        }

        private void DeleteTenant(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление арендатора");
        }
    }
}
