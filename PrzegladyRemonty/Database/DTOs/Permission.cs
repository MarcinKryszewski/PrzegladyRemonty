using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Database.DTOs
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}