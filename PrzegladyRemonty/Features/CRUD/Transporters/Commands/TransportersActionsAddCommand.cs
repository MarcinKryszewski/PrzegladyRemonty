using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersActionsAddCommand : CommandBase
    {
        private readonly TransporterActionProvider _provider;
        private TransportersDetailsViewModel _viewModel;

        public TransportersActionsAddCommand(TransporterActionProvider provider, TransportersDetailsViewModel viewModel)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Transporter.AddAction(_viewModel.SelectedAction);
            _provider.Create(new TransporterAction(_viewModel.Transporter.Id, _viewModel.SelectedAction.Id, 3, "M"));
            _viewModel.GetTransporterActions();
        }
    }
}