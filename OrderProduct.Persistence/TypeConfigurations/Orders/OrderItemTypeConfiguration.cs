using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProduct.Domain.Entities.Orders;
using OrderProduct.Domain.Entities.Products;
using OrderProduct.Persistence.ValueConverters;

namespace OrderProduct.Persistence.TypeConfigurations.Orders;

public class OrderItemTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .HasKey(x => x.Id)
            ;

        builder
            .Property(x => x.Id)
            .HasConversion<BusinessIdValueConverter<OrderItem>>()
            .IsRequired()
            ;

        builder
            .Property(x => x.OrderId)
            .HasConversion<BusinessIdValueConverter<Order>>()
            .IsRequired()
            ;

        builder
            .Property(x => x.ProductId)
            .HasConversion<BusinessIdValueConverter<Product>>()
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
            .Property(x => x.Count)
            .IsRequired()
            ;
    }
}