using PrzegladyRemonty.Stores;
using PrzegladyRemonty.ViewModels;
using PrzegladyRemonty.Views;
using System.ComponentModel;
using System.Windows;

namespace PrzegladyRemonty
{
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly LoginViewModel _loginViewModel;
        private readonly MainViewModel _mainViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _loginViewModel = new();
            _mainViewModel = new();
        }

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            LoginView loginView = new()
            {
                DataContext = _loginViewModel
            };

            MainWindow mainWindow = new()
            {
                DataContext = _mainViewModel
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
                    MainWindow = new MainWindow()
                    {
                        DataContext = _mainViewModel
                    };
                    MainWindow.Show();
                    loginWindow.Close();
                }
            }
        }
    }
}
