using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesEditCommand : CommandBase
    {
        readonly LineProvider _lineProvider;
        readonly LinesEditViewModel _linesEditViewModel;
        public LinesEditCommand(LinesEditViewModel linesEditViewModel, LineProvider lineProvider)
        {
            _lineProvider = lineProvider;
            _linesEditViewModel = linesEditViewModel;
        }

        public override void Execute(object parameter)
        {
            Line line = new(
                _linesEditViewModel.LineId,
                _linesEditViewModel.LineName,
                _linesEditViewModel.LineActive
                );
            line.Edit(_lineProvider);
            _linesEditViewModel.NavigateMainCommand.Execute(null);
        }
    }
}