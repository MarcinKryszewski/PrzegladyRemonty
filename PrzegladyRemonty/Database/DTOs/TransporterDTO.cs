namespace PrzegladyRemonty.Database.DTOs
{
    public class TransporterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string LastMaintenance { get; set; }
        public int Area { get; set; }
    }
}