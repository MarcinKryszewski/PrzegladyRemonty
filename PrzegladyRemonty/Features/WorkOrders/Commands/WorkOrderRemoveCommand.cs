using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.WorkOrders
{
    public class WorkOrderRemoveCommand : CommandBase
    {
        private readonly WorkOrdersListViewModel _viewModel;
        private readonly WorkOrderProvider _provider;

        public WorkOrderRemoveCommand(WorkOrdersListViewModel viewModel, WorkOrderProvider provider)
        {
            _viewModel = viewModel;
            _provider = provider;
        }

        public override void Execute(object parameter)
        {
            _viewModel.SelectedWorkOrder.SetStatus("Anulowane");
            _provider.Update(_viewModel.SelectedWorkOrder);
            _viewModel.SetWorkOrders();
        }
    }
}