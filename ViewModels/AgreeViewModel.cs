using kursOOP.Data.Models;
using kursOOP.Services;
using RentalSystem.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace kursOOP.ViewModels
{
    public class AgreementViewModel : BaseViewModel
    {
        public ObservableCollection<RentalAgreement> Agreements { get; set; }
        public ICommand CreateAgreementCommand { get; }
        public ICommand EditAgreementCommand { get; }
        public ICommand TerminateAgreementCommand { get; }

        public AgreementViewModel()
        {
            Agreements = new ObservableCollection<RentalAgreement>(AgreementService.GetAll());
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
