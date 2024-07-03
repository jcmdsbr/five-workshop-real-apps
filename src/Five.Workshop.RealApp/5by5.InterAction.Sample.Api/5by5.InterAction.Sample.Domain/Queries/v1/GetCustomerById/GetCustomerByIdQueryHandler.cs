using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Entities.v1;
using AutoMapper;
using MediatR;
using System.Linq.Expressions;

namespace _5by5.InterAction.Sample.Domain.Queries.v1.GetCustomerById;
public class GetCustomerByIdQueryHandler(
    IMapper mapper,
    ICustomerRepository repository
    ) : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResponse>
{
    public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {

        Expression<Func<Customer, bool>> predicate = x => x.Id == request.Id;

        var customer = await repository.GetSingleOrDefaultAsync(predicate, cancellationToken);

        return mapper.Map<GetCustomerByIdQueryResponse>(customer);
    }
}