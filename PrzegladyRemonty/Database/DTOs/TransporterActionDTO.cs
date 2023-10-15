using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class TransporterActionDTO
    {
        public int Id { get; set; }
        public ICollection<MaintenanceDTO> Maintenances { get; set; }
        public int TransporterId { get; set; }
        public TransporterDTO Transporter { get; set; }
        public int ActionId { get; set; }
        public ActionCategoryDTO Action { get; set; }
        public int Frequency { get; set; }
        public int FrequencyUnit { get; set; }
    }
}