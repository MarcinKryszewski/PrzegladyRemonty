using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Stores;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class CreateWorkOrderCommand : AsyncCommandBase
    {
        private readonly WorkOrderProvider _workOrderProvider;
        private readonly WorkOrderMaintenanceProvider _workOrderMaintenanceProvider;
        private readonly MaintenanceProvider _maintenanceProvider;
        private readonly TransportersListStore _transportersCart;
        private readonly ObservableCollection<TransporterAction> _transporterActionsAll;
        private readonly UserStore _user;
        private readonly MaintenanceCreateViewModel _viewModel;

        public CreateWorkOrderCommand(
            MaintenanceCreateViewModel viewModel,
            WorkOrderProvider workOrderProvider,
            WorkOrderMaintenanceProvider workOrderMaintenanceProvider,
            MaintenanceProvider maintenanceProvider,
            TransportersListStore transportersCart,
            ObservableCollection<TransporterAction> transporterActionsAll,
            UserStore user
            )
        {
            _workOrderProvider = workOrderProvider;
            _workOrderMaintenanceProvider = workOrderMaintenanceProvider;
            _maintenanceProvider = maintenanceProvider;
            _transportersCart = transportersCart;
            _transporterActionsAll = transporterActionsAll;
            _user = user;
            _viewModel = viewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            var result = from transporter in _transportersCart.Transporters
                         join transporterAction in _transporterActionsAll on transporter.Id equals transporterAction.TransporterId
                         select transporterAction;
            ObservableCollection<int> maintenanceIds = new();

            int workOrderId = _workOrderProvider.CreateAndReturnId(new WorkOrder(DateTime.Now.ToString("yyyy-MM-dd"), _user.User.Id));
            foreach (TransporterAction transporterAction in result)
            {
                int maintenanceId = _maintenanceProvider.CreateAndReturnId(new Models.Maintenance(transporterAction.Id));
                maintenanceIds.Add(maintenanceId);
            }

            foreach (int maintenanceId in maintenanceIds)
            {
                _workOrderMaintenanceProvider.Create(new WorkOrderMaintenance(workOrderId, maintenanceId));
            }

            _viewModel.WorkOrderNumber = workOrderId.ToString();


            return Task.CompletedTask;
        }
    }
}
