using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzegladyRemonty.DTOs
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