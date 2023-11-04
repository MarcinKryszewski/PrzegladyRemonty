using PrzegladyRemonty.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Interfaces
{
    public interface IProvider
    {
        IModel GetById(int id);
        Task<IEnumerable<IModel>> GetAll();
        void Create(IModel item);
        void Update(IModel item);
        Task Delete(int id);
    }
}
