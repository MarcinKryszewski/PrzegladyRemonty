using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsMainViewModel : ViewModelBase
    {
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public PartsMainViewModel(
            INavigationService<PartsEditViewModel> partsEditViewModel,
            INavigationService<PartsAddViewModel> partsAddViewModel,
            INavigationService<PartsDetailsViewModel> partsDetailsViewModel
            )
        {
            NavigateEditCommand = new NavigateCommand<PartsEditViewModel>(partsEditViewModel);
            NavigateAddCommand = new NavigateCommand<PartsAddViewModel>(partsAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<PartsDetailsViewModel>(partsDetailsViewModel);
        }
    }
}
