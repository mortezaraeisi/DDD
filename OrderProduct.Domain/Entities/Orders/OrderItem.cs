using OrderProduct.Domain.Entities.Products;
using OrderProduct.Domain.ValueObjects;

namespace OrderProduct.Domain.Entities.Orders;

public record OrderItem
{
    public BusinessId<OrderItem> Id { private set; get; } = default!;
    public BusinessId<Order> OrderId { private set; get; } = default!;
    public BusinessId<Product> ProductId { private set; get; } = default!;
    public Money Price { private set; get; } = default!;
    public int Count { private set; get; }

    internal static OrderItem Create(BusinessId<Order> orderId, BusinessId<Product> productId, Money price,
        int count) => new()
    {
        Id = BusinessId<OrderItem>.Generate(),
        OrderId = orderId,
        ProductId = productId,
        Price = price,
        Count = count
    };
}