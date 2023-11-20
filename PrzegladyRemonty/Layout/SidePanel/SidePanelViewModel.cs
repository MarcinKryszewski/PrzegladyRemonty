using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Features.ActionsCategories;
using PrzegladyRemonty.Features.Areas;
using PrzegladyRemonty.Features.Dashboard;
using PrzegladyRemonty.Features.Lines;
using PrzegladyRemonty.Features.Maintenance;
using PrzegladyRemonty.Features.MaintenanceHistory;
using PrzegladyRemonty.Features.Parts;
using PrzegladyRemonty.Features.Transporters;
using PrzegladyRemonty.Features.TransporterTypes;
using PrzegladyRemonty.Features.WorkOrders;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Stores;
using System.Windows.Input;

namespace PrzegladyRemonty.Layout.SidePanel
{
    public class SidePanelViewModel : ViewModelBase
    {
        private SelectedPanelStore _selectedPanel;
        public ICommand NavigateAreasCommand { get; }
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateLinesCommand { get; }
        public ICommand NavigateMaintenanceCommand { get; }
        public ICommand NavigateTransportersCommand { get; }
        public ICommand NavigateWorkOrdersCommand { get; }
        public ICommand NavigateActionsCategoriesCommand { get; }
        public ICommand NavigatePartsCommand { get; }
        public ICommand NavigateTransporterTypesCommand { get; }
        public ICommand NavigateMaintenanceHistoryCommand { get; }

        public string SelectedPanelName => _selectedPanel.PanelName;

        public SidePanelViewModel(
            INavigationService<AreasViewModel> areasNavigationService,
            INavigationService<DashboardViewModel> dashboardNavigationService,
            INavigationService<LinesViewModel> linesNavigationService,
            INavigationService<MaintenanceViewModel> maintenanceNavigationService,
            INavigationService<TransportersViewModel> transportersNavigationService,
            INavigationService<WorkOrdersViewModel> workOrdersVNavigationService,
            INavigationService<ActionsCategoriesViewModel> actionsCategoriesNavigationService,
            INavigationService<PartsViewModel> partsNavigationService,
            INavigationService<TransporterTypesViewModel> transporterTypesNavigationService,
            INavigationService<MaintenanceHistoryViewModel> maintenanceHistoryNavigationService,
            IHost navigationServices)
        {
            NavigateAreasCommand = new NavigateCommand<AreasViewModel>(areasNavigationService);
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(dashboardNavigationService);
            NavigateLinesCommand = new NavigateCommand<LinesViewModel>(linesNavigationService);
            NavigateMaintenanceCommand = new NavigateCommand<MaintenanceViewModel>(maintenanceNavigationService);
            NavigateTransportersCommand = new NavigateCommand<TransportersViewModel>(transportersNavigationService);
            NavigateWorkOrdersCommand = new NavigateCommand<WorkOrdersViewModel>(workOrdersVNavigationService);
            NavigateActionsCategoriesCommand = new NavigateCommand<ActionsCategoriesViewModel>(actionsCategoriesNavigationService);
            NavigatePartsCommand = new NavigateCommand<PartsViewModel>(partsNavigationService);
            NavigateTransporterTypesCommand = new NavigateCommand<TransporterTypesViewModel>(transporterTypesNavigationService);
            NavigateMaintenanceHistoryCommand = new NavigateCommand<MaintenanceHistoryViewModel>(maintenanceHistoryNavigationService);
            _selectedPanel = navigationServices.Services.GetRequiredService<SelectedPanelStore>();
        }
    }
}
