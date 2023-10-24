using Dapper;
using PrzegladyRemonty.Database.MS_Access;
using System.Data;
using System.IO;

namespace PrzegladyRemonty.Database.Initializers
{
    public class AccessDatabaseInitializer : IDatabaseInitializer
    {
        private const string CREATE_RESERVATIONS_TABLE_SQL = @"
            CREATE TABLE Reservations (
                Id TEXT PRIMARY KEY, 
                FloorNumber INTEGER,
                RoomNumber INTEGER,
                Username TEXT,
                StartTime TEXT,
                EndTime TEXT
            )";

        private readonly IDbConnection _connection;

        public AccessDatabaseInitializer(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Initialize()
        {
            if (File.Exists("PrzegladyRemonty.accdb")) return;
            CreateNewDatabase();
        }

        private void CreateNewDatabase()
        {
            File.Copy("Database\\MS Access\\PrzegladyRemonty.accdb", "PrzegladyRemonty.accdb", true);
            foreach (string command in new MsAccessInitCommands().InitCommands)
            {
                _connection.Execute(command);
            }
        }
    }
}