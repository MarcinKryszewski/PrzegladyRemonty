using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }

        public LinesDetailsViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);
        }
    }
}
