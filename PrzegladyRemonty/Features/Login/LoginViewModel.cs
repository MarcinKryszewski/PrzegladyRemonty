using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Stores;
using System;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IServiceProvider _databaseServices;
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                _isAuthenticated = value;
                OnPropertyChanged(nameof(IsAuthenticated));
            }
        }

        private string _userType;
        public string UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IHost databaseHost, IHost userHost)
        {
            _databaseServices = databaseHost.Services;

            LoginCommand = new LoginCommand(
                this,
                _databaseServices.GetRequiredService<PersonProvider>(),
                _databaseServices.GetRequiredService<PersonPermissionProvider>(),
                _databaseServices.GetRequiredService<PermissionProvider>(),
                userHost.Services.GetRequiredService<UserStore>());
        }

        public void UserLogin(string login)
        {
            LoginCommand.Execute(login);
        }
    }
}
