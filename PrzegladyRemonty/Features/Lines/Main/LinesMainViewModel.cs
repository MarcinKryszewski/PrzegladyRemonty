using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesMainViewModel : ViewModelBase
    {
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public LinesMainViewModel(
            INavigationService<LinesEditViewModel> linesEditViewModel,
            INavigationService<LinesAddViewModel> linesAddViewModel,
            INavigationService<LinesDetailsViewModel> linesDetailsViewModel
            )
        {
            NavigateEditCommand = new NavigateCommand<LinesEditViewModel>(linesEditViewModel);
            NavigateAddCommand = new NavigateCommand<LinesAddViewModel>(linesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<LinesDetailsViewModel>(linesDetailsViewModel);
        }
    }
}
