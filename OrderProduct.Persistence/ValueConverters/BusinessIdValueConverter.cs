using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderProduct.Domain.ValueObjects;

namespace OrderProduct.Persistence.ValueConverters;

public class BusinessIdValueConverter<TEntity> : ValueConverter<BusinessId<TEntity>, Guid>
{
    public BusinessIdValueConverter()
        : base(
            x => x.Value,
            val => BusinessId<TEntity>.Parse(val))
    {
        ;
    }
}