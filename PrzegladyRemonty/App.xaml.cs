using PrzegladyRemonty.Stores;
using PrzegladyRemonty.ViewModels;
using PrzegladyRemonty.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrzegladyRemonty
{
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            LoginViewModel loginViewModel = new();
            LoginView loginView = new()
            {
                DataContext = loginViewModel
            };
            loginView.Show();

            if (loginViewModel.IsAuthenticated)
            {
                MainWindow = new MainWindow()
                {
                    DataContext = new MainViewModel(_navigationStore)
                };
                MainWindow.Show();
            }

            base.OnStartup(e);
        }
    }
}
