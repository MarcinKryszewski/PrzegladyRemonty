using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.Transporters.Stores;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersDetailsViewModel : ViewModelBase
    {
        private SelectedTransporter _transporter;
        private IServiceProvider _databaseServices;

        private TransporterPart _transporterPart;
        private ObservableCollection<TransporterPart> _transporterParts;
        private ObservableCollection<Part> _parts;

        private TransporterAction _action;
        private ObservableCollection<TransporterAction> _transporterActions;
        private ObservableCollection<ActionCategory> _actions;


        public ICommand AddPart { get; }
        public ICommand RemovePart { get; }
        public ICommand AddAction { get; }
        public ICommand RemoveAction { get; }
        public ICommand SaveTransporter { get; }

        public TransportersDetailsViewModel(IServiceProvider databaseServices, SelectedTransporter transporter, ObservableCollection<Part> parts, ObservableCollection<ActionCategory> actions)
        {
            _transporter = transporter;
            _databaseServices = databaseServices;
            _parts = parts;
            _actions = actions;

            _transporterParts = GetTransporterParts();

            AddPart = new TransportersPartsAddCommand();
            RemovePart = new TransportersPartsRemoveCommand();
            AddAction = new TransportersActionsAddCommand();
            RemoveAction = new TransportersActionsRemoveCommand();
            SaveTransporter = new TransportersSaveCommand();
        }

        private ObservableCollection<TransporterPart> GetTransporterParts()
        {
            _transporter.Transporter.Parts;
            _databaseServices.GetRequiredService<TransporterPart>();
        }


    }
}
