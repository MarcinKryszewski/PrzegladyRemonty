using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using System;

namespace PrzegladyRemonty.Features.Maintenance.MaintenanceCreate.Commands
{
    public class ReturnCommand : CommandBase
    {
        private readonly IServiceProvider _maintenanceServices;

        public ReturnCommand(IServiceProvider maintenanceServices)
        {
            _maintenanceServices = maintenanceServices;
        }

        public override void Execute(object parameter)
        {
            NavigationService<TransportersChooseViewModel> navigationService = _maintenanceServices.GetRequiredService<NavigationService<TransportersChooseViewModel>>();
            navigationService.Navigate();
        }
    }
}
