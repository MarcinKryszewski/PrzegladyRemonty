using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IHost _databaseHost;
        private readonly SelectedPart _transproterType;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public PartsViewModel(IHost databaseHost)
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _databaseHost = databaseHost;
            _transproterType = new SelectedPart();

            INavigationService<PartsMainViewModel> PartsMainNavigationService = CreatePartsMainNavigationService();
            PartsMainNavigationService.Navigate();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private INavigationService<PartsMainViewModel> CreatePartsMainNavigationService()
        {
            return new DefaultNavigationService<PartsMainViewModel>
            (
                _navigationStore,
                () => new PartsMainViewModel(
                    CreatePartsEditNavigationService(),
                    CreatePartsAddNavigationService(),
                    CreatePartsDetailsNavigationService(),
                    _transproterType,
                    _databaseHost)
            );
        }

        private INavigationService<PartsAddViewModel> CreatePartsAddNavigationService()
        {
            return new DefaultNavigationService<PartsAddViewModel>
            (
                _navigationStore,
                () => new PartsAddViewModel(
                    CreatePartsMainNavigationService(),
                    _databaseHost
                )
            );
        }

        private INavigationService<PartsDetailsViewModel> CreatePartsDetailsNavigationService()
        {
            return new DefaultNavigationService<PartsDetailsViewModel>
            (
                _navigationStore,
                () => new PartsDetailsViewModel(
                    CreatePartsMainNavigationService()
                )
            );
        }

        private INavigationService<PartsEditViewModel> CreatePartsEditNavigationService()
        {
            return new DefaultNavigationService<PartsEditViewModel>
            (
                _navigationStore,
                () => new PartsEditViewModel(
                    CreatePartsMainNavigationService(),
                    _transproterType,
                    _databaseHost)
            );
        }


    }
}
