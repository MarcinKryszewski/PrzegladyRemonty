using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesEditViewModel : ViewModelBase
    {
        private string _lineName;
        private bool _lineActive;
        private int _lineId;

        public int LineId
        {
            get => _lineId;
            set
            {
                _lineId = value;
            }
        }
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

        public ICommand NavigateMainCommand { get; }
        public ICommand EditCommand { get; }

        public LinesEditViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel,
            SelectedLine selectedLine,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);

            _lineId = selectedLine.Line.Id;
            _lineName = selectedLine.Line.Name;
            _lineActive = selectedLine.Line.Active;

            EditCommand = new LinesEditCommand(this, databaseHost.Services.GetRequiredService<LineProvider>());
        }
    }
}