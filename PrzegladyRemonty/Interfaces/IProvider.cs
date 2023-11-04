using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Interfaces
{
    public interface IProvider<T>
    {
        T GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Create(T item);
        void Update(T item);
        Task Delete(int id);
    }
}
