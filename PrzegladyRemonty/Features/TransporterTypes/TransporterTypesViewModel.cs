using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IHost _databaseHost;
        private readonly SelectedTransporterType _transproterType;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public TransporterTypesViewModel(IHost databaseHost)
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _databaseHost = databaseHost;
            _transproterType = new SelectedTransporterType();

            INavigationService<TransporterTypesMainViewModel> TransporterTypesMainNavigationService = CreateTransporterTypesMainNavigationService();
            TransporterTypesMainNavigationService.Navigate();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private INavigationService<TransporterTypesMainViewModel> CreateTransporterTypesMainNavigationService()
        {
            return new DefaultNavigationService<TransporterTypesMainViewModel>
            (
                _navigationStore,
                () => new TransporterTypesMainViewModel(
                    CreateTransporterTypesEditNavigationService(),
                    CreateTransporterTypesAddNavigationService(),
                    CreateTransporterTypesDetailsNavigationService(),
                    _transproterType,
                    _databaseHost)
            );
        }

        private INavigationService<TransporterTypesAddViewModel> CreateTransporterTypesAddNavigationService()
        {
            return new DefaultNavigationService<TransporterTypesAddViewModel>
            (
                _navigationStore,
                () => new TransporterTypesAddViewModel(
                    CreateTransporterTypesMainNavigationService(),
                    _databaseHost
                )
            );
        }

        private INavigationService<TransporterTypesDetailsViewModel> CreateTransporterTypesDetailsNavigationService()
        {
            return new DefaultNavigationService<TransporterTypesDetailsViewModel>
            (
                _navigationStore,
                () => new TransporterTypesDetailsViewModel(
                    CreateTransporterTypesMainNavigationService()
                )
            );
        }

        private INavigationService<TransporterTypesEditViewModel> CreateTransporterTypesEditNavigationService()
        {
            return new DefaultNavigationService<TransporterTypesEditViewModel>
            (
                _navigationStore,
                () => new TransporterTypesEditViewModel(
                    CreateTransporterTypesMainNavigationService(),
                    _transproterType,
                    _databaseHost)
            );
        }


    }
}
