namespace PrzegladyRemonty.Database.DTOs
{
    public class TransporterPartDTO
    {
        public int Id { get; set; }
        public int Transporter { get; set; }
        public int Part { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}

