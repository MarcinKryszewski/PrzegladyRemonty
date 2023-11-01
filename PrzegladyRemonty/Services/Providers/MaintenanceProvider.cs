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
    public class MaintenanceProvider : IDatabaseDTOProvider<Maintenance>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                maintenance (MaintenanceDate, Mechanic, MaintenanceAction, Completed, Description)
                VALUES (@MaintenanceDate, @Mechanic, @MaintenanceAction, FALSE, @Description)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM maintenance
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM maintenance
                ";

        private const string _getOneSQL = @"
                SELECT *
                FROM maintenance
                WHERE Id = @Id
                ";

        private const string _updateSQL = @"
                UPDATE  maintenance
                SET 
                    MaintenanceDate = @MaintenanceDate, 
                    Mechanic = @Mechanic, 
                    MaintenanceAction, = @MaintenanceAction 
                    Completed = @Completed, 
                    Description = @Description
                WHERE Id = @Id
                ";
        #endregion

        public MaintenanceProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(Maintenance maintenance)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    MaintenanceDate = maintenance.MaintenanceDate,
                    Mechanic = maintenance.Mechanic,
                    MaintenanceAction = maintenance.MaintenanceAction,
                    Completed = maintenance.Completed,
                    Description = maintenance.Description
                };
                await database.ExecuteAsync(_createSQL, parameters);
            }
        }
        public async Task Delete(int id)
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
        public async Task<IEnumerable<Maintenance>> GetAll()
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                IEnumerable<MaintenanceDTO> maintenanceDTOs = await database.QueryAsync<MaintenanceDTO>(_getAllSQL);
                return maintenanceDTOs.Select(ToMaintenance);
            }
        }
        public Maintenance GetById(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                MaintenanceDTO maintenanceDTO = database.QuerySingleOrDefault<MaintenanceDTO>(_getOneSQL, parameters);
                return ToMaintenance(maintenanceDTO);
            }
        }
        public async void Update(Maintenance maintenance)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = maintenance.Id,
                    MaintenanceDate = maintenance.MaintenanceDate,
                    Mechanic = maintenance.Mechanic,
                    MaintenanceAction = maintenance.MaintenanceAction,
                    Completed = maintenance.Completed,
                    Description = maintenance.Description

                };
                await database.ExecuteAsync(_updateSQL, parameters);
            }
        }
        #endregion

        private static Maintenance ToMaintenance(MaintenanceDTO maintenanceDTO)
        {
            return new Maintenance(
                maintenanceDTO.Id,
                maintenanceDTO.MaintenanceDate,
                maintenanceDTO.Mechanic,
                maintenanceDTO.MaintenanceAction,
                maintenanceDTO.Completed,
                maintenanceDTO.Description
                );
        }
    }
}