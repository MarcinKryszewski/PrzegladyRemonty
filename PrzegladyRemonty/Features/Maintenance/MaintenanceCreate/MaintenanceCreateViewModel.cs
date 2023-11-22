using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.Maintenance.MaintenanceCreate.Commands;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class MaintenanceCreateViewModel : ViewModelBase
    {
        private bool _workOrderNumberCreated;
        private string _workOrderNumber;
        private readonly TransportersListStore _transportersCart;
        private readonly TransporterStore _selectedTransporter;
        private readonly ObservableCollection<TransporterPart> _transporterParts;
        private readonly ObservableCollection<TransporterAction> _transporterActions;
        private readonly ObservableCollection<TransporterAction> _transporterActionsFromCart;
        private readonly ObservableCollection<TransporterAction> _transporterActionsAll;
        private readonly IServiceProvider _maintenanceServices;

        private readonly WorkOrderProvider _workOrderProvider;
        private readonly WorkOrderMaintenanceProvider _workOrderMaintenanceProvider;
        private readonly MaintenanceProvider _maintenanceProvider;

        public string WorkOrderNumber
        {
            get => _workOrderNumber;
            set
            {
                _workOrderNumber = value;
                _workOrderNumberCreated = true;
                OnPropertyChanged(nameof(WorkOrderNumber));
                OnPropertyChanged(nameof(WorkOrderNumberCreated));
            }
        }
        public bool WorkOrderNumberCreated => _workOrderNumberCreated;
        public TransportersListStore TransportersCart => _transportersCart;
        public Transporter SelectedTransporter
        {
            get => _selectedTransporter.Transporter;
            set
            {
                _selectedTransporter.Transporter = value;
                UpdateTransporterActions();
                UpdateTransporterParts();
                OnPropertyChanged(nameof(SelectedTransporter));
            }
        }
        public IEnumerable<TransporterPart> TransporterParts => _transporterParts;
        public IEnumerable<TransporterAction> TransporterActions => _transporterActions;
        public ICommand ReturnCommand { get; }
        public ICommand CreateWorkOrderCommand { get; }

        public MaintenanceCreateViewModel(IServiceProvider maintenanceServices)
        {
            _workOrderNumber = "";

            _maintenanceServices = maintenanceServices;
            _transportersCart = _maintenanceServices.GetRequiredService<TransportersListStore>();
            _selectedTransporter = _maintenanceServices.GetRequiredService<TransporterStore>();
            _transporterActionsAll = _maintenanceServices.GetRequiredService<ObservableCollection<TransporterAction>>();

            _selectedTransporter.Transporter = _transportersCart.Transporters.First();
            _transporterParts = new();
            _transporterActions = new();
            UpdateTransporterActions();
            UpdateTransporterParts();

            _transporterActionsFromCart = new();

            _workOrderProvider = _maintenanceServices.GetRequiredService<WorkOrderProvider>();
            _workOrderMaintenanceProvider = _maintenanceServices.GetRequiredService<WorkOrderMaintenanceProvider>();
            _maintenanceProvider = _maintenanceServices.GetRequiredService<MaintenanceProvider>();

            ReturnCommand = new ReturnCommand(_maintenanceServices);
            CreateWorkOrderCommand = new CreateWorkOrderCommand(
                this,
                _workOrderProvider,
                _workOrderMaintenanceProvider,
                _maintenanceProvider,
                _transportersCart,
                _transporterActionsAll,
                _maintenanceServices.GetRequiredService<UserStore>());
        }

        public void UpdateTransporterParts()
        {
            _transporterParts.Clear();
            ObservableCollection<TransporterPart> transporterParts = _maintenanceServices.GetRequiredService<ObservableCollection<TransporterPart>>();
            foreach (TransporterPart transporterPart in transporterParts)
            {
                if (transporterPart.TransporterId == _selectedTransporter.Transporter.Id)
                {
                    _transporterParts.Add(transporterPart);
                }
            }
        }

        public void UpdateTransporterActions()
        {
            _transporterActions.Clear();
            ObservableCollection<TransporterAction> transporterActions = _maintenanceServices.GetRequiredService<ObservableCollection<TransporterAction>>();
            foreach (TransporterAction transporterAction in transporterActions)
            {
                if (transporterAction.TransporterId == _selectedTransporter.Transporter.Id)
                {
                    _transporterActions.Add(transporterAction);
                }
            }
        }

        public void SetWorkOrderNumber(string workOrderNumber)
        {
            _workOrderNumber = workOrderNumber;
        }
    }
}
