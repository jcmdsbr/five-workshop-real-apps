using _5by5.InterAction.Sample.Domain.ValueObjects.v1;

namespace _5by5.InterAction.Sample.Domain.Queries.v1.GetCustomerById;
public class GetCustomerByIdQueryResponse
{
    public string Name { get; init; }
    public string Document { get; init; }
    public DateTime Birthday { get; init; }
    public Address? Address { get; init; }
    public Guid Id { get; set; }
}