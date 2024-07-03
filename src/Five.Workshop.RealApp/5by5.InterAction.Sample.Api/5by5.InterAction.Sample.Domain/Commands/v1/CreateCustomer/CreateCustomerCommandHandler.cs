using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Entities.v1;
using _5by5.InterAction.Sample.Domain.Services.v1;
using AutoMapper;
using MediatR;

namespace _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper, IDomainNotificationService domainNotification) 
    : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{

    public async Task<CreateCustomerCommandResponse> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        domainNotification.Add("teste");

        var customer = mapper.Map<CreateCustomerCommand, Customer>(request);
        var customerList = new List<Customer>();

        //for (int i = 0; i <= 100; i++)        
        //    customerList.Add(new Customer());

        //var list = customerList.Select(x => repository.AddAsync(x, cancellationToken));

        //await Task.WhenAll(list);
        

        return mapper.Map<CreateCustomerCommandResponse>(customer);
    }



}