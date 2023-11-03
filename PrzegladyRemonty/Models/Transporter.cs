using System;

namespace PrzegladyRemonty.Models
{
    public class Transporter
    {
        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public int Area { get; }
        public DateTime LastMaintenance { get; }
        public int TransporterType { get; }

        public Transporter(int id, string name, bool active, int area, int transporterType)
        {
            Id = id;
            Name = name;
            Active = active;
            Area = area;
            TransporterType = transporterType;
        }

        public Transporter(string name, int area, int transporterType)
        {
            Name = name;
            Area = area;
            TransporterType = transporterType;
        }
    }
}
