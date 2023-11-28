using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersPartsAddCommand : CommandBase
    {
        private readonly TransporterPartProvider _provider;
        private TransportersDetailsViewModel _viewModel;

        public TransportersPartsAddCommand(TransporterPartProvider provider, TransportersDetailsViewModel viewModel)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Transporter.AddPart(_viewModel.SelectedPart);
            _provider.Create(new TransporterPart(_viewModel.Transporter.Id, _viewModel.SelectedPart.Id, 1, "szt"));
            _viewModel.GetTransporterParts();
        }
    }
}