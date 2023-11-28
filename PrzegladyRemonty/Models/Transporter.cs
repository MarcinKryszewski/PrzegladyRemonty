using PrzegladyRemonty.Services.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Models
{
    public class Transporter
    {
        private Area _area;
        private TransporterType _transporterType;
        private DateOnly _lastMaintenance;
        private readonly ObservableCollection<Part> _parts;
        private readonly ObservableCollection<ActionCategory> _actions;
        private int _transporterTypeId;

        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public int AreaId { get; }
        public DateOnly LastMaintenance => _lastMaintenance;
        public int TransporterTypeId => _transporterTypeId;
        public Area Area => _area;
        public TransporterType TransporterType => _transporterType;
        public IEnumerable<Part> Parts => _parts;
        public IEnumerable<ActionCategory> Actions => _actions;

        public Transporter(int id, string name, bool active, int area, int transporterType, DateOnly lastMaintenance)
        {
            Id = id;
            Name = name;
            Active = active;
            AreaId = area;
            _transporterTypeId = transporterType;
            _lastMaintenance = lastMaintenance;

            _parts = new ObservableCollection<Part>();
            _actions = new ObservableCollection<ActionCategory>();
        }

        public Transporter(string name, int area, int transporterType)
        {
            Name = name;
            AreaId = area;
            _transporterTypeId = transporterType;
            _lastMaintenance = DateOnly.FromDayNumber(0);

            _parts = new ObservableCollection<Part>();
            _actions = new ObservableCollection<ActionCategory>();
        }

        public void SetType(TransporterType transporterType)
        {
            _transporterType = transporterType;
            _transporterTypeId = transporterType.Id;
        }
        public void SetArea(Area area)
        {
            _area = area;
        }
        public void AddPart(Part part)
        {
            _parts.Add(part);
        }
        public void RemovePart(Part part)
        {
            _parts.Remove(part);
        }

        public void AddAction(ActionCategory action)
        {
            _actions.Add(action);
        }

        public void RemoveAction(ActionCategory action)
        {
            _actions.Remove(action);
        }

        public void SetMaintenance(DateOnly maintenanceDate = default)
        {
            if (maintenanceDate == default)
            {
                _lastMaintenance = DateOnly.FromDateTime(DateTime.Now);
                return;
            }
            _lastMaintenance = maintenanceDate;
        }

        public void Add(TransporterProvider provider)
        {
            provider.Create(this);
        }
        public void Edit(TransporterProvider provider)
        {
            provider.Update(this);
        }
        public async Task Delete(TransporterProvider provider)
        {
            await provider.Delete(Id);
        }
    }
}
