using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzegladyRemonty.DTOs
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; }
        public ICollection<Maintenance> Maintenances { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}