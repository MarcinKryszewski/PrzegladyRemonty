using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }

        public AreasDetailsViewModel(
            INavigationService<AreasMainViewModel> areasMainViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<AreasMainViewModel>(areasMainViewModel);
        }
    }
}
