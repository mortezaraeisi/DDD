using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProduct.Domain.Entities.Products;
using OrderProduct.Persistence.ValueConverters;

namespace OrderProduct.Persistence.TypeConfigurations.Products;

public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(x => x.Id)
            ;

        builder
            .Property(x => x.Id)
            .HasConversion<BusinessIdValueConverter<Product>>()
            ;

        builder
            .Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired()
            ;

        builder
            .OwnsOne(x => x.Price, moneyBuilder =>
            {
                moneyBuilder.Property(x => x.Currency).IsRequired().HasMaxLength(16);
                moneyBuilder.Property(x => x.Amount).IsRequired().HasPrecision(36, 18);
            })
            ;
    }
}