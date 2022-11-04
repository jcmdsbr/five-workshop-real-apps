namespace Five.Bank.Api.Models.v1.Inputs;

public class AccountOpenInputModel
{
    public AccountOpenInputModel(Guid customerId)
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}