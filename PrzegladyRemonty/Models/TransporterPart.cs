namespace PrzegladyRemonty.Models
{
    public class TransporterPart
    {
        public int Id { get; }
        public int Transporter { get; }
        public int Part { get; }
        public int Amount { get; }
        public string Unit { get; }

        public TransporterPart(int transporter, int part, int amount, string unit)
        {
            Transporter = transporter;
            Part = part;
            Amount = amount;
            Unit = unit;
        }

        public TransporterPart(int id, int transporter, int part, int amount, string unit)
        {
            Id = id;
            Transporter = transporter;
            Part = part;
            Amount = amount;
            Unit = unit;
        }

    }
}