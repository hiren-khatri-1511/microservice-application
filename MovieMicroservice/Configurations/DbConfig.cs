using Microsoft.EntityFrameworkCore;
using MovieMicroservice.Models;

namespace MovieMicroservice.Configurations
{
    public class DbConfig: DbContext
    {
        public DbConfig(DbContextOptions<DbConfig> options) : base(options)
        {

        }
        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
