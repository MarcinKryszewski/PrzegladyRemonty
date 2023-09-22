using PrzegladyRemonty.Layout.Main;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Features.Dashboard;
using PrzegladyRemonty.Features.Login;
using System.ComponentModel;
using System.Windows;
using PrzegladyRemonty.Layout.SidePanel;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Features.Areas;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Layout.TopPanel;
using PrzegladyRemonty.Features.Lines;
using PrzegladyRemonty.Features.Maintenance;
using PrzegladyRemonty.Features.Transporters;
using PrzegladyRemonty.Features.WorkOrders;

namespace PrzegladyRemonty
{
    public partial class App : Application
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly SidePanelViewModel _sidePanelViewModel;
        private readonly TopPanelViewModel _topPanelViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _loginViewModel = new();
            _sidePanelViewModel = new SidePanelViewModel(
                CreateAreasNavigationService(),
                CreateDashboardNavigationService(),
                CreateLinesNavigationService(),
                CreateMaintenanceNavigationService(),
                CreateTransportersNavigationService(),
                CreateWorkOrdersNavigationService()
            );
            _topPanelViewModel = new TopPanelViewModel();
        }

        private void ApplicationStart(object sender, StartupEventArgs e)
        {

            LoginView loginView = new()
            {
                DataContext = _loginViewModel
            };

            loginView.Show();
            _loginViewModel.PropertyChanged += OnUserAuthenticated;
        }

        private void OnUserAuthenticated(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_loginViewModel.IsAuthenticated))
            {
                if (_loginViewModel.IsAuthenticated)
                {
                    Window loginWindow = MainWindow;
                    INavigationService<DashboardViewModel> dashboardNavigationService = CreateDashboardNavigationService();
                    dashboardNavigationService.Navigate();
                    MainWindow = new MainWindow()
                    {
                        DataContext = new MainViewModel(_navigationStore)
                    };
                    MainWindow.Show();
                    loginWindow.Close();
                }
            }
        }

        private INavigationService<AreasViewModel> CreateAreasNavigationService()
        {
            return new LayoutNavigationService<AreasViewModel>
            (
                _navigationStore,
                () => new AreasViewModel(),
                _sidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<DashboardViewModel> CreateDashboardNavigationService()
        {
            return new LayoutNavigationService<DashboardViewModel>
            (
                _navigationStore,
                () => new DashboardViewModel(),
                _sidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<LinesViewModel> CreateLinesNavigationService()
        {
            return new LayoutNavigationService<LinesViewModel>
            (
                _navigationStore,
                () => new LinesViewModel(),
                _sidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<MaintenanceViewModel> CreateMaintenanceNavigationService()
        {
            return new LayoutNavigationService<MaintenanceViewModel>
            (
                _navigationStore,
                () => new MaintenanceViewModel(),
                _sidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<TransportersViewModel> CreateTransportersNavigationService()
        {
            return new LayoutNavigationService<TransportersViewModel>
            (
                _navigationStore,
                () => new TransportersViewModel(),
                _sidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<WorkOrdersViewModel> CreateWorkOrdersNavigationService()
        {
            return new LayoutNavigationService<WorkOrdersViewModel>
            (
                _navigationStore,
                () => new WorkOrdersViewModel(),
                _sidePanelViewModel,
                _topPanelViewModel
            );
        }
    }
}
