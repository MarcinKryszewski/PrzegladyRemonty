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
        private readonly ObservableCollection<TransporterAction> _actions;

        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public int AreaId { get; }
        public DateOnly LastMaintenance => _lastMaintenance;
        public int TransporterTypeId { get; }
        public Area Area => _area;
        public TransporterType TransporterType => _transporterType;
        public IEnumerable<Part> Parts => _parts;
        public IEnumerable<TransporterAction> Actions => _actions;

        public Transporter(int id, string name, bool active, int area, int transporterType)
        {
            Id = id;
            Name = name;
            Active = active;
            AreaId = area;
            TransporterTypeId = transporterType;
        }

        public Transporter(string name, int area, int transporterType)
        {
            Name = name;
            AreaId = area;
            TransporterTypeId = transporterType;
        }

        public void SetType(TransporterType transporterType)
        {
            _transporterType = transporterType;
        }
        public void SetArea(Area area)
        {
            _area = area;
        }
        public void AddPart(Part part)
        {
            _parts.Add(part);
        }
        public void AddAction(TransporterAction action)
        {
            _actions.Add(action);
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
