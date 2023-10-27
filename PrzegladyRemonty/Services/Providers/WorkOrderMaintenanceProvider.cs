using PrzegladyRemonty.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Services.Providers
{
    public class WorkOrderProvider : IDatabaseDTOProvider<WorkOrderDTO>
    {
        public void Create(WorkOrderDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkOrderDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public WorkOrderDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkOrderDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
