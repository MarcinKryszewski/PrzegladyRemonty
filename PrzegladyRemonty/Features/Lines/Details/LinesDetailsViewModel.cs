using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }

        public LinesDetailsViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel,
            INavigationService<LinesEditViewModel> linesEditViewModel,
            INavigationService<LinesAddViewModel> linesAddViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);
            NavigateEditCommand = new NavigateCommand<LinesEditViewModel>(linesEditViewModel);
            NavigateAddCommand = new NavigateCommand<LinesAddViewModel>(linesAddViewModel);
        }
    }
}
