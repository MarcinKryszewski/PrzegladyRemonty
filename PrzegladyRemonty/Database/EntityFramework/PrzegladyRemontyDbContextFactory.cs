using Microsoft.EntityFrameworkCore;

namespace PrzegladyRemonty.Database.EntityFramework
{
    public class PrzegladyRemontyDbContextFactory
    {
        private readonly string _connectionString;

        public PrzegladyRemontyDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PrzegladyRemontyDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new PrzegladyRemontyDbContext(options);
        }
    }
}