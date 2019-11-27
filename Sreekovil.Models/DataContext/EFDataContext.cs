using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sreekovil.Models.Models;
using Sreekovil.Models.Configurations;

namespace Sreekovil.Models.DataContext
{
    public class EFDataContext : DbContext
    {
        private IConfiguration _config;

        public EFDataContext(DbContextOptions<EFDataContext> options, IConfiguration configuration) : base(options)
        {
            _config = configuration;
        }

        public DbSet<Deity> Deities { get; set; }

        public DbSet<Offering> Offerings { get; set; }

        public DbSet<OfferingTransaction> OfferingTransactions { get; set; }

        public DbSet<OfferingPreBooking> OfferingPreBookings { get; set; }

        public DbSet<StarSign> StarSigns { get; set; }

        public DbSet<Temple> Temples { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetSection("ConnectionStrings")["SreekovilDev"];

            optionsBuilder.UseMySQL(connectionString,
                  mySqlOptions =>
                  {
                      mySqlOptions.MigrationsAssembly("Sreekovil.Models");
                  });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurations();
        }

    }
}
