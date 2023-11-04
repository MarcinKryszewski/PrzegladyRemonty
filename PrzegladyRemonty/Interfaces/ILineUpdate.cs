using PrzegladyRemonty.Models;
using System.Collections.Generic;

namespace PrzegladyRemonty.Interfaces
{
    public interface ILineUpdate
    {
        public void UpdateLines(IEnumerable<Line> lines);
    }
}