using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly TopPanelViewModel _topPanelViewModel;
        private readonly SidePanelViewModel _sidePanelViewModel;
        private readonly UserStore _user;
        #endregion

        public App()
        {
            _user = new UserStore();

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

            _navigationHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(_user);
                services.AddSingleton(_databaseHost);

                services.AddSingleton(new NavigationStore());
                services.AddSingleton<TopPanelViewModel>();

                services.AddSingleton<AreasViewModel>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<LinesViewModel>();
                services.AddSingleton<MaintenanceViewModel>();
                services.AddSingleton<TransportersViewModel>();
                services.AddSingleton<WorkOrdersViewModel>();
                services.AddSingleton<ActionsCategoriesViewModel>();
                services.AddSingleton<PartsViewModel>();
                services.AddSingleton<TransporterTypesViewModel>();
                services.AddSingleton<MaintenanceHistoryViewModel>();


            }).Build();
            _navigationHost.Start();

            _navigationStore = _navigationHost.Services.GetRequiredService<NavigationStore>();
            _topPanelViewModel = _navigationHost.Services.GetRequiredService<TopPanelViewModel>();
            _sidePanelViewModel = CreateSidePanelViewModel();

            _loginViewModel = new LoginViewModel(_databaseHost, _user);

        }

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            _databaseHost.Start();
            _navigationHost.Start();

            using DatabaseConnectionFactory connectionFactory = _databaseHost.Services.GetRequiredService<DatabaseConnectionFactory>();
            using IDbConnection connection = connectionFactory.Connect();

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
                        DataContext = new MainViewModel(_navigationStore)
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
                CreateMaintenanceHistoryNavigationService()
            );
        }

        #region CreateNavigationServices
        private INavigationService<AreasViewModel> CreateAreasNavigationService()
        {
            return new LayoutNavigationService<AreasViewModel>
            (
                _navigationStore, //+
                () => new AreasViewModel(_databaseHost),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<DashboardViewModel> CreateDashboardNavigationService()
        {
            return new LayoutNavigationService<DashboardViewModel>
            (
                _navigationStore,
                () => new DashboardViewModel(),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<LinesViewModel> CreateLinesNavigationService()
        {
            return new LayoutNavigationService<LinesViewModel>
            (
                _navigationStore,
                () => new LinesViewModel(_databaseHost),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<MaintenanceViewModel> CreateMaintenanceNavigationService()
        {
            return new LayoutNavigationService<MaintenanceViewModel>
            (
                _navigationStore,
                () => new MaintenanceViewModel(_databaseHost),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<TransportersViewModel> CreateTransportersNavigationService()
        {
            return new LayoutNavigationService<TransportersViewModel>
            (
                _navigationStore,
                () => new TransportersViewModel(_databaseHost),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<WorkOrdersViewModel> CreateWorkOrdersNavigationService()
        {
            return new LayoutNavigationService<WorkOrdersViewModel>
            (
                _navigationStore,
                () => new WorkOrdersViewModel(),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<ActionsCategoriesViewModel> CreateActionsCategoriesNavigationService()
        {
            return new LayoutNavigationService<ActionsCategoriesViewModel>
            (
                _navigationStore,
                () => new ActionsCategoriesViewModel(_databaseHost),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<PartsViewModel> CreatePartsNavigationService()
        {
            return new LayoutNavigationService<PartsViewModel>
            (
                _navigationStore,
                () => new PartsViewModel(_databaseHost),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<TransporterTypesViewModel> CreateTransporterTypesNavigationService()
        {
            return new LayoutNavigationService<TransporterTypesViewModel>
            (
                _navigationStore,
                () => new TransporterTypesViewModel(_databaseHost),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<MaintenanceHistoryViewModel> CreateMaintenanceHistoryNavigationService()
        {
            return new LayoutNavigationService<MaintenanceHistoryViewModel>
            (
                _navigationStore,
                () => new MaintenanceHistoryViewModel(),
                CreateSidePanelViewModel,
                _topPanelViewModel
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