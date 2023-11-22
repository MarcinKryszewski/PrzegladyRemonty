using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Maintenance.MaintenanceCreate.Commands
{
    public class CreateWorkOrderCommand : AsyncCommandBase
    {
        private readonly WorkOrderProvider _workOrderProvider;
        private readonly WorkOrderMaintenanceProvider _workOrderMaintenanceProvider;
        private readonly MaintenanceProvider _maintenanceProvider;
        private readonly TransportersListStore _transportersCart;
        private readonly ObservableCollection<TransporterAction> _transporterActions;

        public CreateWorkOrderCommand(WorkOrderProvider workOrderProvider, WorkOrderMaintenanceProvider workOrderMaintenanceProvider, MaintenanceProvider maintenanceProvider, TransportersListStore transportersCart, ObservableCollection<TransporterAction> transporterActions)
        {
            _workOrderProvider = workOrderProvider;
            _workOrderMaintenanceProvider = workOrderMaintenanceProvider;
            _maintenanceProvider = maintenanceProvider;
            _transportersCart = transportersCart;
            _transporterActions = transporterActions;
        }

        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
