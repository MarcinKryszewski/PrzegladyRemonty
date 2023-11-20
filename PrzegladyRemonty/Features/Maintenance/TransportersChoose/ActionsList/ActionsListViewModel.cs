using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class ActionsListViewModel : ViewModelBase
    {
        private readonly MaintenanceTransporterStore _globalSelectedTransporter;
        private ObservableCollection<ActionCategory> _actions;

        public IEnumerable<ActionCategory> Actions => _actions;

        public ActionsListViewModel(IServiceProvider maintenanceServices)
        {
            _actions = new ObservableCollection<ActionCategory>();
            _globalSelectedTransporter = maintenanceServices.GetRequiredService<MaintenanceTransporterStore>();
            _globalSelectedTransporter.PropertyChanged += OnStorePropertyChanged;
        }

        private void OnStorePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalSelectedTransporter.Transporter))
            {
                _actions.Clear();
                if (_globalSelectedTransporter.Transporter is null) return;

                foreach (var action in _globalSelectedTransporter.Transporter.Actions)
                {
                    _actions.Add(action);
                }
                OnPropertyChanged(nameof(Actions));
            }
        }
    }
}