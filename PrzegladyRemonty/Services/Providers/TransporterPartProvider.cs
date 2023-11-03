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
    public class TransporterPartProvider : IDatabaseDTOProvider<TransporterPart>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                transporterPart (Transporter, Part, Amount, Unit)
                VALUES (@Transporter, @Part, @Amount, @Unit)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM transporterPart
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM transporterPart
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM transporterPart
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  transporterPart
                SET 
                    Transporter = @Transporter,
                    Part = @Part,
                    Amount = @Amount,
                    Unit = Unit
                WHERE Id = @Id
                ";
        #endregion

        public TransporterPartProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(TransporterPart transporterPart)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Transporter = transporterPart.Transporter,
                Part = transporterPart.Part,
                Amount = transporterPart.Amount,
                Unit = transporterPart.Unit
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
        public async Task<IEnumerable<TransporterPart>> GetAll()
        {
            using IDbConnection database = _dbContextFactory.Connect();
            IEnumerable<TransporterPartDTO> transporterPartDTOs = await database.QueryAsync<TransporterPartDTO>(_getAllSQL);
            return transporterPartDTOs.Select(ToTransporterPart);
        }
        public TransporterPart GetById(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            TransporterPartDTO transporterPartDTO = database.QuerySingleOrDefault<TransporterPartDTO>(_getOneSQL, parameters);
            return ToTransporterPart(transporterPartDTO);
        }
        public async void Update(TransporterPart transporterPart)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = transporterPart.Id,
                Transporter = transporterPart.Transporter,
                Part = transporterPart.Part,
                Amount = transporterPart.Amount,
                Unit = transporterPart.Unit

            };
            await database.ExecuteAsync(_updateSQL, parameters);
        }
        #endregion

        private static TransporterPart ToTransporterPart(TransporterPartDTO transporterPartDTO)
        {
            return new TransporterPart
                (
                    transporterPartDTO.Id,
                    transporterPartDTO.Transporter,
                    transporterPartDTO.Part,
                    transporterPartDTO.Amount,
                    transporterPartDTO.Unit
                );
        }
    }
}