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
    public class TransporterTypeProvider : IProvider<TransporterType>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                transporterType (Name)
                VALUES (@Name)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM transporterType
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM transporterType
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM transporterType
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  transporterType
                SET 
                    Name = @Name
                WHERE Id = @Id
                ";
        #endregion

        public TransporterTypeProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(TransporterType transporterType)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Name = transporterType.Name
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
        public async Task<IEnumerable<TransporterType>> GetAll()
        {
            using IDbConnection database = _dbContextFactory.Connect();
            IEnumerable<TransporterTypeDTO> transporterTypeDTOs = await database.QueryAsync<TransporterTypeDTO>(_getAllSQL);
            return transporterTypeDTOs.Select(ToTransporterType);
        }
        public TransporterType GetById(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            TransporterTypeDTO transporterTypeDTO = database.QuerySingleOrDefault<TransporterTypeDTO>(_getOneSQL, parameters);
            return ToTransporterType(transporterTypeDTO);
        }
        public async void Update(TransporterType transporterType)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = transporterType.Id,
                Name = transporterType.Name

            };
            await database.ExecuteAsync(_updateSQL, parameters);
        }
        #endregion

        private static TransporterType ToTransporterType(TransporterTypeDTO transporterTypeDTO)
        {
            return new TransporterType
                (
                    transporterTypeDTO.Id,
                    transporterTypeDTO.Name
                );
        }
    }
}