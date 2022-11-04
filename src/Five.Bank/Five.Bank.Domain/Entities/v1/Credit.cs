namespace Five.Bank.Domain.Entities.v1;

public sealed class Credit : Transaction
{
    public Credit(decimal amount, DateTime createdAt, string? description) 
        : base(amount, createdAt, description)
    {
    }

    public Credit(Guid id, decimal amount, DateTime createdAt, string? description) 
        : base(id, amount, createdAt, description)
    {
    }
}