namespace Five.Bank.Domain.Specifications.v1;

public class NameSpecification
{
    private readonly string _name;

    public NameSpecification(string name)
    {
        _name = name;
    }

    public bool IsSatisfied()
    {
        return !string.IsNullOrEmpty(_name);
    }
}