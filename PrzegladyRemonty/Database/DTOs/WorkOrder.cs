using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Database.DTOs
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public User User { get; set; }
    }
}