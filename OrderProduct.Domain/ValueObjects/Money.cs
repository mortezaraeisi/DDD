using OrderProduct.Domain.Exceptions;

namespace OrderProduct.Domain.ValueObjects;

public record Money(string Currency, decimal Amount)
{
    public static Money operator +(Money lhs, Money rhs)
    {
        if (lhs.Currency != rhs.Currency)
        {
            throw new MoneyTypeMismatchException();
        }

        return lhs with { Amount = lhs.Amount + rhs.Amount };
    }

    public static Money operator -(Money lhs, Money rhs)
    {
        if (lhs.Currency != rhs.Currency)
        {
            throw new MoneyTypeMismatchException();
        }

        return lhs with { Amount = lhs.Amount - rhs.Amount };
    }

    public static Money operator *(Money lhs, Money rhs)
    {
        if (lhs.Currency != rhs.Currency)
        {
            throw new MoneyTypeMismatchException();
        }

        return lhs with { Amount = lhs.Amount * rhs.Amount };
    }

    public static Money operator /(Money lhs, Money rhs)
    {
        if (lhs.Currency != rhs.Currency)
        {
            throw new MoneyTypeMismatchException();
        }

        return lhs with { Amount = lhs.Amount / rhs.Amount };
    }
};