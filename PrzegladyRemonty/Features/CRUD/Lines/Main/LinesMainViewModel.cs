using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Commands.Load;
using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesMainViewModel : ViewModelBase, ILineUpdate
    {
        private readonly ObservableCollection<Line> _lines;
        private readonly IHost _databaseHost;
        private Line _selectedLine;
        private readonly SelectedLine _lineStore;

        public IEnumerable<Line> Lines => _lines;
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }
        public ICommand LinesLoadCommand { get; }
        public ICommand LinesRemoveCommand { get; }

        public Line SelectedLine
        {
            get => _selectedLine;
            set
            {
                _selectedLine = value;
                _lineStore.Line = value;
                OnPropertyChanged(nameof(SelectedLine));
                OnPropertyChanged(nameof(IsLineSelected));
            }
        }

        public SelectedLine SelectedLineStore => _lineStore;
        public bool IsLineSelected => _selectedLine != null;

        public LinesMainViewModel(
            INavigationService<LinesEditViewModel> linesEditViewModel,
            INavigationService<LinesAddViewModel> linesAddViewModel,
            INavigationService<LinesDetailsViewModel> linesDetailsViewModel,
            SelectedLine selectedLine,
            IHost databaseHost
            )
        {
            NavigateEditCommand = new NavigateCommand<LinesEditViewModel>(linesEditViewModel);
            NavigateAddCommand = new NavigateCommand<LinesAddViewModel>(linesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<LinesDetailsViewModel>(linesDetailsViewModel);

            _databaseHost = databaseHost;
            _lines = new ObservableCollection<Line>();
            _lineStore = selectedLine;
            LinesLoadCommand = new LinesLoadCommand(this, _databaseHost.Services.GetRequiredService<LineProvider>());
            LinesRemoveCommand = new LinesRemoveCommand(this, _databaseHost.Services.GetRequiredService<LineProvider>());

            LinesLoadCommand.Execute(null);
        }

        public void UpdateLines(IEnumerable<Line> lines)
        {
            _lines.Clear();
            foreach (Line line in lines)
            {
                _lines.Add(line);
            }
        }
    }
}
