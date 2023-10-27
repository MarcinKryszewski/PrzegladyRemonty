namespace PrzegladyRemonty.Models
{
    public class Transporter
    {
        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public int Area { get; }

        public Transporter(int id, string name, bool active, int area)
        {
            Id = id;
            Name = name;
            Active = active;
            Area = area;
        }

        public Transporter(string name, int area)
        {
            Name = name;
            Area = area;
        }
    }
}
