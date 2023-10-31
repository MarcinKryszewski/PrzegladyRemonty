using PrzegladyRemonty.Commands;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Login
{
    public class LoginViewModel : ViewModelBase
    {
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

        public LoginViewModel(PersonProvider personProvider)
        {
            LoginCommand = new LoginCommand(this, personProvider);
        }
    }
}
