using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesAddViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public LinesAddViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel,
            INavigationService<LinesEditViewModel> linesEditViewModel,
            INavigationService<LinesDetailsViewModel> linesDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);
            NavigateEditCommand = new NavigateCommand<LinesEditViewModel>(linesEditViewModel);
            NavigateDetailsCommand = new NavigateCommand<LinesDetailsViewModel>(linesDetailsViewModel);
        }
    }
}
