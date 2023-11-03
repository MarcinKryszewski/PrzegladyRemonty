using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
namespace PrzegladyRemonty.Features.Parts
{
    public class PartsEditViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public PartsEditViewModel(
            INavigationService<PartsMainViewModel> partsMainViewModel,
            INavigationService<PartsAddViewModel> partsAddViewModel,
            INavigationService<PartsDetailsViewModel> partsDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<PartsMainViewModel>(partsMainViewModel);
            NavigateAddCommand = new NavigateCommand<PartsAddViewModel>(partsAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<PartsDetailsViewModel>(partsDetailsViewModel);
        }
    }
}
