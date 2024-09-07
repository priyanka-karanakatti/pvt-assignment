using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PTVGroupRepository.Models;

namespace PTVGroupRepository.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("PtvDbConnectionString"), x => x.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("postgis");
        }
        public DbSet<StreetModel> Street { get; set; }

    }
}
