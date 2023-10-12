using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class Maintenance
    {
        public int Id { get; set; }
        public string MaintenanceDate { get; set; }
        public int Completed { get; set; }
        public string Comment { get; set; }
        public User Mechanic { get; set; }
        public TransporterAction Action { get; set; }
        public ICollection<WorkOrderMaintenance> WorkOrderMaintenances { get; set; }
    }
}