using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasEditViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public AreasEditViewModel(
            INavigationService<AreasMainViewModel> areasMainViewModel,
            INavigationService<AreasAddViewModel> areasAddViewModel,
            INavigationService<AreasDetailsViewModel> areasDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<AreasMainViewModel>(areasMainViewModel);
            NavigateAddCommand = new NavigateCommand<AreasAddViewModel>(areasAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<AreasDetailsViewModel>(areasDetailsViewModel);
        }
    }
}
