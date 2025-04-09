using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("secrets.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("ConnectionString");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasKey(a => a.Id);
            modelBuilder.Entity<AuthorizedUser>().HasKey(user => user.Id);
            modelBuilder.Entity<RegistrationKey>().HasKey(key => key.Id);
            modelBuilder.Entity<Image>().HasKey(image => image.Id);
            modelBuilder.Entity<Album>().HasKey(album => album.Id);
            modelBuilder.Entity<RegistrationKey>().HasData(new RegistrationKey
            {
                Id = 1,
                Key = "qwerty12"
            });
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AuthorizedUser> AuthorizedUsers { get; set; }
        public DbSet<RegistrationKey> RegistrationKeys { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
