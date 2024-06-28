namespace Five.Bank.Domain.Specifications.v1;

public class CustomerMajoritySpecification(DateTime birthday)
{
    public bool IsSatisfied()
    {
        return DateTime.Now.Year - birthday.Year >= 18;
    }
}