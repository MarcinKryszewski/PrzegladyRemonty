using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesAddCommand : CommandBase
    {
        readonly LineProvider _lineProvider;
        readonly LinesAddViewModel _linesAddViewModel;
        public LinesAddCommand(LinesAddViewModel linesAddViewModel, LineProvider lineProvider)
        {
            _lineProvider = lineProvider;
            _linesAddViewModel = linesAddViewModel;
        }

        public override void Execute(object parameter)
        {
            string lineName = _linesAddViewModel.Name;

            Line line = new(lineName);
            line.Add(_lineProvider);
            _linesAddViewModel.NavigateMainCommand.Execute(null);
        }
    }
}