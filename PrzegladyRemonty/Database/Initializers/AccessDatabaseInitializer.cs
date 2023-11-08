//using ADOX;
using Dapper;
using PrzegladyRemonty.Database.MS_Access;
using System.Data;
using System.IO;

namespace PrzegladyRemonty.Database.Initializers
{
    public class AccessDatabaseInitializer : IDatabaseInitializer
    {
        private readonly IDbConnection _connection;

        public AccessDatabaseInitializer(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Initialize()
        {
            if (File.Exists("PrzegladyRemonty.accdb")) return;
            CreateEmptyAccdbFile("PrzegladyRemonty.accdb");
            CreateDatabase();
        }
        static void CreateEmptyAccdbFile(string filePath)
        {
            /*
            Catalog catalog = new();
            catalog.Create($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Jet OLEDB:Engine Type=5");
            catalog = null;*/
        }

        private void CreateDatabase()
        {
            foreach (string command in new MsAccessInitCommands().InitCommands)
            {
                _connection.Execute(command);
            }
        }
    }
}