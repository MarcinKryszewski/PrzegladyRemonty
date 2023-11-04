#region Usingsset;
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
    public class PartProvider : IProvider<Part>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                part (Name, Producent, ProducentNumber)
                VALUES (@Name, @Producent, @ProducentNumber)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM part
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM part
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM part
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  part
                SET 
                    Name = @Name,
                    Producent = @Producent,
                    ProducentNumber = @ProducentNumber
                WHERE Id = @Id
                ";
        #endregion

        public PartProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(Part part)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Name = part.Name,
                Producent = part.Producent,
                ProducentNumber = part.ProducentNumber
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
        public async Task<IEnumerable<Part>> GetAll()
        {
            using IDbConnection database = _dbContextFactory.Connect();
            IEnumerable<PartDTO> partDTOs = await database.QueryAsync<PartDTO>(_getAllSQL);
            return partDTOs.Select(ToPart);
        }
        public Part GetById(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            PartDTO partDTO = database.QuerySingleOrDefault<PartDTO>(_getOneSQL, parameters);
            return ToPart(partDTO);
        }
        public async void Update(Part part)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = part.Id,
                Name = part.Name,
                Producent = part.Producent,
                ProducentNumber = part.ProducentNumber

            };
            await database.ExecuteAsync(_updateSQL, parameters);
        }
        #endregion

        private static Part ToPart(PartDTO partDTO)
        {
            return new Part
                (
                    partDTO.Id,
                    partDTO.Name,
                    partDTO.Producent,
                    partDTO.ProducentNumber
                );
        }
    }
}