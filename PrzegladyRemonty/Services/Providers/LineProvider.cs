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
    public class LineProvider : IDatabaseDTOProvider<Line>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                line (Name, Active)
                VALUES (@Name, True)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM line
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM line
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM line
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  line
                SET 
                    Name = @Name,
                    Active = @Active                
                WHERE Id = @Id
                ";
        #endregion

        public LineProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(Line line)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Name = line.Name
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
        public async Task<IEnumerable<Line>> GetAll()
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                IEnumerable<LineDTO> lineDTOs = await database.QueryAsync<LineDTO>(_getAllSQL);
                return lineDTOs.Select(ToLine);
            }
        }
        public Line GetById(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                LineDTO lineDTO = database.QuerySingleOrDefault<LineDTO>(_getOneSQL, parameters);
                return ToLine(lineDTO);
            }
        }
        public async void Update(Line line)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = line.Id,
                    Name = line.Name,
                    Active = line.Active

                };
                await database.ExecuteAsync(_updateSQL, parameters);
            }
        }
        #endregion

        private static Line ToLine(LineDTO lineDTO)
        {
            return new Line(lineDTO.Id, lineDTO.Name, lineDTO.Active);
        }
    }
}