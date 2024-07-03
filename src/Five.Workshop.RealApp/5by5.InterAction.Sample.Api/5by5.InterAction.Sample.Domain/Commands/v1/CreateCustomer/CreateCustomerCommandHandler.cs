using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Entities.v1;
using AutoMapper;
using MediatR;

namespace _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper) 
    : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{

    public async Task<CreateCustomerCommandResponse> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = mapper.Map<CreateCustomerCommand, Customer>(request);

        await repository.AddAsync(customer, cancellationToken);

        return new CreateCustomerCommandResponse { Id = customer.Id, Name = customer.Name };
    }
}