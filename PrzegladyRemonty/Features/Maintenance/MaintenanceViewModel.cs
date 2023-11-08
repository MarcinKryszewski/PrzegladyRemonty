using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Shared.Stores;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class MaintenanceViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IHost _databaseHost;
        private readonly TransportersListStore _transporters;
        private TransporterStore _transporter;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MaintenanceViewModel(IHost databaseHost)
        {
            _databaseHost = databaseHost;
            _navigationStore = new NavigationStore();

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _transporters = new TransportersListStore();
            _transporter = new TransporterStore();

            INavigationService<TransportersChooseViewModel> TransportersChooseNavigationService = CreateTransportersChooseNavigationService();
            TransportersChooseNavigationService.Navigate();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private INavigationService<TransportersChooseViewModel> CreateTransportersChooseNavigationService()
        {
            return new DefaultNavigationService<TransportersChooseViewModel>
            (
                _navigationStore,
                () => new TransportersChooseViewModel()
            );
        }
    }
}
