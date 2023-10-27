using PrzegladyRemonty.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Services.Providers
{
    public class MaintenanceProvider : IDatabaseDTOProvider<MaintenanceDTO>
    {
        public void Create(MaintenanceDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaintenanceDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public MaintenanceDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MaintenanceDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
