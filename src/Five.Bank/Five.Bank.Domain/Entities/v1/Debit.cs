namespace Five.Bank.Domain.Entities.v1;

public sealed class Debit : Transaction
{
    public Debit(decimal amount, DateTime createdAt, string? description) 
        : base(amount, createdAt, description)
    {
    }

    public Debit(Guid id, decimal amount, DateTime createdAt, string? description) 
        : base(id, amount, createdAt, description)
    {
    }
}