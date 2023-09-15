using PrzegladyRemonty.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrzegladyRemonty.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private string _username;
        private bool _isAuthenticated;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
            set
            {
                _isAuthenticated = value;
                OnPropertyChanged(nameof(IsAuthenticated));
            }
        }

        public ICommand LoginCommand { get; }
        

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }
    }
}
