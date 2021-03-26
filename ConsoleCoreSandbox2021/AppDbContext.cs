using ConsoleCoreSandbox2021.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ConsoleCoreSandbox2021
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
                optionsBuilder.LogTo(
                    message =>System.Diagnostics.Debug.WriteLine(message),
                    new[] { DbLoggerCategory.Database.Command.Name });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            return connectionString;
        }
    }
}
