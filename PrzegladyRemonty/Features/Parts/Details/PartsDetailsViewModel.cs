using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
namespace PrzegladyRemonty.Features.Parts
{
    public class PartsDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }

        public PartsDetailsViewModel(
            INavigationService<PartsMainViewModel> partsMainViewModel,
            INavigationService<PartsEditViewModel> partsEditViewModel,
            INavigationService<PartsAddViewModel> partsAddViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<PartsMainViewModel>(partsMainViewModel);
            NavigateEditCommand = new NavigateCommand<PartsEditViewModel>(partsEditViewModel);
            NavigateAddCommand = new NavigateCommand<PartsAddViewModel>(partsAddViewModel);
        }
    }
}
