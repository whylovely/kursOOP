using System.Windows;

namespace kursOOP.Utils
{
    public static class Navigator
    {
        public static void Navigate(BaseViewModel viewModel)
        {
            // Для примера мы используем Window с привязкой к ViewModel.
            var window = new Window
            {
                DataContext = viewModel
            };
            window.Show();
        }
    }
}
