using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class ProductionLineListViewModel : ViewModelBase
    {
        private readonly Brewery _brewery;
        private readonly TransporterStore _selectedTransporter;
        private readonly TransportersListStore _transportersCart;
        private readonly MaintenanceTransporterStore _globalSelectedTransporter;

        public Brewery Brewery => _brewery;
        public ICommand ChooseTransporter { get; }
        public ICommand SelectedItem { get; }

        public ProductionLineListViewModel(IServiceProvider maintenanceServices)
        {
            _globalSelectedTransporter = maintenanceServices.GetRequiredService<MaintenanceTransporterStore>();
            _brewery = maintenanceServices.GetRequiredService<Brewery>();
            _selectedTransporter = maintenanceServices.GetRequiredService<TransporterStore>();
            _transportersCart = maintenanceServices.GetRequiredService<TransportersListStore>();

            ChooseTransporter = new SelectTransporterCommand(_selectedTransporter, _transportersCart);
            SelectedItem = new SelectTreeViewItemCommand(_selectedTransporter, _globalSelectedTransporter);
        }
    }
}
