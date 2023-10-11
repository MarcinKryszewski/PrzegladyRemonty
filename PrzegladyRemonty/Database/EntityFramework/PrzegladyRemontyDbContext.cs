using Microsoft.EntityFrameworkCore;
using PrzegladyRemonty.Database.DTOs;

namespace PrzegladyRemonty.Database.EntityFramework
{
    public class PrzegladyRemontyDbContext : DbContext
    {
        public PrzegladyRemontyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ActionCategory> ActionsCategories { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<TransporterAction> TransportersActions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UsersPermissions { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderMaintenance> WorkOrdersMaintenances { get; set; }
    }
}