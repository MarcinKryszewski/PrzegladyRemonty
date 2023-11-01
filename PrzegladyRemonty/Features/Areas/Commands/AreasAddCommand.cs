using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasAddCommand : CommandBase
    {
        private AreasAddViewModel _viewModel;
        private AreaProvider _provider;

        public AreasAddCommand(AreasAddViewModel viewModel, AreaProvider provider)
        {
            _viewModel = viewModel;
            _provider = provider;
        }


        public override void Execute(object parameter)
        {
            string areaName = _viewModel.Name;
            int lineId = _viewModel.Line.Id;

            Area area = new(areaName, lineId);
            area.Add(_provider);
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}
