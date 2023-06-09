using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProduct.Domain.Entities.Customers;
using OrderProduct.Persistence.ValueConverters;

namespace OrderProduct.Persistence.TypeConfigurations.Customers;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(x => x.Id)
            ;

        builder
            .Property(x => x.Id)
            .HasConversion<BusinessIdValueConverter<Customer>>()
            ;

        builder
            .HasIndex(x => x.Email)
            .IsUnique()
            ;

        builder
            .Property(x => x.Email)
            .HasMaxLength(255)
            .IsRequired()
            ;

        builder
            .Property(x => x.Name)
            .HasMaxLength(128)
            .IsRequired()
            ;
    }
}