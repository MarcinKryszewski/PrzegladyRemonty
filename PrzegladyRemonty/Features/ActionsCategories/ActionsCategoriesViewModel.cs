using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IHost _databaseHost;
        private readonly SelectedActionCategory _transproterType;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ActionsCategoriesViewModel(IHost databaseHost)
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _databaseHost = databaseHost;
            _transproterType = new SelectedActionCategory();

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
                    CreateActionsCategoriesDetailsNavigationService(),
                    _transproterType,
                    _databaseHost)
            );
        }

        private INavigationService<ActionsCategoriesAddViewModel> CreateActionsCategoriesAddNavigationService()
        {
            return new DefaultNavigationService<ActionsCategoriesAddViewModel>
            (
                _navigationStore,
                () => new ActionsCategoriesAddViewModel(
                    CreateActionsCategoriesMainNavigationService(),
                    _databaseHost
                )
            );
        }

        private INavigationService<ActionsCategoriesDetailsViewModel> CreateActionsCategoriesDetailsNavigationService()
        {
            return new DefaultNavigationService<ActionsCategoriesDetailsViewModel>
            (
                _navigationStore,
                () => new ActionsCategoriesDetailsViewModel(
                    CreateActionsCategoriesMainNavigationService()
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
                    _transproterType,
                    _databaseHost)
            );
        }


    }
}
