namespace OrderProduct.Domain.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException()
    {
    }

    protected DomainException(string msg)
        : base(msg)
    {
        ;
    }
}