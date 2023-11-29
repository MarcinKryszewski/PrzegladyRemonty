namespace PrzegladyRemonty.Database.DTOs
{
    public class TransporterActionDTO
    {
        public int Id { get; set; }
        public int Transporter { get; set; }
        public int MaintenanceAction { get; set; }
        public int Frequency { get; set; }
        public string FrequencyUnit { get; set; }
        public string Status { get; set; }
    }
}