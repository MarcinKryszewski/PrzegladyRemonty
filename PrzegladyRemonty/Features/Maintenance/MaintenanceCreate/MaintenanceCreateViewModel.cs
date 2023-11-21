using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Shared.ViewModels;
using System;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class MaintenanceCreateViewModel : ViewModelBase
    {
        private bool _workOrderNumberCreated;
        private readonly TransportersListStore _transportersCart;

        public string WorkOrderNumber = "555";
        public bool WorkOrderNumberCreated => _workOrderNumberCreated;
        public TransportersListStore TransportersCart => _transportersCart;

        public MaintenanceCreateViewModel(IServiceProvider maintenanceServices)
        {
            _transportersCart = maintenanceServices.GetRequiredService<TransportersListStore>();
        }
    }
}
