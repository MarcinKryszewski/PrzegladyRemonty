#region Usings
using Dapper;
using PrzegladyRemonty.Database;
using PrzegladyRemonty.Database.DTOs;
using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace PrzegladyRemonty.Services.Providers
{
    public class WorkOrderProvider : IProvider<WorkOrder>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                workOrder (Created, CreatedBy)
                VALUES (@Created, @CreatedBy)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM workOrder
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM workOrder
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM workOrder
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  workOrder
                SET 
                    Created = @Created,
                    CreatedBy = @CreatedBy
                WHERE Id = @Id
                ";
        #endregion

        public WorkOrderProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(WorkOrder workOrder)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Created = workOrder.Created,
                CreatedBy = workOrder.CreatedBy
            };
            await database.ExecuteAsync(_createSQL, parameters);
        }
        public async Task Delete(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            await database.ExecuteAsync(_deleteSQL, parameters);
        }
        public async Task<IEnumerable<WorkOrder>> GetAll()
        {
            using IDbConnection database = _dbContextFactory.Connect();
            IEnumerable<WorkOrderDTO> workOrderDTOs = await database.QueryAsync<WorkOrderDTO>(_getAllSQL);
            return workOrderDTOs.Select(ToWorkOrder);
        }
        public WorkOrder GetById(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            WorkOrderDTO workOrderDTO = database.QuerySingleOrDefault<WorkOrderDTO>(_getOneSQL, parameters);
            return ToWorkOrder(workOrderDTO);
        }
        public async void Update(WorkOrder workOrder)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = workOrder.Id,
                Created = workOrder.Created,
                CreatedBy = workOrder.CreatedBy

            };
            await database.ExecuteAsync(_updateSQL, parameters);
        }
        #endregion

        private static WorkOrder ToWorkOrder(WorkOrderDTO workOrderDTO)
        {
            return new WorkOrder
                (
                    workOrderDTO.Id,
                    workOrderDTO.Created,
                    workOrderDTO.CreatedBy
                );
        }
    }
}