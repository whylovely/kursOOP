using kursOOP.Data;
using kursOOP.Data.Models;
using kursOOP.Data.Repository;
using kursOOP.Services;
using kursOOP.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using RentalSystem.Services;

namespace kursOOP.ViewModels
{
    public class AgreementViewModel : BaseViewModel
    {
        public ObservableCollection<RentalAgreement> Agreements { get; set; }
        public ICommand CreateAgreementCommand { get; }
        public ICommand EditAgreementCommand { get; }
        public ICommand TerminateAgreementCommand { get; }

        private readonly AgreementService _agreementService;

        public AgreementViewModel()
        {
            // Создание экземпляра DbContextOptions для DatabaseContext
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer("Server=postgres;Database=property;Trusted_Connection=True;MultipleActiveResultSets=true")  // Укажите строку подключения
                .Options;

            // Создание экземпляра AgreementService с параметром DatabaseContext
            _agreementService = new AgreementService(new RentalAgreementRepository(new DatabaseContext(options)));

            // Загрузка всех договоров
            Agreements = new ObservableCollection<RentalAgreement>(_agreementService.GetAll());

            // Инициализация команд
            CreateAgreementCommand = new RelayCommand(CreateAgreement);
            EditAgreementCommand = new RelayCommand(EditAgreement, CanEditOrTerminate);
            TerminateAgreementCommand = new RelayCommand(TerminateAgreement, CanEditOrTerminate);
        }

        private void CreateAgreement()
        {
            // Логика создания договора
        }

        private void EditAgreement()
        {
            // Логика редактирования договора
        }

        private void TerminateAgreement()
        {
            // Логика завершения договора
        }

        private bool CanEditOrTerminate() => SelectedAgreement != null;

        public RentalAgreement SelectedAgreement { get; set; }
    }
}
