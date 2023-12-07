using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.MaintenanceHistory
{
    public class MaintenanceHistoryViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Models.Maintenance> _maintenances;
        private readonly IServiceProvider _services;

        public IEnumerable<Models.Maintenance> Maintenances => _maintenances;

        public MaintenanceHistoryViewModel(IServiceProvider databaseServices)
        {
            _services = databaseServices;
            _maintenances = new();
            SetMaintenances();
        }

        private void SetMaintenances()
        {
            _maintenances.Clear();
            IEnumerable<Models.Maintenance> maintenances = _services.GetRequiredService<MaintenanceProvider>().GetAll().Result;
            IEnumerable<Person> mechanics = _services.GetRequiredService<PersonProvider>().GetAll().Result;
            IEnumerable<TransporterAction> transporterActions = GetTransporterActions();


            foreach (Models.Maintenance maintenance in maintenances)
            {
                maintenance.SetMechanic(mechanics.First(m => m.Id == maintenance.MechanicId));
                maintenance.SetAction(transporterActions.First(a => a.Id == maintenance.MaintenanceActionId));

                _maintenances.Add(maintenance);
            }
        }

        private IEnumerable<TransporterAction> GetTransporterActions()
        {
            ObservableCollection<TransporterAction> transporterActions = new(_services.GetRequiredService<TransporterActionProvider>().GetAll().Result);
            IEnumerable<ActionCategory> actions = _services.GetRequiredService<ActionCategoryProvider>().GetAll().Result;
            IEnumerable<Transporter> transporters = GetTransporters();

            foreach (TransporterAction action in transporterActions)
            {
                action.SetAction(actions.First(a => a.Id == action.ActionId));
                action.SetTransporter(transporters.First(a => a.Id == action.TransporterId));
            }

            return transporterActions;
        }

        private IEnumerable<Transporter> GetTransporters()
        {
            ObservableCollection<Transporter> transporters = new(_services.GetRequiredService<TransporterProvider>().GetAll().Result);
            IEnumerable<TransporterType> types = _services.GetRequiredService<TransporterTypeProvider>().GetAll().Result;
            IEnumerable<Area> areas = GetAreas();

            foreach (Transporter transporter in transporters)
            {
                transporter.SetType(types.First(t => t.Id == transporter.TransporterTypeId));
                transporter.SetArea(areas.First(a => a.Id == transporter.AreaId));
            }

            return transporters;
        }

        private IEnumerable<Area> GetAreas()
        {
            ObservableCollection<Area> areas = new(_services.GetRequiredService<AreaProvider>().GetAll().Result);
            IEnumerable<Line> lines = _services.GetRequiredService<LineProvider>().GetAll().Result;

            foreach (Area area in areas)
            {
                area.SetLine(lines.First(l => l.Id == area.LineId));
            }

            return areas;
        }
    }
}
