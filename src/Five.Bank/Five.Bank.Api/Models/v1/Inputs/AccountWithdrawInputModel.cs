namespace Five.Bank.Api.Models.v1.Inputs;

public class AccountWithdrawInputModel
{
    public AccountWithdrawInputModel(decimal amount)
    {
        Amount = amount;
    }

    public decimal Amount { get; }
}