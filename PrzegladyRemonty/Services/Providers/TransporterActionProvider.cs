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
    public class TransporterActionProvider : IProvider<TransporterAction>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                transporterAction (Transporter, MaintenanceAction, Frequency, FrequencyUnit)
                VALUES (@Transporter, @MaintenanceAction, @Frequency, @FrequencyUnit)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM transporterAction
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM transporterAction
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM transporterAction
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  transporterAction
                SET 
                    Transporter = @Transporter,
                    MaintenanceAction = @MaintenanceAction,
                    Frequency = @Frequency,
                    FrequencyUnit = @FrequencyUnit
                WHERE Id = @Id
                ";
        #endregion

        public TransporterActionProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(TransporterAction transporterAction)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Transporter = transporterAction.TransporterId,
                MaintenanceAction = transporterAction.ActionId,
                Frequency = transporterAction.Frequency,
                FrequencyUnit = transporterAction.FrequencyUnit
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
        public async Task<IEnumerable<TransporterAction>> GetAll()
        {
            using IDbConnection database = _dbContextFactory.Connect();
            IEnumerable<TransporterActionDTO> transporterActionDTOs = await database.QueryAsync<TransporterActionDTO>(_getAllSQL);
            return transporterActionDTOs.Select(ToTransporterAction);
        }
        public TransporterAction GetById(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            TransporterActionDTO transporterActionDTO = database.QuerySingleOrDefault<TransporterActionDTO>(_getOneSQL, parameters);
            return ToTransporterAction(transporterActionDTO);
        }
        public async void Update(TransporterAction transporterAction)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = transporterAction.Id,
                Transporter = transporterAction.TransporterId,
                MaintenanceAction = transporterAction.ActionId,
                Frequency = transporterAction.Frequency,
                FrequencyUnit = transporterAction.FrequencyUnit

            };
            await database.ExecuteAsync(_updateSQL, parameters);
        }
        #endregion

        private static TransporterAction ToTransporterAction(TransporterActionDTO transporterActionDTO)
        {
            return new TransporterAction
                (
                    transporterActionDTO.Id,
                    transporterActionDTO.Transporter,
                    transporterActionDTO.MaintenanceAction,
                    transporterActionDTO.Frequency,
                    transporterActionDTO.FrequencyUnit
                );
        }
    }
}