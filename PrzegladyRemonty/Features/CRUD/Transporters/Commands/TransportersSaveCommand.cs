using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersSaveCommand : CommandBase
    {
        private readonly TransportersDetailsViewModel _viewModel;

        public TransportersSaveCommand(TransportersDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}
