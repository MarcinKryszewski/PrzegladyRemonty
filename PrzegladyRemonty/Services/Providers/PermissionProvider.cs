using PrzegladyRemonty.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Services.Providers
{
    public class PermissionProvider : IDatabaseDTOProvider<PermissionDTO>
    {
        public void Create(PermissionDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PermissionDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public PermissionDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PermissionDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
