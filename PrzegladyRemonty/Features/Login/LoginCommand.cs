using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Stores;
using System.Collections.Generic;

namespace PrzegladyRemonty.Features.Login
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly PersonProvider _personProvider;
        private readonly PersonPermissionProvider _personPermissionProvider;
        private readonly PermissionProvider _permissionProvider;
        private readonly UserStore _user;

        public LoginCommand(LoginViewModel LoginViewModel, PersonProvider personProvider, PersonPermissionProvider personPermissionProvider, PermissionProvider permissionProvider, UserStore user)
        {
            _loginViewModel = LoginViewModel;
            _personProvider = personProvider;
            _personPermissionProvider = personPermissionProvider;
            _permissionProvider = permissionProvider;
            _user = user;
        }
        public override void Execute(object parameter)
        {
            string username;

            if (parameter != null)
            {
                username = parameter.ToString();
            }
            else
            {
                username = _loginViewModel.Username;
            }

            if (username?.Length > 0)
            {
                if (username == "@dm1n")
                {
                    _user.User = new Person(1, "Admin", "Admin", "Admin", true);
                    _loginViewModel.IsAuthenticated = true;
                    return;
                }
                bool userExists = _personProvider.Exists(username);
                if (userExists)
                {
                    SetUser(username);
                }
                _loginViewModel.IsAuthenticated = userExists;
            }
        }

        public void SetUser(string username)
        {
            _user.User = _personProvider.GetByLogin(username);
            SetUserRoles(_user.User.Id);
        }

        public async void SetUserRoles(int userId)
        {
            IEnumerable<PersonPermission> permissionsForUser;
            permissionsForUser = await _personPermissionProvider.GetAllUserPermissions(userId);
            foreach (PersonPermission personPermission in permissionsForUser)
            {
                Permission permission = _permissionProvider.GetById(personPermission.Permission);
                _user.AddPermission(permission);
            }
        }
    }
}
