using OrderProduct.Domain.ValueObjects;

namespace OrderProduct.Domain.Entities.Customers;

public class Customer
{
    public BusinessId<Customer> Id { private set; get; } = default!;
    public string Name { private set; get; } = string.Empty;
    public string Email { private set; get; } = string.Empty;
}
