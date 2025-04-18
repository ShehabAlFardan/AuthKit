using AuthKit.Domain.OrganizationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Infrastructure.Persistance.OrganizationAggregate.EntityConfigurations
{
    class OrganizationEntityTypeConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organiztions");
            builder.Property(x => x.Id).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.ApplicationId).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.Name).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.CreatedBy).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.CreatedAt).UsePropertyAccessMode(PropertyAccessMode.Field).IsRequired();
            builder.Property(x => x.UpdatedAt).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
