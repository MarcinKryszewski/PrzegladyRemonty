using System.Collections.ObjectModel;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersActionsRemoveCommand : CommandBase
    {
        private TransportersDetailsViewModel _viewModel;

        public TransportersActionsRemoveCommand(TransportersDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            //_viewModel.ActionsList.Remove(_viewModel.SelectedAction);
        }
    }
}