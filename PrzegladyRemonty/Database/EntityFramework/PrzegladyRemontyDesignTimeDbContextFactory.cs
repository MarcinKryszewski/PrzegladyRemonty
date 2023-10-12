using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PrzegladyRemonty.Database.EntityFramework
{
    public class PrzegladyRemontyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PrzegladyRemontyDbContext>
    {
        public PrzegladyRemontyDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=PrzegladyRemonty.db").Options;

            return new PrzegladyRemontyDbContext(options);
        }
    }
}
