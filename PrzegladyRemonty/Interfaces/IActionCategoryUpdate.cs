using PrzegladyRemonty.Models;
using System.Collections.Generic;

namespace PrzegladyRemonty.Interfaces
{
    public interface IActionCategoryUpdate
    {
        public void UpdateActions(IEnumerable<ActionCategory> actions);
    }
}
