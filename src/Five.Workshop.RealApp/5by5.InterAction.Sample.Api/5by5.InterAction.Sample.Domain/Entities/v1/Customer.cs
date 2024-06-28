using _5by5.InterAction.Sample.Domain.Contracts.v1;

namespace _5by5.InterAction.Sample.Domain.Entities.v1;

public class Customer : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
}