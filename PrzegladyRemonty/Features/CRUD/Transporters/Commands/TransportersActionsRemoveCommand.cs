using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersActionsRemoveCommand : CommandBase
    {
        private readonly TransporterActionProvider _provider;
        private readonly TransportersDetailsViewModel _viewModel;

        public TransportersActionsRemoveCommand(TransporterActionProvider provider, TransportersDetailsViewModel viewModel)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Transporter.RemoveAction(_viewModel.SelectedTransporterAction.Action);
            _provider.Delete(_viewModel.SelectedTransporterAction.Id).Wait();
            _viewModel.GetTransporterActions();
        }
    }
}