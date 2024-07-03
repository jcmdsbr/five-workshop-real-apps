using _5by5.InterAction.Sample.Domain.ValueObjects.v1;

namespace _5by5.InterAction.Sample.Domain.Queries.v1.GetCustomerById;

public class GetCustomerByIdQueryResponse
{
    public string Name { get; set; }
    public string Document { get; set; }
    public DateTime Birthday { get; set; }
    public Address? Address { get; set; }
    public Guid Id { get; set; }
}