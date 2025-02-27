using AuthKit.Infrastructure.Persistance.ApplicationAggregate.EntityConfigurations;
using AuthKit.Infrastructure.Persistance.DashboardAggregate.EntityConfigurations;
using AuthKit.Infrastructure.Persistance.OrganizationAggregate.EntityConfigurations;
using AuthKit.Infrastructure.Persistance.UserAggregate.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Domain.OrganizationAggregate;
using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Domain.UserAggregate;

namespace AuthKit.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.ApplicationAggregate.Application> Applications { get; set; }
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
