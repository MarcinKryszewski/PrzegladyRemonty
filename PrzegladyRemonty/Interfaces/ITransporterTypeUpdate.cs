using PrzegladyRemonty.Models;
using System.Collections.Generic;

namespace PrzegladyRemonty.Interfaces
{
    public interface ITransporterTypeUpdate
    {
        public void UpdateTransporterTypes(IEnumerable<TransporterType> transporterTypes);
    }
}
