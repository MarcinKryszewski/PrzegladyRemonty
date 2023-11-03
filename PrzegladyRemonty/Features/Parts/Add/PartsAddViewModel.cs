using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsAddViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public PartsAddViewModel(
            INavigationService<PartsMainViewModel> partsMainViewModel,
            INavigationService<PartsEditViewModel> partsEditViewModel,
            INavigationService<PartsDetailsViewModel> partsDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<PartsMainViewModel>(partsMainViewModel);
            NavigateEditCommand = new NavigateCommand<PartsEditViewModel>(partsEditViewModel);
            NavigateDetailsCommand = new NavigateCommand<PartsDetailsViewModel>(partsDetailsViewModel);
        }
    }
}
