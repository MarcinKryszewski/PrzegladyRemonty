using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public AreasViewModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            INavigationService<AreasMainViewModel> areasMainNavigationService = CreateAreasMainNavigationService();
            areasMainNavigationService.Navigate();

        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private INavigationService<AreasMainViewModel> CreateAreasMainNavigationService()
        {
            return new DefaultNavigationService<AreasMainViewModel>
            (
                _navigationStore,
                () => new AreasMainViewModel(
                    CreateAreasEditNavigationService(),
                    CreateAreasAddNavigationService(),
                    CreateAreasDetailsNavigationService())
            );
        }
        private INavigationService<AreasAddViewModel> CreateAreasAddNavigationService()
        {
            return new DefaultNavigationService<AreasAddViewModel>
            (
                _navigationStore,
                () => new AreasAddViewModel(
                    CreateAreasMainNavigationService(),
                    CreateAreasEditNavigationService(),
                    CreateAreasDetailsNavigationService()
                )
            );
        }
        private INavigationService<AreasDetailsViewModel> CreateAreasDetailsNavigationService()
        {
            return new DefaultNavigationService<AreasDetailsViewModel>
            (
                _navigationStore,
                () => new AreasDetailsViewModel(
                    CreateAreasMainNavigationService(),
                    CreateAreasEditNavigationService(),
                    CreateAreasAddNavigationService()
                )
            );
        }
        private INavigationService<AreasEditViewModel> CreateAreasEditNavigationService()
        {
            return new DefaultNavigationService<AreasEditViewModel>
            (
                _navigationStore,
                () => new AreasEditViewModel(
                    CreateAreasMainNavigationService(),
                    CreateAreasAddNavigationService(),
                    CreateAreasDetailsNavigationService())
            );
        }
    }
}