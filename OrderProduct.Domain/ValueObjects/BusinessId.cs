namespace OrderProduct.Domain.ValueObjects;

public record BusinessId<T>
{
    public Guid Value { private set; get; }
    
    public static BusinessId<T> Generate() => new()
    {
        Value = Guid.NewGuid()
    };
};