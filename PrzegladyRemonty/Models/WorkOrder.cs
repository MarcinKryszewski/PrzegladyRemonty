using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrzegladyRemonty.Models
{
    public class WorkOrder
    {
        private ObservableCollection<Maintenance> _maintenances;
        public int Id { get; }
        public string Created { get; }
        public int CreatedBy { get; }
        public string Status { get; }
        public IEnumerable<Maintenance> Maintenances => _maintenances;

        public WorkOrder(string created, int createdBy, string status = "Otwarte")
        {
            Created = created;
            CreatedBy = createdBy;
            Status = status;
        }

        public WorkOrder(int id, string created, int createdBy, string status = "Otwarte")
        {
            Id = id;
            Created = created;
            CreatedBy = createdBy;
            Status = status;
        }

        public void AddMaintenance(Maintenance maintenance)
        {
            _maintenances.Add(maintenance);
        }

        public void RemoveMaintenance(Maintenance maintenance)
        {
            _maintenances.Remove(maintenance);
        }
    }
}
