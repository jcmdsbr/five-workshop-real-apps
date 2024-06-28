using _5by5.InterAction.Sample.Domain.Contracts.v1;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace _5by5.InterAction.Sample.Infra.Repositories.Customer.v1;

public class CustomerRepository(IMongoClient client) : BaseDbRepository<Domain.Entities.v1.Customer, Guid>(client), ICustomerRepository;