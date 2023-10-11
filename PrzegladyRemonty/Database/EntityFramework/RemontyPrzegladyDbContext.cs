using Microsoft.EntityFrameworkCore;

namespace PrzegladyRemonty.Database.EntityFramework
{
    public class RemontyPrzegladyDbContext : DbContext
    {
        public RemontyPrzegladyDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<ReservationDTO> Reservations { get; set; }
    }
}