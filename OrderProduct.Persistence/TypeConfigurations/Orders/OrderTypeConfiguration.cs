using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProduct.Domain.Entities.Customers;
using OrderProduct.Domain.Entities.Orders;
using OrderProduct.Persistence.ValueConverters;

namespace OrderProduct.Persistence.TypeConfigurations.Orders;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(x => x.Id)
            ;

        builder
            .Property(x => x.Id)
            .HasConversion<BusinessIdValueConverter<Order>>()
            .IsRequired()
            ;

        builder
            .Property(x => x.CustomerId)
            .HasConversion<BusinessIdValueConverter<Customer>>()
            .IsRequired()
            ;

        builder
            .OwnsOne(x => x.Price, moneyBuilder =>
            {
                moneyBuilder.Property(x => x.Currency).IsRequired().HasMaxLength(16);
                moneyBuilder.Property(x => x.Amount).IsRequired().HasPrecision(36, 18);
            })
            ;

        builder
            .HasMany(x => x.OrderItems)
            .WithOne()
            .HasForeignKey(x => x.OrderId)
            .IsRequired()
            ;

        builder
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .IsRequired()
            ;
    }
}