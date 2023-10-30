using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Data.OleDb;

namespace PrzegladyRemonty.Database
{
    public class DatabaseConnectionFactory : IDisposable
    {
        private readonly IConfiguration _configuration;
        private DbConnection _connection;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection Connect()
        {
            string databaseType = _configuration["DatabaseType"];
            string connectionString;

            switch (databaseType)
            {
                case "SQLite":
                    connectionString = _configuration.GetConnectionString("SQLiteConnection");
                    _connection = new SqliteConnection(connectionString);
                    break;

                case "Access":
                    connectionString = _configuration.GetConnectionString("AccessConnection");
                    _connection = new OleDbConnection(connectionString);
                    break;

                default:
                    throw new InvalidOperationException("Invalid or unsupported database type.");
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
