#region Usings
using Dapper;
using PrzegladyRemonty.Database;
using PrzegladyRemonty.Database.DTOs;
using PrzegladyRemonty.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace PrzegladyRemonty.Services.Providers
{
    public class WorkOrderMaintenanceProvider : IDatabaseDTOProvider<WorkOrderMaintenance>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                workOrderMaintenance (WorkOrder, Maintenance)
                VALUES (@WorkOrder, @Maintenance)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM workOrderMaintenance
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM workOrderMaintenance
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM workOrderMaintenance
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  workOrderMaintenance
                SET (
                    WorkOrder = @WorkOrder,
                    Maintenance = @Maintenance
                )
                WHERE Id = @Id
                ";
        #endregion

        public WorkOrderMaintenanceProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(WorkOrderMaintenance workOrderMaintenance)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    WorkOrder = workOrderMaintenance.WorkOrder,
                    Maintenance = workOrderMaintenance.Maintenance
                };
                await database.ExecuteAsync(_createSQL, parameters);
            }
        }
        public async void Delete(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                await database.ExecuteAsync(_deleteSQL, parameters);
            }
        }
        public async Task<IEnumerable<WorkOrderMaintenance>> GetAll()
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                IEnumerable<WorkOrderMaintenanceDTO> workOrderMaintenanceDTOs = await database.QueryAsync<WorkOrderMaintenanceDTO>(_getAllSQL);
                return workOrderMaintenanceDTOs.Select(ToWorkOrderMaintenance);
            }
        }
        public WorkOrderMaintenance GetById(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                WorkOrderMaintenanceDTO workOrderMaintenanceDTO = database.QuerySingleOrDefault<WorkOrderMaintenanceDTO>(_getOneSQL, parameters);
                return ToWorkOrderMaintenance(workOrderMaintenanceDTO);
            }
        }
        public async void Update(WorkOrderMaintenance workOrderMaintenance)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = workOrderMaintenance.Id,
                    WorkOrder = workOrderMaintenance.WorkOrder,
                    Maintenance = workOrderMaintenance.Maintenance

                };
                await database.ExecuteAsync(_updateSQL, parameters);
            }
        }
        #endregion

        private static WorkOrderMaintenance ToWorkOrderMaintenance(WorkOrderMaintenanceDTO workOrderMaintenanceDTO)
        {
            return new WorkOrderMaintenance
                (
                    workOrderMaintenanceDTO.Id,
                    workOrderMaintenanceDTO.WorkOrder,
                    workOrderMaintenanceDTO.Maintenance
                );
        }
    }
}