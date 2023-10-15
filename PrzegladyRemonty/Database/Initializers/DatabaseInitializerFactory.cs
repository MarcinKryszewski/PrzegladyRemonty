using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace PrzegladyRemonty.Database.Initializers
{
    public class DatabaseInitializerFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        private string _databaseType;

        public DatabaseInitializerFactory(IConfiguration configuration, IDbConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
            _databaseType = _configuration["DatabaseType"];
        }

        public IDatabaseInitializer CreateInitializer()
        {
            switch (_databaseType)
            {
                case "SQLite":
                    return new SQLiteDatabaseInitializer(_connection);
                case "Access":
                    return new AccessDatabaseInitializer(_connection);
                default:
                    throw new InvalidOperationException("Invalid or unsupported database type.");
            }
        }
    }
}
