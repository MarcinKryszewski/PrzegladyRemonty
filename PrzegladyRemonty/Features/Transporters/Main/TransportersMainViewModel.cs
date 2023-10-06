using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersMainViewModel : ViewModelBase
    {
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public TransportersMainViewModel(
            INavigationService<TransportersEditViewModel> transportersEditViewModel,
            INavigationService<TransportersAddViewModel> transportersAddViewModel,
            INavigationService<TransportersDetailsViewModel> transportersDetailsViewModel
            )
        {
            NavigateEditCommand = new NavigateCommand<TransportersEditViewModel>(transportersEditViewModel);
            NavigateAddCommand = new NavigateCommand<TransportersAddViewModel>(transportersAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<TransportersDetailsViewModel>(transportersDetailsViewModel);
        }
    }
}
