using PrzegladyRemonty.Layout.Main;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Features.Dashboard;
using PrzegladyRemonty.Features.Login;
using System.ComponentModel;
using System.Windows;

namespace PrzegladyRemonty
{
    public partial class App : Application
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _loginViewModel = new();
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
                    _navigationStore.CurrentViewModel = new DashboardViewModel();
                    MainWindow = new MainWindow()
                    {
                        DataContext = new MainViewModel(_navigationStore)
                    };
                    MainWindow.Show();
                    loginWindow.Close();
                }
            }
        }
    }
}
