using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersEditViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public TransportersEditViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            INavigationService<TransportersAddViewModel> transportersAddViewModel,
            INavigationService<TransportersDetailsViewModel> transportersDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<TransportersMainViewModel>(transportersMainViewModel);
            NavigateAddCommand = new NavigateCommand<TransportersAddViewModel>(transportersAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<TransportersDetailsViewModel>(transportersDetailsViewModel);
        }
    }
}
