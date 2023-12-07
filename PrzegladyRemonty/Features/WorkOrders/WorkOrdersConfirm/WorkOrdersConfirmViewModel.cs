using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.WorkOrders.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrzegladyRemonty.Features.WorkOrders
{
    public class WorkOrdersConfirmViewModel : ViewModelBase
    {
        private ObservableCollection<Models.Maintenance> _maintenances;

        public IEnumerable<Models.Maintenance> Maintenances => _maintenances;

        public WorkOrdersConfirmViewModel(IServiceProvider services)
        {
            _maintenances = new ObservableCollection<Models.Maintenance>(services.GetRequiredService<SelectedWorkOrder>().WorkOrder.Maintenances);
        }
    }
}