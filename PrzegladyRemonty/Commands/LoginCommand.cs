using PrzegladyRemonty.Features.Login;
using PrzegladyRemonty.Shared.Commands;

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
