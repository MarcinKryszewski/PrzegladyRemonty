using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class AreaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public LineDTO Line { get; set; }
        public ICollection<TransporterDTO> Transporters { get; set; }
    }
}