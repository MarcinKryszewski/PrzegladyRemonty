using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasEditCommand : CommandBase
    {
        readonly AreaProvider _areaProvider;
        readonly AreasEditViewModel _areasEditViewModel;
        public AreasEditCommand(AreasEditViewModel areasEditViewModel, AreaProvider areaProvider)
        {
            _areaProvider = areaProvider;
            _areasEditViewModel = areasEditViewModel;
        }

        public override void Execute(object parameter)
        {
            Area area = new(
                _areasEditViewModel.Id,
                _areasEditViewModel.Name,
                _areasEditViewModel.Active,
                _areasEditViewModel.Line.Id
                );
            area.Edit(_areaProvider);
            _areasEditViewModel.NavigateMainCommand.Execute(null);
        }
    }
}