using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.Transporters.Stores;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersDetailsViewModel : ViewModelBase
    {
        private SelectedTransporter _transporter;
        private IServiceProvider _databaseServices;

        private TransporterPart _transporterPart;
        private Part _part;
        private ObservableCollection<TransporterPart> _transporterParts;
        private ObservableCollection<Part> _parts;

        private TransporterAction _transporterAction;
        private ActionCategory _action;
        private ObservableCollection<TransporterAction> _transporterActions;
        private ObservableCollection<ActionCategory> _actions;

        public Transporter Transporter => _transporter.Transporter;

        public IEnumerable<TransporterPart> TransporterParts => _transporterParts;
        public IEnumerable<Part> Parts => _parts;

        public IEnumerable<TransporterAction> TransporterActions => _transporterActions;
        public IEnumerable<ActionCategory> Actions => _actions;

        public TransporterAction SelectedTransporterAction
        {
            get => _transporterAction;
            set
            {
                _transporterAction = value;
                OnPropertyChanged(nameof(SelectedTransporterAction));
            }
        }

        public ActionCategory SelectedAction
        {
            get => _action;
            set
            {
                _action = value;
                OnPropertyChanged(nameof(SelectedAction));
            }
        }

        public TransporterPart SelectedTransporterPart
        {
            get => _transporterPart;
            set
            {
                _transporterPart = value;
                OnPropertyChanged(nameof(SelectedTransporterPart));
            }
        }

        public Part SelectedPart
        {
            get => _part;
            set
            {
                _part = value;
                OnPropertyChanged(nameof(SelectedPart));
            }
        }

        public ICommand AddPart { get; }
        public ICommand RemovePart { get; }
        public ICommand AddAction { get; }
        public ICommand RemoveAction { get; }
        public ICommand NavigateMainCommand { get; }

        public TransportersDetailsViewModel(INavigationService<TransportersMainViewModel> transportersMainViewModel, IServiceProvider databaseServices, SelectedTransporter transporter, ObservableCollection<Part> parts, ObservableCollection<ActionCategory> actions)
        {
            _transporter = transporter;
            _databaseServices = databaseServices;
            _parts = parts;
            _actions = actions;

            _transporterParts = new();
            _transporterActions = new();

            GetTransporterParts();
            GetTransporterActions();

            TransporterActionProvider actionProvider = _databaseServices.GetRequiredService<TransporterActionProvider>();
            TransporterPartProvider partProvider = _databaseServices.GetRequiredService<TransporterPartProvider>();

            AddPart = new TransportersPartsAddCommand(partProvider, this);
            RemovePart = new TransportersPartsRemoveCommand(partProvider, this);
            AddAction = new TransportersActionsAddCommand(actionProvider, this);
            RemoveAction = new TransportersActionsRemoveCommand(actionProvider, this);
            NavigateMainCommand = new NavigateCommand<TransportersMainViewModel>(transportersMainViewModel);
        }

        public void GetTransporterParts()
        {
            _transporterParts.Clear();
            foreach (TransporterPart transporterPart in _databaseServices.GetRequiredService<TransporterPartProvider>().GetAll().Result)
            {
                if (transporterPart.TransporterId == _transporter.Transporter.Id)
                {
                    transporterPart.SetPart(_parts.Single(p => p.Id == transporterPart.PartId));
                    transporterPart.SetTransporter(_transporter.Transporter);
                    _transporterParts.Add(transporterPart);
                }
            }
        }
        public void GetTransporterActions()
        {
            _transporterActions.Clear();
            foreach (TransporterAction transporterAction in _databaseServices.GetRequiredService<TransporterActionProvider>().GetAll().Result)
            {
                if (transporterAction.TransporterId == _transporter.Transporter.Id)
                {
                    transporterAction.SetAction(_actions.Single(a => a.Id == transporterAction.ActionId));
                    transporterAction.SetTransporter(_transporter.Transporter);
                    _transporterActions.Add(transporterAction);
                }
            }
        }



    }
}
