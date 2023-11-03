namespace PrzegladyRemonty.Models
{
    public class TransporterType
    {
        public int Id { get; }
        public string Name { get; }

        public TransporterType(string name)
        {
            Name = name;
        }
        public TransporterType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
