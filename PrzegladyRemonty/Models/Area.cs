namespace PrzegladyRemonty.Models
{
    public class Area
    {
        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public int Line { get; }

        public Area(int id, string name, bool active, int line)
        {
            Id = id;
            Name = name;
            Active = active;
            Line = line;
        }

        public Area(string name, int line)
        {
            Name = name;
            Line = line;
        }
    }
}
