using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrzegladyRemonty.Bases;

namespace PrzegladyRemonty.Commands
{
    public class NavigationCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}