using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersAddCommand : CommandBase
    {
        private readonly TransportersAddViewModel _viewModel;
        private readonly TransporterProvider _provider;

        public TransportersAddCommand(TransportersAddViewModel viewModel, TransporterProvider provider)
        {
            _viewModel = viewModel;
            _provider = provider;
        }

        public override void Execute(object parameter)
        {
            string transporterName = _viewModel.Name;
            int areaId = _viewModel.Area.Id;
            int transporterTypeId = _viewModel.TransporterType.Id;

            Transporter transporter = new Transporter(transporterName, areaId, transporterTypeId);
            transporter.Add(_provider);
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}
