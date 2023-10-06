using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesEditViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public LinesEditViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel,
            INavigationService<LinesAddViewModel> linesAddViewModel,
            INavigationService<LinesDetailsViewModel> linesDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);
            NavigateAddCommand = new NavigateCommand<LinesAddViewModel>(linesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<LinesDetailsViewModel>(linesDetailsViewModel);
        }
    }
}
