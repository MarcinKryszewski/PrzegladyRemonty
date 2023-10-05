using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasAddViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public AreasAddViewModel(
            INavigationService<AreasMainViewModel> areasMainViewModel,
            INavigationService<AreasEditViewModel> areasEditViewModel,
            INavigationService<AreasDetailsViewModel> areasDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<AreasMainViewModel>(areasMainViewModel);
            NavigateEditCommand = new NavigateCommand<AreasEditViewModel>(areasEditViewModel);
            NavigateDetailsCommand = new NavigateCommand<AreasDetailsViewModel>(areasDetailsViewModel);
        }
    }
}
