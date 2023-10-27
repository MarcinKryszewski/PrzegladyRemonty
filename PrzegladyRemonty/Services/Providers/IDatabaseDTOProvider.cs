using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Services.Providers
{
    public interface IDatabaseDTOProvider<T>
    {
        T GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);

    }
}
