using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersAddViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public TransportersAddViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            INavigationService<TransportersEditViewModel> transportersEditViewModel,
            INavigationService<TransportersDetailsViewModel> transportersDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<TransportersMainViewModel>(transportersMainViewModel);
            NavigateEditCommand = new NavigateCommand<TransportersEditViewModel>(transportersEditViewModel);
            NavigateDetailsCommand = new NavigateCommand<TransportersDetailsViewModel>(transportersDetailsViewModel);
        }
    }
}
