using PrzegladyRemonty.Models;
using System.Collections.Generic;

namespace PrzegladyRemonty.Interfaces
{
    public interface IAreaUpdate
    {
        public void UpdateAreas(IEnumerable<Area> areas);
    }
}
