using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class ActionCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TransporterDTO> Transporters { get; set; }
    }
}