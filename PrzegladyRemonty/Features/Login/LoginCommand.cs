using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Login
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly PersonProvider _personProvider;

        public LoginCommand(LoginViewModel LoginViewModel, PersonProvider personProvider)
        {
            _loginViewModel = LoginViewModel;
            _personProvider = personProvider;
        }
        public override void Execute(object parameter)
        {
            if (_loginViewModel.Username?.Length > 0)
            {
                _loginViewModel.IsAuthenticated = _personProvider.Exists(_loginViewModel.Username);
            }
        }
    }
}
