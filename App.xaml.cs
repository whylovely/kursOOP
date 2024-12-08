using System;
using System.Windows;

namespace kursOOP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        // Перегрузка метода OnStartup для дополнительной логики старта приложения
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Пример кастомной логики для инициализации
            // Здесь можно создать и запустить главный ViewModel или выполнить другие действия
        }
    }
}
