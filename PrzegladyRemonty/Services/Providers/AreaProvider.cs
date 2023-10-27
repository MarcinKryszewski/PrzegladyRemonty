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
    public class AreaProvider : IDatabaseDTOProvider<Area>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                area (Name, Active, Line)
                VALUES (@Name, True, @Line)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM area
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM area
                ";


        private const string _getOneSQL = @"
                SELECT *
                FROM area
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  area
                SET (
                    Name = @Name,
                    Active = @Active,
                    Line = @Line
                )
                WHERE Id = @Id
                ";
        #endregion

        public AreaProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(Area area)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Name = area.Name,
                    Line = area.Line
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
        public async Task<IEnumerable<Area>> GetAll()
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                IEnumerable<AreaDTO> areasDTO = await database.QueryAsync<AreaDTO>(_getAllSQL);
                return areasDTO.Select(ToArea);
            }
        }
        public Area GetById(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                AreaDTO areaDTO = database.QuerySingleOrDefault<AreaDTO>(_getOneSQL, parameters);
                return ToArea(areaDTO);
            }
        }
        public async void Update(Area area)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = area.Id,
                    Name = area.Name,
                    Active = area.Active,
                    Line = area.Line

                };
                await database.ExecuteAsync(_updateSQL, parameters);
            }
        }
        #endregion

        private static Area ToArea(AreaDTO areaDTO)
        {
            return new Area(areaDTO.Id, areaDTO.Name, areaDTO.Active, areaDTO.Line);
        }
    }
}