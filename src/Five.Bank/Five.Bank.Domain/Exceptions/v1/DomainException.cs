namespace Five.Bank.Domain.Exceptions.v1;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}