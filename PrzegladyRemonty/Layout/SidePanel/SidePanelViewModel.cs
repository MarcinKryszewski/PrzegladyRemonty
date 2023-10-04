﻿using PrzegladyRemonty.Features.Areas;
using PrzegladyRemonty.Features.Dashboard;
using PrzegladyRemonty.Features.Lines;
using PrzegladyRemonty.Features.Maintenance;
using PrzegladyRemonty.Features.Transporters;
using PrzegladyRemonty.Features.WorkOrders;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Layout.SidePanel
{
    public class SidePanelViewModel : ViewModelBase
    {
        public ICommand NavigateAreasCommand { get; }
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateLinesCommand { get; }
        public ICommand NavigateMaintenanceCommand { get; }
        public ICommand NavigateTransportersCommand { get; }
        public ICommand NavigateWorkOrdersCommand { get; }

        public SidePanelViewModel(
            INavigationService<AreasViewModel> areasNavigationService,
            INavigationService<DashboardViewModel> dashboardNavigationService,
            INavigationService<LinesViewModel> linesNavigationService,
            INavigationService<MaintenanceViewModel> maintenanceNavigationService,
            INavigationService<TransportersViewModel> transportersNavigationService,
            INavigationService<WorkOrdersViewModel> workOrdersVNavigationService)
        {
            NavigateAreasCommand = new NavigateCommand<AreasViewModel>(areasNavigationService);
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(dashboardNavigationService);
            NavigateLinesCommand = new NavigateCommand<LinesViewModel>(linesNavigationService);
            NavigateMaintenanceCommand = new NavigateCommand<MaintenanceViewModel>(maintenanceNavigationService);
            NavigateTransportersCommand = new NavigateCommand<TransportersViewModel>(transportersNavigationService);
            NavigateWorkOrdersCommand = new NavigateCommand<WorkOrdersViewModel>(workOrdersVNavigationService);
        }

    }
}
