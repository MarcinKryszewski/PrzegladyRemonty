using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.WorkOrders.Stores;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.WorkOrders
{
    public class WorkOrdersListViewModel : ViewModelBase
    {
        private readonly IServiceProvider _services;
        private readonly ObservableCollection<WorkOrder> _workOrders;
        private WorkOrder _selectedWorkOrder;
        private readonly SelectedWorkOrder _workOrderStore;
        public WorkOrder SelectedWorkOrder
        {
            get => _selectedWorkOrder;
            set
            {
                _selectedWorkOrder = value;
                _workOrderStore.WorkOrder = value;
                OnPropertyChanged(nameof(SelectedWorkOrder));
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public IEnumerable<WorkOrder> WorkOrders => _workOrders;
        public bool IsSelected => _selectedWorkOrder != null;
        public ICommand NavigateDetailsCommand { get; }
        public ICommand RemoveCommand { get; }


        public WorkOrdersListViewModel(IServiceProvider services)
        {
            _services = services;
            _workOrderStore = services.GetRequiredService<SelectedWorkOrder>();
            _workOrders = new();
            SetWorkOrders();

            NavigateDetailsCommand = new NavigateCommand<WorkOrdersConfirmViewModel>(_services.GetRequiredService<NavigationService<WorkOrdersConfirmViewModel>>());
            RemoveCommand = new WorkOrderRemoveCommand(this, _services.GetRequiredService<WorkOrderProvider>());
        }

        public void SetWorkOrders()
        {
            _workOrders.Clear();
            foreach (WorkOrder workOrder in _services.GetRequiredService<WorkOrderProvider>().GetAllActive().Result)
            {
                workOrder.SetCreator(_services.GetRequiredService<PersonProvider>().GetById(workOrder.CreatedBy));

                IEnumerable<WorkOrderMaintenance> workOrderMaintenances = GetWorkOrderMaintenance().Where(b => b.WorkOrder == workOrder.Id);
                IEnumerable<Models.Maintenance> maintenances = GetMaintenances().Where(c => workOrderMaintenances.Any(b => b.Maintenance == c.Id));

                foreach (Models.Maintenance maintenance in maintenances)
                {
                    workOrder.AddMaintenance(maintenance);
                }

                _workOrders.Add(workOrder);
            }
        }

        public ObservableCollection<Models.Maintenance> GetMaintenances()
        {
            return new ObservableCollection<Models.Maintenance>(_services.GetRequiredService<MaintenanceProvider>().GetAll().Result);
        }

        public ObservableCollection<WorkOrderMaintenance> GetWorkOrderMaintenance()
        {
            return new ObservableCollection<WorkOrderMaintenance>(_services.GetRequiredService<WorkOrderMaintenanceProvider>().GetAll().Result);
        }

    }
}