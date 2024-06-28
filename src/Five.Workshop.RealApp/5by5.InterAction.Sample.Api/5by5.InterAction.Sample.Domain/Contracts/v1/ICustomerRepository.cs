using _5by5.InterAction.Sample.Domain.Entities.v1;

namespace _5by5.InterAction.Sample.Domain.Contracts.v1;

public interface ICustomerRepository : IRepository<Customer, Guid>
{
}