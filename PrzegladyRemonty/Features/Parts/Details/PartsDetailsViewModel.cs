using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }

        public PartsDetailsViewModel(
            INavigationService<PartsMainViewModel> partsMainViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<PartsMainViewModel>(partsMainViewModel);
        }
    }
}
