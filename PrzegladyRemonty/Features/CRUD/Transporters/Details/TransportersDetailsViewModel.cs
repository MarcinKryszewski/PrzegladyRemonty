using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Features.Transporters.Stores;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Services.Providers;
using System.Linq;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersDetailsViewModel : ViewModelBase
    {
        /*private readonly IServiceProvider _databaseServices;
        private readonly SelectedTransporter _selectedTransporter;
        private ObservableCollection<TransporterPart> _transporterParts;
        private ObservableCollection<TransporterPart> _transporterPartsSelected;
        private ObservableCollection<TransporterAction> _transporterActions;
        private ObservableCollection<TransporterAction> _transporterActionsSelected;

        private Part _partSelected;
        private readonly ObservableCollection<Part> _parts;
        private readonly ObservableCollection<Part> _partsSelected;
        private readonly ObservableCollection<Part> _partsList;

        private ActionCategory _actionSelected;
        private readonly ObservableCollection<ActionCategory> _actions;
        private readonly ObservableCollection<ActionCategory> _actionsSelected;
        private readonly ObservableCollection<ActionCategory> _actionsList;

        public Part SelectedPart => _partSelected;
        public ObservableCollection<Part> Parts => _parts;
        public ObservableCollection<Part> PartsSelected => _partsSelected;
        public ObservableCollection<TransporterPart> PartsList => new(_transporterPartsSelected);

        public ActionCategory SelectedAction => _actionSelected;
        public ObservableCollection<ActionCategory> Actions => _actions;
        public ObservableCollection<ActionCategory> ActionsSelected => _actionsSelected;
        public ObservableCollection<TransporterAction> ActionsList => new(_transporterActionsSelected);

        public Transporter Transporter => _selectedTransporter.Transporter;

        public ICommand NavigateMainCommand { get; }
        public ICommand AddActions { get; }
        public ICommand AddParts { get; }
        public ICommand RemoveAction { get; }
        public ICommand RemovePart { get; }
        public ICommand SaveTransporters { get; }

        public TransportersDetailsViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            IHost database,
            SelectedTransporter selectedTransporter,
            ObservableCollection<Part> parts,
            ObservableCollection<ActionCategory> actions)
        {
            NavigateMainCommand = new NavigateCommand<TransportersMainViewModel>(transportersMainViewModel);
            _databaseServices = database.Services;
            _selectedTransporter = selectedTransporter;

            _transporterParts = new ObservableCollection<TransporterPart>(GetTransportersParts());
            _transporterActions = new ObservableCollection<TransporterAction>(GetTransporterActions());
            _transporterPartsSelected = new ObservableCollection<TransporterPart>(GetTransportersPartsSelected());
            _transporterActionsSelected = new ObservableCollection<TransporterAction>(GetTransporterActionsSelected());

            _parts = parts;
            _partsSelected = new();
            _partsList = new ObservableCollection<Part>(_selectedTransporter.Transporter.Parts);

            _actions = actions;
            _actionsSelected = new();
            _actionsList = new ObservableCollection<ActionCategory>(_selectedTransporter.Transporter.Actions);

            SetSelectedTransporter();

            AddActions = new TransportersActionsAddCommand(_actionsSelected, _actionsList);
            RemoveAction = new TransportersActionsRemoveCommand(this);

            AddParts = new TransportersPartsAddCommand(_partsSelected, _partsList);
            RemovePart = new TransportersPartsRemoveCommand(this);

            SaveTransporters = new TransportersSaveCommand();
        }

        private void SetSelectedTransporter()
        {
            Transporter transporter = _selectedTransporter.Transporter;

            IEnumerable<TransporterPart> transportersParts = _transporterParts.Where(b => b.TransporterId == transporter.Id);
            IEnumerable<Part> parts = _parts.Where(c => transportersParts.Any(b => b.PartId == c.Id));

            foreach (Part part in parts)
            {
                transporter.AddPart(part);
            }

            IEnumerable<TransporterAction> transportersActions = _transporterActions.Where(b => b.TransporterId == transporter.Id);
            IEnumerable<ActionCategory> actions = _actions.Where(c => transportersActions.Any(b => b.ActionId == c.Id));

            foreach (ActionCategory action in actions)
            {
                transporter.AddAction(action);
            }
        }

        private IEnumerable<Part> GetParts()
        {
            return _databaseServices.GetRequiredService<PartProvider>().GetAll().Result;
        }

        private IEnumerable<TransporterPart> GetTransportersParts()
        {
            return _databaseServices.GetRequiredService<TransporterPartProvider>().GetAll().Result;
        }

        private IEnumerable<TransporterPart> GetTransportersPartsSelected()
        {
            ObservableCollection<TransporterPart> transporterParts = new();
            foreach (TransporterPart transporterPart in _transporterParts)
            {
                if (transporterPart.Transporter.Id == _selectedTransporter.Transporter.Id) transporterParts.Add(transporterPart);
            }
            return transporterParts;
        }

        private IEnumerable<ActionCategory> GetActions()
        {
            IEnumerable<ActionCategory> actionsList = _databaseServices.GetRequiredService<ActionCategoryProvider>().GetAll().Result;
            return actionsList;
        }

        private IEnumerable<TransporterAction> GetTransporterActions()
        {
            IEnumerable<TransporterAction> actionsList = _databaseServices.GetRequiredService<TransporterActionProvider>().GetAll().Result;
            return actionsList;
        }

        private IEnumerable<TransporterAction> GetTransporterActionsSelected()
        {
            ObservableCollection<TransporterAction> transporterActions = new();
            foreach (TransporterAction transporterAction in _transporterActions)
            {
                if (transporterAction.Transporter.Id == _selectedTransporter.Transporter.Id) transporterActions.Add(transporterAction);
            }
            return transporterActions;
        }*/

        public TransportersDetailsViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            IHost database,
            SelectedTransporter selectedTransporter,
            ObservableCollection<Part> parts,
            ObservableCollection<ActionCategory> actions)
        { }
    }
}
