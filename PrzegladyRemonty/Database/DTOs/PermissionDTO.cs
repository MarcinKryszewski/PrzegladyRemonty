using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}