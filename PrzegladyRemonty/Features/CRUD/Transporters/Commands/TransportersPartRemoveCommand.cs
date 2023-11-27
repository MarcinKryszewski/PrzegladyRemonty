using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersPartsRemoveCommand : CommandBase
    {
        private TransportersDetailsViewModel _viewModel;

        public TransportersPartsRemoveCommand(TransportersDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            //_viewModel.PartsList.Remove(_viewModel.SelectedPart);
        }
    }
}