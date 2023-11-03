using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public PartsViewModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
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
                    CreatePartsDetailsNavigationService())
            );
        }
        private INavigationService<PartsAddViewModel> CreatePartsAddNavigationService()
        {
            return new DefaultNavigationService<PartsAddViewModel>
            (
                _navigationStore,
                () => new PartsAddViewModel(
                    CreatePartsMainNavigationService(),
                    CreatePartsEditNavigationService(),
                    CreatePartsDetailsNavigationService()
                )
            );
        }
        private INavigationService<PartsDetailsViewModel> CreatePartsDetailsNavigationService()
        {
            return new DefaultNavigationService<PartsDetailsViewModel>
            (
                _navigationStore,
                () => new PartsDetailsViewModel(
                    CreatePartsMainNavigationService(),
                    CreatePartsEditNavigationService(),
                    CreatePartsAddNavigationService()
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
                    CreatePartsAddNavigationService(),
                    CreatePartsDetailsNavigationService())
            );
        }
    }
}
