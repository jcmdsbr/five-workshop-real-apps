using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Entities.v1;
using MongoDB.Driver;

namespace Five.Bank.Infra.MongoDb.Repositories.v1;

public class AccountRepository : IAccountRepository
{
    private readonly IMongoCollection<Account> _collection;

    public AccountRepository(IMongoClient client)
    {
        _collection = client
            .GetDatabase("FiveBank")
            .GetCollection<Account>(nameof(Account));
    }

    public async Task AddAsync(Account obj)
    {
        await _collection.InsertOneAsync(obj);
    }

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        return await _collection
            .Find(customer => customer.Id == id)
            .SingleOrDefaultAsync();
    }

    public async Task UpdateAsync(Account account)
    {
        await _collection.ReplaceOneAsync(acc => acc.Id == account.Id, account);
    }
}