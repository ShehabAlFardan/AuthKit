using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Domain.OrganizationAggregate;
using AuthKit.Domain.UserAggregate;
using AuthKit.Infrastructure.Persistance.ApplicationAggregate.EntityConfigurations;
using AuthKit.Infrastructure.Persistance.DashboardAggregate.EntityConfigurations;
using AuthKit.Infrastructure.Persistance.OrganizationAggregate;
using AuthKit.Infrastructure.Persistance.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace AuthKit.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<DashboardUser> DashboardUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DashboardUserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }
    }
}
