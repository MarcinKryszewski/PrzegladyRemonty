using Dapper;
using PrzegladyRemonty.Database;
using PrzegladyRemonty.Database.DTOs;
using PrzegladyRemonty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Services.Providers
{
    public class LineProvider : IDatabaseDTOProvider<Line>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        private const string _createSQL = @"
            INSERT INTO
            line (Name, Active)
            VALUES (@Name, True)
            ";
        private const string _deleteSQL = "";
        private const string _getAllSQL = @"
            SELECT *
            FROM line
            ";
        private const string _getOneSQL = @"
            SELECT *
            FROM line
            WHERE Id = @Id
            ";
        private const string _updateSQL = "";

        public LineProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Line>> GetAll()
        {
            throw new NotImplementedException();
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

        public void Update(Line item)
        {
            throw new NotImplementedException();
        }

        private static Line ToLine(LineDTO lineDTO)
        {
            return new Line(lineDTO.Name);
        }
    }
}
