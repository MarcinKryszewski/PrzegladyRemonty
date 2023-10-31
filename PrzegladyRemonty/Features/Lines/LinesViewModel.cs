using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IHost _databaseHost;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public LinesViewModel(IHost databaseHost)
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            INavigationService<LinesMainViewModel> LinesMainNavigationService = CreateLinesMainNavigationService();
            LinesMainNavigationService.Navigate();
            _databaseHost = databaseHost;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private INavigationService<LinesMainViewModel> CreateLinesMainNavigationService()
        {
            return new DefaultNavigationService<LinesMainViewModel>
            (
                _navigationStore,
                () => new LinesMainViewModel(
                    CreateLinesEditNavigationService(),
                    CreateLinesAddNavigationService(),
                    CreateLinesDetailsNavigationService())
            );
        }
        private INavigationService<LinesAddViewModel> CreateLinesAddNavigationService()
        {
            return new DefaultNavigationService<LinesAddViewModel>
            (
                _navigationStore,
                () => new LinesAddViewModel(
                    CreateLinesMainNavigationService(),
                    CreateLinesEditNavigationService(),
                    CreateLinesDetailsNavigationService(),
                    _databaseHost
                )
            );
        }
        private INavigationService<LinesDetailsViewModel> CreateLinesDetailsNavigationService()
        {
            return new DefaultNavigationService<LinesDetailsViewModel>
            (
                _navigationStore,
                () => new LinesDetailsViewModel(
                    CreateLinesMainNavigationService(),
                    CreateLinesEditNavigationService(),
                    CreateLinesAddNavigationService()
                )
            );
        }
        private INavigationService<LinesEditViewModel> CreateLinesEditNavigationService()
        {
            return new DefaultNavigationService<LinesEditViewModel>
            (
                _navigationStore,
                () => new LinesEditViewModel(
                    CreateLinesMainNavigationService(),
                    CreateLinesAddNavigationService(),
                    CreateLinesDetailsNavigationService())
            );
        }
    }
}
