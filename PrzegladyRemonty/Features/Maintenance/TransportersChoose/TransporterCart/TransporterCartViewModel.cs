using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class TransporterCartViewModel : ViewModelBase
    {
        private readonly TransporterStore _selectedTransporter;
        private readonly TransportersListStore _transportersCart;
        private readonly MaintenanceTransporterStore _globalSelectedTransporter;

        public IEnumerable<Transporter> Transporters => _transportersCart.Transporters;

        public Transporter SelectedTransporter
        {
            get => _selectedTransporter.Transporter;
            set
            {
                _selectedTransporter.Transporter = value;
                _globalSelectedTransporter.Transporter = value;
                OnPropertyChanged(nameof(SelectedTransporter));
            }
        }

        public ICommand RemoveTransporter { get; }

        public TransporterCartViewModel(IServiceProvider maintenanceServices)
        {
            _selectedTransporter = maintenanceServices.GetRequiredService<TransporterStore>();
            _transportersCart = maintenanceServices.GetRequiredService<TransportersListStore>();
            RemoveTransporter = new RemoveTransporterCommand(_selectedTransporter, _transportersCart);
            _globalSelectedTransporter = maintenanceServices.GetRequiredService<MaintenanceTransporterStore>();
        }
    }
}
