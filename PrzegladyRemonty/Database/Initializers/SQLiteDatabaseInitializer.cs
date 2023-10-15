using Dapper;
using System.Data;

namespace PrzegladyRemonty.Database.Initializers
{
    public class SQLiteDatabaseInitializer : IDatabaseInitializer
    {
        private const string CREATE_RESERVATIONS_TABLE_SQL = @"
            CREATE TABLE IF NOT EXISTS Reservations (
                Id TEXT PRIMARY KEY, 
                FloorNumber INTEGER,
                RoomNumber INTEGER,
                Username TEXT,
                StartTime TEXT,
                EndTime TEXT
            )";

        private readonly IDbConnection _connection;

        public SQLiteDatabaseInitializer(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Initialize()
        {
            //SQLiteConnection.CreateFile("PrzeladyRemonty.db");
            using (_connection)
            {
                _connection.Open();
                _connection.Execute(CREATE_RESERVATIONS_TABLE_SQL);
            }
        }
    }
}
