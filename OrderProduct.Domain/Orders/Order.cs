using OrderProduct.Domain.Customers;
using OrderProduct.Domain.Exceptions;
using OrderProduct.Domain.Products;
using OrderProduct.Domain.ValueObjects;

namespace OrderProduct.Domain.Orders;

public class Order
{
    private readonly List<OrderItem> _orderItems = new();

    private Order()
    {
        ;
    }

    public BusinessId<Order> Id { private set; get; } = default!;
    public BusinessId<Customer> CustomerId { private set; get; } = default!;
    public IList<OrderItem> OrderItems => _orderItems.ToList(); // a navigation

    public void AddOrderItem(BusinessId<Product> productId, Money price, int count)
    {
        var orderItem = OrderItem.Create(Id, productId, price, count);
        if (_orderItems.Any(x => x == orderItem))
        {
            throw new DuplicateOrderItemException();
        }

        if (_orderItems.Any(x => x.ProductId == orderItem.ProductId))
        {
            throw new DuplicateOrderItemException();
        }

        _orderItems.Add(orderItem);
    }

    public static Order Create(BusinessId<Customer> customerId) => new()
    {
        Id = BusinessId<Order>.Generate(),
        CustomerId = customerId
    };
}