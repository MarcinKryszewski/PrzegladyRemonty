using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; }
        public ICollection<WorkOrderDTO> WorkOrders { get; set; }
        public ICollection<MaintenanceDTO> Maintenances { get; set; }
        public ICollection<PermissionDTO> Permissions { get; set; }
    }
}