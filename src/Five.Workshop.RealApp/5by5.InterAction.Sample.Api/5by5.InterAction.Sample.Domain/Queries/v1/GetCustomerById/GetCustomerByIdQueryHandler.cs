using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Entities.v1;
using AutoMapper;
using MediatR;
using System.Linq.Expressions;

namespace _5by5.InterAction.Sample.Domain.Queries.v1.GetCustomerById;
public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResponse>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(
        ICustomerRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Customer, bool>> predicate = x => x.Id == request.Id;

        var customer = await _repository.GetSingleOrDefaultAsync(predicate, cancellationToken);

        return _mapper.Map<GetCustomerByIdQueryResponse>(customer);
    }
}