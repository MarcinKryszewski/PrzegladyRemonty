using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ActionsCategoriesViewModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            INavigationService<ActionsCategoriesMainViewModel> ActionsCategoriesMainNavigationService = CreateActionsCategoriesMainNavigationService();
            ActionsCategoriesMainNavigationService.Navigate();

        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private INavigationService<ActionsCategoriesMainViewModel> CreateActionsCategoriesMainNavigationService()
        {
            return new DefaultNavigationService<ActionsCategoriesMainViewModel>
            (
                _navigationStore,
                () => new ActionsCategoriesMainViewModel(
                    CreateActionsCategoriesEditNavigationService(),
                    CreateActionsCategoriesAddNavigationService(),
                    CreateActionsCategoriesDetailsNavigationService())
            );
        }
        private INavigationService<ActionsCategoriesAddViewModel> CreateActionsCategoriesAddNavigationService()
        {
            return new DefaultNavigationService<ActionsCategoriesAddViewModel>
            (
                _navigationStore,
                () => new ActionsCategoriesAddViewModel(
                    CreateActionsCategoriesMainNavigationService(),
                    CreateActionsCategoriesEditNavigationService(),
                    CreateActionsCategoriesDetailsNavigationService()
                )
            );
        }
        private INavigationService<ActionsCategoriesDetailsViewModel> CreateActionsCategoriesDetailsNavigationService()
        {
            return new DefaultNavigationService<ActionsCategoriesDetailsViewModel>
            (
                _navigationStore,
                () => new ActionsCategoriesDetailsViewModel(
                    CreateActionsCategoriesMainNavigationService(),
                    CreateActionsCategoriesEditNavigationService(),
                    CreateActionsCategoriesAddNavigationService()
                )
            );
        }
        private INavigationService<ActionsCategoriesEditViewModel> CreateActionsCategoriesEditNavigationService()
        {
            return new DefaultNavigationService<ActionsCategoriesEditViewModel>
            (
                _navigationStore,
                () => new ActionsCategoriesEditViewModel(
                    CreateActionsCategoriesMainNavigationService(),
                    CreateActionsCategoriesAddNavigationService(),
                    CreateActionsCategoriesDetailsNavigationService())
            );
        }
    }
}
