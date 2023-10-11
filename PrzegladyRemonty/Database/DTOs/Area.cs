using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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