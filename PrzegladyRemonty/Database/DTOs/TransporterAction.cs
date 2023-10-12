using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class TransporterAction
    {
        public int Id { get; set; }
        public ICollection<Maintenance> Maintenances { get; set; }
        public int TransporterId { get; set; }
        public Transporter Transporter { get; set; }
        public int ActionId { get; set; }
        public ActionCategory Action { get; set; }
    }
}