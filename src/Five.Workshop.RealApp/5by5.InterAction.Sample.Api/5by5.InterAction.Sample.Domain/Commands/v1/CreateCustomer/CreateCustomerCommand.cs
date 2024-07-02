using _5by5.InterAction.Sample.Domain.ValueObjects.v1;
using MediatR;

namespace _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public Address? Address { get; set; }
}