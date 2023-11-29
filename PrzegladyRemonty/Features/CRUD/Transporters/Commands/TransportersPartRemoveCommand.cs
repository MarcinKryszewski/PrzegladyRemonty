using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersPartsRemoveCommand : CommandBase
    {
        private readonly TransporterPartProvider _provider;
        private readonly TransportersDetailsViewModel _viewModel;

        public TransportersPartsRemoveCommand(TransporterPartProvider provider, TransportersDetailsViewModel viewModel)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Transporter.RemovePart(_viewModel.SelectedTransporterPart.Part);
            _provider.Delete(_viewModel.SelectedTransporterPart.Id).Wait();
            _viewModel.GetTransporterParts();
        }
    }
}