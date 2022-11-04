using Five.Bank.Domain.Contracts.v1;

namespace Five.Bank.Domain.Entities.v1;

public sealed class Account : IEntity
{
    public Account(Guid customerId) : this(Guid.NewGuid(), new (), customerId, false) {}

    public Account(Guid id, List<Transaction> transactions, Guid customerId, bool isClosed)
    {
        Id = id;
        Transactions = transactions;
        CustomerId = customerId;
        IsClosed = isClosed;
    }

    public Guid Id { get; init; }
    public List<Transaction> Transactions { get; init; }
    public Guid CustomerId { get; private set; }
    public bool IsClosed { get; private set; }

    public void Deposit(Credit credit) => Transactions.Add(credit);

    public void Withdraw(Debit debit)
    {
        if (GetCurrentBalance() > debit.Amount) Transactions.Add(debit);

        throw new Exception("A conta não possui saldo para saque");
    }

    public void Open(Guid customerId, Credit credit)
    {
        CustomerId = customerId;
        IsClosed = false;
        Deposit(credit);
    }

    public void Close()
    {
        if (GetCurrentBalance() == 0)
        {
            IsClosed = true;
            return;
        }

        throw new Exception("A conta não pode ser fechada, por que existe saldo.");
    }

    public decimal GetCurrentBalance()
    {
        var balance = 0M; // decimal balance = 0;

        foreach (var transaction in Transactions)
        {
            if (transaction is Debit)
                balance -= transaction.Amount;
            else
                balance += transaction.Amount;
        }

        return balance;


    }
}