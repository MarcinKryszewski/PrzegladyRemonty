namespace PrzegladyRemonty.Models
{
    public class Part
    {
        public int Id { get; }
        public string Name { get; }
        public string Producent { get; }
        public string ProducentNumber { get; }

        public Part(string name, string producent, string producentNumber)
        {
            Name = name;
            Producent = producent;
            ProducentNumber = producentNumber;
        }

        public Part(int id, string name, string producent, string producentNumber)
        {
            Id = id;
            Name = name;
            Producent = producent;
            ProducentNumber = producentNumber;
        }

    }
}
