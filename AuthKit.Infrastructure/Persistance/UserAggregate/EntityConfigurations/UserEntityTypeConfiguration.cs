using AuthKit.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthKit.Infrastructure.Persistance.UserAggregate.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.FirstName).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.LastName).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.Email).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.Password).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.ApplicationId).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.OrganizationId).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.CreatedAt).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.UpdatedAt).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
