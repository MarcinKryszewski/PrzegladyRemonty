using System;
using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.WorkOrders.Stores;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;

namespace PrzegladyRemonty.Features.WorkOrders
{
    public class WorkOrderSaveCommand : CommandBase
    {
        private IServiceProvider _services;
        private WorkOrdersConfirmViewModel _viewModel;
        private WorkOrder _workOrder;


        public WorkOrderSaveCommand(IServiceProvider services, WorkOrdersConfirmViewModel viewModel)
        {
            _services = services;
            _viewModel = viewModel;
            _workOrder = _services.GetRequiredService<SelectedWorkOrder>().WorkOrder;
        }

        public override void Execute(object parameter)
        {
            MaintenanceProvider provider = _services.GetRequiredService<MaintenanceProvider>();

            foreach (Models.Maintenance maintenance in _workOrder.Maintenances)
            {
                provider.Update(new Models.Maintenance(
                    maintenance.Id,
                    _viewModel.DateText,
                    _viewModel.Person.Id,
                    maintenance.MaintenanceActionId,
                    true,
                    maintenance.Description
                ));
            }

            _services.GetRequiredService<NavigationService<WorkOrdersListViewModel>>().Navigate();
        }
    }
}