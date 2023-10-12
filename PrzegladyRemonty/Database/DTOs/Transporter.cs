using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class Transporter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string LastMaintenance { get; set; }
        public Area Area { get; set; }
        public ICollection<TransporterAction> TransporterActions { get; set; }
    }
}