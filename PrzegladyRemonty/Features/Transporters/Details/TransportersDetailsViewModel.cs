using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }

        public TransportersDetailsViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            INavigationService<TransportersEditViewModel> transportersEditViewModel,
            INavigationService<TransportersAddViewModel> transportersAddViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<TransportersMainViewModel>(transportersMainViewModel);
            NavigateEditCommand = new NavigateCommand<TransportersEditViewModel>(transportersEditViewModel);
            NavigateAddCommand = new NavigateCommand<TransportersAddViewModel>(transportersAddViewModel);
        }
    }
}
