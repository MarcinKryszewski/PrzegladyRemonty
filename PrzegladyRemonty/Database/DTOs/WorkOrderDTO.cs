using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class WorkOrderDTO
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public UserDTO CreatedBy { get; set; }
        public ICollection<MaintenanceDTO> Maintenances { get; set; }
    }
}