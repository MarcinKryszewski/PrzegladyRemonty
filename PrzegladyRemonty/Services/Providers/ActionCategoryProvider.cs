using PrzegladyRemonty.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Services.Providers
{
    public class ActionCategoryProvider : IDatabaseDTOProvider<ActionCategoryDTO>
    {


        public ActionCategoryProvider()
        {

        }

        public void Create(ActionCategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ActionCategoryDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ActionCategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActionCategoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
