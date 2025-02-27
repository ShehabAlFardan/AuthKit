using AuthKit.Domain.ApplicationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthKit.Infrastructure.Persistance.ApplicationAggregate.EntityConfigurations
{
    class ApplicationEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ApplicationAggregate.Application>
    {
        public void Configure(EntityTypeBuilder<Domain.ApplicationAggregate.Application> builder)
        {
            builder.ToTable("Applications");
            builder.Property(x => x.Id).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.Name).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.ApplicationType).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.CreatedAt).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.UpdatedAt).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
