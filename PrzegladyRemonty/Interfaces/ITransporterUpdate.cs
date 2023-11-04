using PrzegladyRemonty.Models;
using System.Collections.Generic;

namespace PrzegladyRemonty.Interfaces
{
    public interface ITransporterUpdate
    {
        public void UpdateTransporters(IEnumerable<Transporter> transporters);
    }
}
