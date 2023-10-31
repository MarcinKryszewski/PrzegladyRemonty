using System.Windows.Input;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesEditViewModel : ViewModelBase
    {
        private readonly Line _line;
        private string _lineName;
        private bool _lineActive;

        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public string LineName
        {
            get => _lineName;
            set
            {
                _lineName = value;
                OnPropertyChanged(nameof(LineName));
            }
        }
        public bool LineActive
        {
            get => _lineActive;
            set
            {
                _lineActive = value;
                OnPropertyChanged(nameof(LineActive));
            }
        }

        public ICommand EditCommand { get; }

        public LinesEditViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel,
            INavigationService<LinesAddViewModel> linesAddViewModel,
            INavigationService<LinesDetailsViewModel> linesDetailsViewModel,
            Line line
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);
            NavigateAddCommand = new NavigateCommand<LinesAddViewModel>(linesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<LinesDetailsViewModel>(linesDetailsViewModel);

            _line = line;
            _lineName = _line.Name;
            _lineActive = _line.Active;

            EditCommand = new LinesEditCommand
        }
    }
}
