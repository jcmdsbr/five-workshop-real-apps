namespace Five.Bank.Api.Models.v1.Inputs;

public class AccountDepositInputModel
{
    public AccountDepositInputModel(decimal amount)
    {
        Amount = amount;
    }

    public decimal Amount { get; }
}