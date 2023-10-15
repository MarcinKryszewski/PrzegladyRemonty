using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class LineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public ICollection<AreaDTO> Areas { get; set; }
    }
}