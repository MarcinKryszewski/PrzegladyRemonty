using PrzegladyRemonty.Interfaces;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Models
{
    public interface IModel
    {
        public void Add(IProvider provider);
        public void Edit(IProvider provider);
        public Task Remove(IProvider provider);

    }
}