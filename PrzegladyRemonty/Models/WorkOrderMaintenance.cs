namespace PrzegladyRemonty.Models
{
    public class WorkOrderMaintenance
    {
        public int Id { get; }
        public int WorkOrder { get; }
        public int Maintenance { get; }
        public WorkOrderMaintenance(int workOrder, int maintenance)
        {
            WorkOrder = workOrder;
            Maintenance = maintenance;
        }

        public WorkOrderMaintenance(int id, int workOrder, int maintenance)
        {
            Id = id;
            WorkOrder = workOrder;
            Maintenance = maintenance;
        }
    }
}
