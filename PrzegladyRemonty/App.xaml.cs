﻿using PrzegladyRemonty.Features.Areas;
using PrzegladyRemonty.Features.Dashboard;
using PrzegladyRemonty.Features.Lines;
using PrzegladyRemonty.Features.Login;
using PrzegladyRemonty.Features.Maintenance;
using PrzegladyRemonty.Features.Transporters;
using PrzegladyRemonty.Features.WorkOrders;
using PrzegladyRemonty.Layout.Main;
using PrzegladyRemonty.Layout.SidePanel;
using PrzegladyRemonty.Layout.TopPanel;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using System.ComponentModel;
using System.Windows;

namespace PrzegladyRemonty
{
    public partial class App : Application
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly TopPanelViewModel _topPanelViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _loginViewModel = new();
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

        private INavigationService<AreasViewModel> CreateAreasNavigationService()
        {
            return new LayoutNavigationService<AreasViewModel>
            (
                _navigationStore,
                () => new AreasViewModel(),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
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
                CreateWorkOrdersNavigationService()
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
                () => new LinesViewModel(),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<MaintenanceViewModel> CreateMaintenanceNavigationService()
        {
            return new LayoutNavigationService<MaintenanceViewModel>
            (
                _navigationStore,
                () => new MaintenanceViewModel(),
                CreateSidePanelViewModel,
                _topPanelViewModel
            );
        }
        private INavigationService<TransportersViewModel> CreateTransportersNavigationService()
        {
            return new LayoutNavigationService<TransportersViewModel>
            (
                _navigationStore,
                () => new TransportersViewModel(),
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
    }
}
