namespace PrzegladyRemonty.Database.DTOs
{
    public class MaintenanceDTO
    {
        public int Id { get; set; }
        public string MaintenanceDate { get; set; }
        public int Mechanic { get; set; }
        public int MaintenanceAction { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
    }
}