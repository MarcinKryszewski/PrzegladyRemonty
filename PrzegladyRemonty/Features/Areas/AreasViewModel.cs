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
            return new AreasNavigationService<AreasMainViewModel>
            (
                _navigationStore,
                () => new AreasMainViewModel(CreateAreasEditNavigationService())
            );
        }
        private INavigationService<AreasAddViewModel> CreateAreasAddNavigationService()
        {
            return new AreasNavigationService<AreasAddViewModel>
            (
                _navigationStore,
                () => new AreasAddViewModel()
            );
        }
        private INavigationService<AreasDetailsViewModel> CreateAreasDetailsNavigationService()
        {
            return new AreasNavigationService<AreasDetailsViewModel>
            (
                _navigationStore,
                () => new AreasDetailsViewModel()
            );
        }
        private INavigationService<AreasEditViewModel> CreateAreasEditNavigationService()
        {
            return new AreasNavigationService<AreasEditViewModel>
            (
                _navigationStore,
                () => new AreasEditViewModel()
            );
        }
    }
}