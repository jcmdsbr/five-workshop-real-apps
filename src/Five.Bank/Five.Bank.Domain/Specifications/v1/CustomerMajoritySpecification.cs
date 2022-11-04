namespace Five.Bank.Domain.Specifications.v1;

public class CustomerMajoritySpecification
{
    private readonly DateTime _birthday;

    public CustomerMajoritySpecification(DateTime birthday)
    {
        _birthday = birthday;
    }

    public bool IsSatisfied() => DateTime.Now.Year - _birthday.Year >= 18;
}