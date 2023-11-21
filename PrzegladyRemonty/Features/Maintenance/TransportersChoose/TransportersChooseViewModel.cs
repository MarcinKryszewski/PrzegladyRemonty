using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.Maintenance.TransportersChoose.Commands;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class TransportersChooseViewModel : ViewModelBase
    {
        public ActionsListViewModel ActionsListViewModel { get; }
        public PartsListViewModel PartsListViewModel { get; }
        public ProductionLineListViewModel ProductionLineListViewModel { get; }
        public TransporterCartViewModel TransporterCartViewModel { get; }

        public ICommand ClearCart { get; }
        public ICommand ConfirmCart { get; }

        public TransportersChooseViewModel(IServiceProvider maintenanceServices)
        {
            ActionsListViewModel = new(maintenanceServices);
            PartsListViewModel = new(maintenanceServices);
            ProductionLineListViewModel = new(maintenanceServices);
            TransporterCartViewModel = new(maintenanceServices);

            ClearCart = new ClearCartCommand(maintenanceServices.GetRequiredService<TransportersListStore>());
            ConfirmCart = new ConfirmCartCommand(maintenanceServices);
        }
    }
}