namespace OrderProduct.Domain.ValueObjects;

public record BusinessId<T>
{
    public Guid Value { private set; get; }

    private BusinessId(Guid value)
    {
        Value = value;
    }

    public static BusinessId<T> Generate() => new(Guid.NewGuid());
    public static BusinessId<T> Parse(Guid value) => new(value);
};