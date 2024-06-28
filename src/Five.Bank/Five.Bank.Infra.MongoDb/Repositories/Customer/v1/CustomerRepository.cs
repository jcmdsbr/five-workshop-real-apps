using Five.Bank.Domain.Contracts.v1;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Five.Bank.Infra.MongoDb.Repositories.Customer.v1;

public class CustomerRepository(IMongoClient client, IConventionPack conventionPack)
    : BaseDbRepository<Domain.Entities.v1.Customer, Guid>(client, conventionPack), ICustomerRepository;