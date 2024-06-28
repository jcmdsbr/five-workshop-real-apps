using System.Linq.Expressions;
using Five.Bank.Domain.Contracts.v1;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Five.Bank.Infra.MongoDb.Repositories;

public class BaseDbRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
{
    private const string Database = "Five";
    private readonly CountOptions _countOpt;
    private readonly ReplaceOptions _replaceOpt;
    protected readonly IMongoCollection<TEntity> Collection;

    public BaseDbRepository(IMongoClient client, IConventionPack conventionPack)
    {
        // Register MongoDB conventions to handle serialization.
        ConventionRegistry.Register("Convention", conventionPack, _ => true);

        // Access the MongoDB collection associated with the TEntity type.
        Collection = client
            .GetDatabase(Database)
            .GetCollection<TEntity>(typeof(TEntity).Name);

        // Replace default options
        _replaceOpt = new ReplaceOptions { IsUpsert = true };

        // Count default options
        _countOpt = new CountOptions { Limit = 1 };
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Collection.ReplaceOneAsync(x => x.Id!.Equals(entity.Id), entity, _replaceOpt, cancellationToken);
    }

    public virtual async Task<TEntity?> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await Collection.Find(predicate).SingleOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        var count = await Collection.CountDocumentsAsync(predicate, _countOpt, cancellationToken);
        return count > 0;
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Collection.AsQueryable().ToListAsync(cancellationToken);
    }
}