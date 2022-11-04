using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Exceptions.v1;

namespace Five.Bank.Domain.Entities.v1;

public sealed class Account : IEntity
{
    public Account(Guid customerId) : this(Guid.NewGuid(), new List<Transaction>(), customerId, false)
    {
    }

    public Account(Guid id, List<Transaction> transactions, Guid customerId, bool isClosed)
    {
        Id = id;
        Transactions = transactions;
        CustomerId = customerId;
        IsClosed = isClosed;
    }

    public List<Transaction> Transactions { get; init; }
    public Guid CustomerId { get; }
    public bool IsClosed { get; private set; }

    public Guid Id { get; init; }

    public void Deposit(Credit credit)
    {
        Transactions.Add(credit);
    }

    public void Withdraw(Debit debit)
    {
        if (GetCurrentBalance() < debit.Amount)
            throw new DomainException("A conta não possui saldo para saque");

        Transactions.Add(debit);
    }

    public void Open(Credit credit)
    {
        IsClosed = false;
        Deposit(credit);
    }

    public void Close()
    {
        if (GetCurrentBalance() != 0)
            throw new DomainException("A conta não pode ser fechada, por que existe saldo.");

        IsClosed = true;
    }

    public decimal GetCurrentBalance()
    {
        var balance = 0M; // decimal balance = 0;

        foreach (var transaction in Transactions)
            if (transaction is Debit)
                balance -= transaction.Amount;
            else
                balance += transaction.Amount;

        return balance;
    }
}