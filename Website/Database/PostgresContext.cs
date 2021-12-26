using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.Database
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
