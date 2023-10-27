using PrzegladyRemonty.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Services.Providers
{
    public class AreaProvider : IDatabaseDTOProvider<AreaDTO>
    {
        public void Create(AreaDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AreaDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public AreaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AreaDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
