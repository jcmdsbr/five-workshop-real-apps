using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Entities.v1;
using AutoMapper;
using MediatR;
using System.Reflection;

namespace _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(
        ICustomerRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        await _repository.AddAsync(customer, cancellationToken);
        return _mapper.Map<CreateCustomerCommandResponse>(customer);
    }
}