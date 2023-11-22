namespace PrzegladyRemonty.Models
{
    public class TransporterPart
    {
        private Part _part;
        private Transporter _transporter;

        public int Id { get; }
        public int TransporterId { get; }
        public int PartId { get; }
        public int Amount { get; }
        public string Unit { get; }
        public Part Part => _part;
        public Transporter Transporter => _transporter;

        public TransporterPart(int transporter, int part, int amount, string unit)
        {
            TransporterId = transporter;
            PartId = part;
            Amount = amount;
            Unit = unit;
        }

        public TransporterPart(int id, int transporter, int part, int amount, string unit)
        {
            Id = id;
            TransporterId = transporter;
            PartId = part;
            Amount = amount;
            Unit = unit;
        }

        public void SetTransporter(Transporter transporter)
        {
            _transporter = transporter;
        }

        public void SetPart(Part part)
        {
            _part = part;
        }
    }
}