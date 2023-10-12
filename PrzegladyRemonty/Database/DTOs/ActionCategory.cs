using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class ActionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public int MyProperty { get; set; }
        public ICollection<TransporterAction> TransporterActions { get; set; }
    }
}