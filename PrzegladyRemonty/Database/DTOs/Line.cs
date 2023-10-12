using System.Collections.Generic;

namespace PrzegladyRemonty.Database.DTOs
{
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}