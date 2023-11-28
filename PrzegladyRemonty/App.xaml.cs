using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Database;
using PrzegladyRemonty.Database.Initializers;
using PrzegladyRemonty.Features.ActionsCategories;
using PrzegladyRemonty.Features.Areas;
using PrzegladyRemonty.Features.Dashboard;
using PrzegladyRemonty.Features.Lines;
using PrzegladyRemonty.Features.Login;
using PrzegladyRemonty.Features.Maintenance;
using PrzegladyRemonty.Features.MaintenanceHistory;
using PrzegladyRemonty.Features.Parts;
using PrzegladyRemonty.Features.Transporters;
using PrzegladyRemonty.Features.TransporterTypes;
using PrzegladyRemonty.Features.WorkOrders;
using PrzegladyRemonty.Layout.Main;
using PrzegladyRemonty.Layout.SidePanel;
using PrzegladyRemonty.Layout.TopPanel;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Stores;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows;


namespace PrzegladyRemonty
{
    public partial class App : Application
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly IHost _databaseHost;
        private readonly IHost _navigationHost;
        private readonly IHost _userHost;

        private readonly LoginViewModel _loginViewModel;
        #endregion

        public App()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _databaseHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(new DatabaseConnectionFactory(_configuration));

                ProvidersServices(services);
            }).Build();
            _databaseHost.Start();

            _userHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(new UserStore());
            }).Build();
            _userHost.Start();

            _navigationHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<SelectedPanelStore>();
                services.AddSingleton<TopPanelViewModel>(new TopPanelViewModel(_userHost.Services.GetRequiredService<UserStore>()));
            }).Build();
            _navigationHost.Start();

            _loginViewModel = new LoginViewModel(_databaseHost, _userHost);
        }

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            _databaseHost.Start();
            _navigationHost.Start();

            using IDbConnection connection = _databaseHost.Services.GetRequiredService<DatabaseConnectionFactory>().Connect();
            DatabaseInitializerFactory initializer = new(_configuration, connection);
            IDatabaseInitializer databaseInitializer = initializer.CreateInitializer();
            databaseInitializer.Initialize();

            LoginView loginView = new()
            {
                DataContext = _loginViewModel
            };

            loginView.Show();
            _loginViewModel.PropertyChanged += OnUserAuthenticated;
            _loginViewModel.UserLogin(Environment.UserName);
        }
        private void OnUserAuthenticated(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_loginViewModel.IsAuthenticated))
            {
                if (_loginViewModel.IsAuthenticated)
                {
                    Window loginWindow = MainWindow;
                    INavigationService<DashboardViewModel> dashboardNavigationService = CreateDashboardNavigationService();
                    MainWindow = new MainWindow()
                    {
                        DataContext = new MainViewModel(_navigationHost.Services.GetRequiredService<NavigationStore>())
                    };
                    dashboardNavigationService.Navigate();

                    MainWindow.Show();
                    loginWindow.Close();
                }
            }
        }

        private SidePanelViewModel CreateSidePanelViewModel()
        {
            return new SidePanelViewModel
            (
                CreateAreasNavigationService(),
                CreateDashboardNavigationService(),
                CreateLinesNavigationService(),
                CreateMaintenanceNavigationService(),
                CreateTransportersNavigationService(),
                CreateWorkOrdersNavigationService(),
                CreateActionsCategoriesNavigationService(),
                CreatePartsNavigationService(),
                CreateTransporterTypesNavigationService(),
                CreateMaintenanceHistoryNavigationService(),
                _navigationHost
            );
        }

        #region CreateNavigationServices
        private INavigationService<AreasViewModel> CreateAreasNavigationService()
        {
            return new LayoutNavigationService<AreasViewModel>
            (
                _navigationHost,
                () => new AreasViewModel(_databaseHost),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<DashboardViewModel> CreateDashboardNavigationService()
        {
            return new LayoutNavigationService<DashboardViewModel>
            (
                _navigationHost,
                () => new DashboardViewModel(),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<LinesViewModel> CreateLinesNavigationService()
        {
            return new LayoutNavigationService<LinesViewModel>
            (
                _navigationHost,
                () => new LinesViewModel(_databaseHost),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<MaintenanceViewModel> CreateMaintenanceNavigationService()
        {
            return new LayoutNavigationService<MaintenanceViewModel>
            (
                _navigationHost,
                () => new MaintenanceViewModel(_databaseHost, _userHost),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<TransportersViewModel> CreateTransportersNavigationService()
        {
            return new LayoutNavigationService<TransportersViewModel>
            (
                _navigationHost,
                () => new TransportersViewModel(_databaseHost),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<WorkOrdersViewModel> CreateWorkOrdersNavigationService()
        {
            return new LayoutNavigationService<WorkOrdersViewModel>
            (
                _navigationHost,
                () => new WorkOrdersViewModel(_databaseHost.Services, _userHost.Services),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<ActionsCategoriesViewModel> CreateActionsCategoriesNavigationService()
        {
            return new LayoutNavigationService<ActionsCategoriesViewModel>
            (
                _navigationHost,
                () => new ActionsCategoriesViewModel(_databaseHost),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<PartsViewModel> CreatePartsNavigationService()
        {
            return new LayoutNavigationService<PartsViewModel>
            (
                _navigationHost,
                () => new PartsViewModel(_databaseHost),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<TransporterTypesViewModel> CreateTransporterTypesNavigationService()
        {
            return new LayoutNavigationService<TransporterTypesViewModel>
            (
                _navigationHost,
                () => new TransporterTypesViewModel(_databaseHost),
                CreateSidePanelViewModel
            );
        }
        private INavigationService<MaintenanceHistoryViewModel> CreateMaintenanceHistoryNavigationService()
        {
            return new LayoutNavigationService<MaintenanceHistoryViewModel>
            (
                _navigationHost,
                () => new MaintenanceHistoryViewModel(),
                CreateSidePanelViewModel
            );
        }
        #endregion

        private static void ProvidersServices(IServiceCollection services)
        {
            services.AddSingleton<ActionCategoryProvider>();
            services.AddSingleton<AreaProvider>();
            services.AddSingleton<LineProvider>();
            services.AddSingleton<MaintenanceProvider>();
            services.AddSingleton<PermissionProvider>();
            services.AddSingleton<PersonPermissionProvider>();
            services.AddSingleton<PersonProvider>();
            services.AddSingleton<TransporterActionProvider>();
            services.AddSingleton<TransporterProvider>();
            services.AddSingleton<WorkOrderMaintenanceProvider>();
            services.AddSingleton<WorkOrderProvider>();
            services.AddSingleton<PartProvider>();
            services.AddSingleton<TransporterPartProvider>();
            services.AddSingleton<TransporterTypeProvider>();
        }
    }
}