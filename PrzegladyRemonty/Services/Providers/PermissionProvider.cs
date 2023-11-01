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
    public class PermissionProvider : IDatabaseDTOProvider<Permission>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                permission (Name, PermissionValue)
                VALUES (@Name, @PermissionValue)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM permission
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM permission
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM permission
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  permission
                SET 
                    Name = @Name,
                    PermissionValue = @PermissionValue
                WHERE Id = @Id
                ";
        #endregion

        public PermissionProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(Permission permission)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Name = permission.Name,
                    PermissionValue = permission.PermissionValue
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
        public async Task<IEnumerable<Permission>> GetAll()
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                IEnumerable<PermissionDTO> permissionDTOs = await database.QueryAsync<PermissionDTO>(_getAllSQL);
                return permissionDTOs.Select(ToPermission);
            }
        }
        public Permission GetById(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                PermissionDTO permissionDTO = database.QuerySingleOrDefault<PermissionDTO>(_getOneSQL, parameters);
                return ToPermission(permissionDTO);
            }
        }
        public async void Update(Permission permission)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    PermissionValue = permission.PermissionValue

                };
                await database.ExecuteAsync(_updateSQL, parameters);
            }
        }
        #endregion

        private static Permission ToPermission(PermissionDTO permissionDTO)
        {
            return new Permission(
                permissionDTO.Id,
                permissionDTO.Name,
                permissionDTO.PermissionValue);
        }
    }
}