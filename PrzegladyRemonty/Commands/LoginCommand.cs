using PrzegladyRemonty.Bases;
using PrzegladyRemonty.Views.Features.Login;

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
            if (_loginViewModel.Username?.Length > 0)
            {
                _loginViewModel.IsAuthenticated = true;
            }
        }
    }
}
