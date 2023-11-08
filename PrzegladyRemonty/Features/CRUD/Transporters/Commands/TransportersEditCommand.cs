using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersEditCommand : CommandBase
    {
        readonly TransportersEditViewModel _viewModel;
        readonly TransporterProvider _provider;

        public TransportersEditCommand(TransportersEditViewModel viewModel, TransporterProvider provider)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Transporter transporter = new(
                _viewModel.Id,
                _viewModel.Name,
                _viewModel.Active,
                _viewModel.Area.Id,
                _viewModel.TransporterType.Id);

            transporter.Edit(_provider);
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}
