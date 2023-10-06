using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public TransportersViewModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            INavigationService<TransportersMainViewModel> TransportersMainNavigationService = CreateTransportersMainNavigationService();
            TransportersMainNavigationService.Navigate();

        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private INavigationService<TransportersMainViewModel> CreateTransportersMainNavigationService()
        {
            return new DefaultNavigationService<TransportersMainViewModel>
            (
                _navigationStore,
                () => new TransportersMainViewModel(
                    CreateTransportersEditNavigationService(),
                    CreateTransportersAddNavigationService(),
                    CreateTransportersDetailsNavigationService())
            );
        }
        private INavigationService<TransportersAddViewModel> CreateTransportersAddNavigationService()
        {
            return new DefaultNavigationService<TransportersAddViewModel>
            (
                _navigationStore,
                () => new TransportersAddViewModel(
                    CreateTransportersMainNavigationService(),
                    CreateTransportersEditNavigationService(),
                    CreateTransportersDetailsNavigationService()
                )
            );
        }
        private INavigationService<TransportersDetailsViewModel> CreateTransportersDetailsNavigationService()
        {
            return new DefaultNavigationService<TransportersDetailsViewModel>
            (
                _navigationStore,
                () => new TransportersDetailsViewModel(
                    CreateTransportersMainNavigationService(),
                    CreateTransportersEditNavigationService(),
                    CreateTransportersAddNavigationService()
                )
            );
        }
        private INavigationService<TransportersEditViewModel> CreateTransportersEditNavigationService()
        {
            return new DefaultNavigationService<TransportersEditViewModel>
            (
                _navigationStore,
                () => new TransportersEditViewModel(
                    CreateTransportersMainNavigationService(),
                    CreateTransportersAddNavigationService(),
                    CreateTransportersDetailsNavigationService())
            );
        }
    }
}
