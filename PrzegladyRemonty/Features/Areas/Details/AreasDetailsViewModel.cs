using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }

        public AreasDetailsViewModel(
            INavigationService<AreasMainViewModel> areasMainViewModel,
            INavigationService<AreasEditViewModel> areasEditViewModel,
            INavigationService<AreasAddViewModel> areasAddViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<AreasMainViewModel>(areasMainViewModel);
            NavigateEditCommand = new NavigateCommand<AreasEditViewModel>(areasEditViewModel);
            NavigateAddCommand = new NavigateCommand<AreasAddViewModel>(areasAddViewModel);
        }
    }
}
