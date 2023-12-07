using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrzegladyRemonty.Models
{
    public class WorkOrder
    {
        private ObservableCollection<Maintenance> _maintenances;
        private Person _creator;
        private string _status;

        public int Id { get; }
        public string Created { get; }
        public DateOnly CreatedDate => DateOnly.Parse(Created);
        public int CreatedBy { get; }
        public Person Creator => _creator;
        public string Status => _status;
        public IEnumerable<Maintenance> Maintenances => _maintenances;
        public int MaintenancesAmount => _maintenances.Count;
        public int CompletedTasks { get; set; }

        public WorkOrder(string created, int createdBy, string status = "Otwarte")
        {
            Created = created;
            CreatedBy = createdBy;
            _status = status;
            _maintenances = new();
        }

        public WorkOrder(int id, string created, int createdBy, string status = "Otwarte")
        {
            Id = id;
            Created = created;
            CreatedBy = createdBy;
            _status = status;
            _maintenances = new();
        }

        public void AddMaintenance(Maintenance maintenance)
        {
            _maintenances.Add(maintenance);
        }

        public void RemoveMaintenance(Maintenance maintenance)
        {
            _maintenances.Remove(maintenance);
        }

        public void SetCreator(Person creator)
        {
            _creator = creator;
        }

        public void SetStatus(string status)
        {
            _status = status;
        }
    }
}
