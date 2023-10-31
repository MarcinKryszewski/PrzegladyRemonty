using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesRemoveCommand : CommandBase
    {
        readonly LineProvider _lineProvider;
        readonly LinesMainViewModel _linesMainViewModel;
        public LinesRemoveCommand(LinesMainViewModel linesMainViewModel, LineProvider lineProvider)
        {
            _lineProvider = lineProvider;
            _linesMainViewModel = linesMainViewModel;
        }

        public override void Execute(object parameter)
        {
            Line line = _linesMainViewModel.LineStore.Line;
            line.Delete(_lineProvider);
            _linesMainViewModel.LinesLoadCommand.Execute(null);
        }
    }
}
