using System;
using System.Collections.ObjectModel;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.WorkOrders
{
    public class WorkOrdersListViewModel : ViewModelBase
    {
        private ObservableCollection<WorkOrder> _workOrders;

        public WorkOrdersListViewModel(IServiceProvider workOrdersServices)
        {

        }
    }
}