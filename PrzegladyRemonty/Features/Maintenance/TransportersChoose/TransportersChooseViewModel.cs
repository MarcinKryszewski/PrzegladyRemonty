using PrzegladyRemonty.Shared.ViewModels;
using System;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class TransportersChooseViewModel : ViewModelBase
    {
        //private readonly IServiceProvider _maintenanceServices;
        //private readonly TransporterStore _transporterStore;

        public ActionsListViewModel ActionsListViewModel { get; }
        public PartsListViewModel PartsListViewModel { get; }
        public ProductionLineListViewModel ProductionLineListViewModel { get; }
        public TransporterCartViewModel TransporterCartViewModel { get; }

        public TransportersChooseViewModel(IServiceProvider maintenanceServices)
        {
            //IServiceProvider _maintenanceServices = maintenanceServices;

            //_transporterStore = maintenanceServices.GetRequiredService<TransporterStore>();

            ActionsListViewModel = new(maintenanceServices);
            PartsListViewModel = new(maintenanceServices);
            ProductionLineListViewModel = new(maintenanceServices);
            TransporterCartViewModel = new(maintenanceServices);
        }
    }
}