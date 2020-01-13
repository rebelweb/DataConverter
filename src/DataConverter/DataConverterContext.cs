using Microsoft.EntityFrameworkCore;

namespace DataConverter
{
    public class DataConverterContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataConverterContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}