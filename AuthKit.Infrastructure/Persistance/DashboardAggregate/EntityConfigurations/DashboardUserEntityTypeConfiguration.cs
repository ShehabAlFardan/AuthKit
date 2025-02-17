using AuthKit.Domain.DashbaordAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthKit.Infrastructure.Persistance.DashboardAggregate.EntityConfigurations
{
    class DashboardUserEntityTypeConfiguration : IEntityTypeConfiguration<DashboardUser>
    {
        public void Configure(EntityTypeBuilder<DashboardUser> builder)
        {
            builder.ToTable("DashboardUsers");

            builder.Property(x => x.Id).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.Name).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.Email).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.Password).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.CreatedAt).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.UpdatedAt).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
