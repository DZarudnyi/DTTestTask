using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Clients.Context
{
    public class BaseDbContext : DbContext
    {
        public IConfiguration _config { get; set; }

        public BaseDbContext(DbContextOptions<BaseDbContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}
