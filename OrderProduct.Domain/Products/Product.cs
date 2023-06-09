using OrderProduct.Domain.ValueObjects;

namespace OrderProduct.Domain.Products;

public class Product
{
    public BusinessId<Product> Id { private set; get; } = default!;
    public string Name { private set; get; } = string.Empty;
    public Money Price { private set; get; } = default!;
    public int AvailableCount { private set; get; }
}
