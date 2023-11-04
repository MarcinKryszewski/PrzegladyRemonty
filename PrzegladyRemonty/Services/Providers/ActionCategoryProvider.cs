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
    public class ActionCategoryProvider : IProvider<ActionCategory>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                actionCategory (Name, Active)
                VALUES (@Name, True)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM actionCategory
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM actionCategory
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM actionCategory
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE actionCategory
                SET 
                    Name = @Name,
                    Active = @Active
                WHERE Id = @Id
                ";
        #endregion

        public ActionCategoryProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(ActionCategory actionCategory)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Name = actionCategory.Name
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
        public async Task<IEnumerable<ActionCategory>> GetAll()
        {
            using IDbConnection database = _dbContextFactory.Connect();
            IEnumerable<ActionCategoryDTO> actionCategoryDTOs = await database.QueryAsync<ActionCategoryDTO>(_getAllSQL);
            return actionCategoryDTOs.Select(ToActionCategory);
        }
        public ActionCategory GetById(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            ActionCategoryDTO actionCategoryDTO = database.QuerySingleOrDefault<ActionCategoryDTO>(_getOneSQL, parameters);
            return ToActionCategory(actionCategoryDTO);
        }
        public async void Update(ActionCategory actionCategory)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = actionCategory.Id,
                Name = actionCategory.Name

            };
            await database.ExecuteAsync(_updateSQL, parameters);
        }
        #endregion

        private static ActionCategory ToActionCategory(ActionCategoryDTO actionCategoryDTO)
        {
            return new ActionCategory(actionCategoryDTO.Id, actionCategoryDTO.Name);
        }
    }
}