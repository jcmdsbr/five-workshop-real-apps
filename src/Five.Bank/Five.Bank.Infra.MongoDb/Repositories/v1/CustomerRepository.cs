using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Entities.v1;
using MongoDB.Driver;

namespace Five.Bank.Infra.MongoDb.Repositories.v1;

public class CustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _collection;

    public CustomerRepository(IMongoClient client)
    {
        _collection = client
            .GetDatabase("FiveBank")
            .GetCollection<Customer>(nameof(Customer));
    }

    public async Task AddAsync(Customer obj)
    {
        await _collection.InsertOneAsync(obj);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _collection
            .Find(customer => customer.Id == id)
            .SingleOrDefaultAsync();
    }
}