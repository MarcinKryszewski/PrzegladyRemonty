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

        private readonly PersonProvider _personProvider;
        private readonly PersonPermissionProvider _personPermissionProvider;
        private readonly PermissionProvider _permissionProvider;
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

        public LoginViewModel(IHost databaseHost, UserStore user)
        {
            _databaseServices = databaseHost.Services;

            _personProvider = _databaseServices.GetRequiredService<PersonProvider>();
            _personPermissionProvider = _databaseServices.GetRequiredService<PersonPermissionProvider>();
            _permissionProvider = _databaseServices.GetRequiredService<PermissionProvider>();

            LoginCommand = new LoginCommand(this, _personProvider, _personPermissionProvider, _permissionProvider, user);
        }

        public void UserLogin(string login)
        {
            LoginCommand.Execute(login);
        }


    }
}
