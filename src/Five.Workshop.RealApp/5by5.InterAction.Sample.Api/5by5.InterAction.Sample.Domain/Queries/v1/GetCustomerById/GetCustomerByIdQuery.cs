using _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
using MediatR;

namespace _5by5.InterAction.Sample.Domain.Queries.v1.GetCustomerById;
public class GetCustomerByIdQuery(Guid Id) : IRequest<GetCustomerByIdQueryResponse>
{
    public Guid Id { get; set; } = Id;
}