using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class PartsListViewModel : ViewModelBase
    {
        private readonly MaintenanceTransporterStore _globalSelectedTransporter;
        private ObservableCollection<Part> _parts;

        public IEnumerable<Part> Parts => _parts;

        public PartsListViewModel(IServiceProvider maintenanceServices)
        {
            _parts = new ObservableCollection<Part>();
            _globalSelectedTransporter = maintenanceServices.GetRequiredService<MaintenanceTransporterStore>();
            _globalSelectedTransporter.PropertyChanged += OnStorePropertyChanged;
        }

        private void OnStorePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalSelectedTransporter.Transporter))
            {
                _parts.Clear();
                if (_globalSelectedTransporter.Transporter is null) return;

                foreach (var part in _globalSelectedTransporter.Transporter.Parts)
                {
                    _parts.Add(part);
                }
                OnPropertyChanged(nameof(Parts));
            }
        }
    }
}
