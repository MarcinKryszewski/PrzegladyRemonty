using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class MaintenanceDTO
    {
        public int Id { get; set; }
        public string MaintenanceDate { get; set; }
        public int Completed { get; set; }
        public string Comment { get; set; }
        public UserDTO Mechanic { get; set; }
        public TransporterActionDTO Action { get; set; }
        public ICollection<WorkOrderDTO> WorkOrders { get; set; }
    }
}