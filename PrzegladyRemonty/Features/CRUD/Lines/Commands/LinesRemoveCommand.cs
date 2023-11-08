using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesRemoveCommand : AsyncCommandBase
    {
        private readonly LineProvider _lineProvider;
        private readonly LinesMainViewModel _linesMainViewModel;
        public LinesRemoveCommand(LinesMainViewModel linesMainViewModel, LineProvider lineProvider)
        {
            _lineProvider = lineProvider;
            _linesMainViewModel = linesMainViewModel;
            _linesMainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _linesMainViewModel.IsLineSelected;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Line line = _linesMainViewModel.SelectedLineStore.Line;
            await line.Delete(_lineProvider);
            _linesMainViewModel.LinesLoadCommand.Execute(null);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LinesMainViewModel.IsLineSelected))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
