using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using System;
using System.Linq;

namespace PrzegladyRemonty.Features.Maintenance.TransportersChoose.Commands
{
    public class ConfirmCartCommand : CommandBase
    {
        private readonly IServiceProvider _services;
        private readonly TransportersListStore _transporterCart;
        public ConfirmCartCommand(IServiceProvider maintenanceServices)
        {
            _services = maintenanceServices;
            _transporterCart = _services.GetRequiredService<TransportersListStore>();
        }

        public override void Execute(object parameter)
        {
            if (_transporterCart.Transporters.Any())
            {
                NavigationService<MaintenanceCreateViewModel> navigationService = _services.GetRequiredService<NavigationService<MaintenanceCreateViewModel>>();
                navigationService.Navigate();
            }

        }
    }
}
