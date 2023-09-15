using PrzegladyRemonty.ViewModels;
using PrzegladyRemonty.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrzegladyRemonty.Commands
{
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        public LoginCommand(LoginViewModel LoginViewModel)
        {
            _loginViewModel = LoginViewModel;
        }
        public override void Execute(object parameter)
        {
            if (_loginViewModel.Username.Length > 0)
            {
                _loginViewModel.IsAuthenticated = true;
            }
        }
    }
}
