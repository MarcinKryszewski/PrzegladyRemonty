using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class WorkOrderMaintenance
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public int MaintenanceId { get; set; }
        public Maintenance Maintenance { get; set; }
        public ICollection<WorkOrderMaintenance> WorkOrderMaintenances { get; set; }
    }
}