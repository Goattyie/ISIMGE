using Common.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace DatabaseServer.Database
{
    public class PostgresConnection : DbContext
    {
        public PostgresConnection(DbContextOptions<PostgresConnection> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceTask> Tasks { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
