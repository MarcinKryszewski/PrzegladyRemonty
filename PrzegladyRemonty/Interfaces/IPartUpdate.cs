using PrzegladyRemonty.Models;
using System.Collections.Generic;

namespace PrzegladyRemonty.Interfaces
{
    public interface IPartUpdate
    {
        public void UpdateParts(IEnumerable<Part> parts);
    }
}