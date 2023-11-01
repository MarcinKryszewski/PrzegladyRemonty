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
    public class PersonPermissionProvider : IDatabaseDTOProvider<PersonPermission>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                personPermission (Person, Permission)
                VALUES (@Person, @Permission)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM personPermission
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM personPermission
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM personPermission
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  personPermission
                SET 
                    Person = @Person,
                    Permission = @Permission
                WHERE Id = @Id
                ";
        #endregion

        public PersonPermissionProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(PersonPermission personPermission)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Person = personPermission.Person,
                    Permission = personPermission.Permission
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
        public async Task<IEnumerable<PersonPermission>> GetAll()
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                IEnumerable<PersonPermissionDTO> personPermissionDTOs = await database.QueryAsync<PersonPermissionDTO>(_getAllSQL);
                return personPermissionDTOs.Select(ToPersonPermission);
            }
        }
        public PersonPermission GetById(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                PersonPermissionDTO personPermissionDTO = database.QuerySingleOrDefault<PersonPermissionDTO>(_getOneSQL, parameters);
                return ToPersonPermission(personPermissionDTO);
            }
        }
        public async void Update(PersonPermission personPermission)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = personPermission.Id,
                    Person = personPermission.Person,
                    Permission = personPermission.Permission
                };
                await database.ExecuteAsync(_updateSQL, parameters);
            }
        }
        #endregion

        private static PersonPermission ToPersonPermission(PersonPermissionDTO personPermissionDTO)
        {
            return new PersonPermission
                (
                    personPermissionDTO.Id,
                    personPermissionDTO.Person,
                    personPermissionDTO.Permission
                );
        }
    }
}