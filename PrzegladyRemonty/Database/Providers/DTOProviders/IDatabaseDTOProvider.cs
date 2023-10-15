using System.Collections.Generic;

namespace PrzegladyRemonty.Database.Providers
{
    public interface IDatabaseDTOProvider<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
