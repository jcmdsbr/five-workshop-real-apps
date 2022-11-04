namespace Five.Bank.Api.Models.v1.Outputs;

public class CustomerOutputModel
{
    public CustomerOutputModel(Guid id, string? name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string? Name { get; }
}