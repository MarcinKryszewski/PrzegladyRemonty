using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public Line Line { get; set; }
        public ICollection<Transporter> Transporters { get; set; }
    }
}