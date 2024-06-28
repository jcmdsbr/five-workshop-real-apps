using System.Linq.Expressions;
using _5by5.InterAction.Sample.Domain.Contracts.v1;
using MongoDB.Driver;

namespace _5by5.InterAction.Sample.Infra.Repositories;

public class BaseDbRepository<TEntity, TId>(IMongoClient client) : IRepository<TEntity, TId> where TEntity : IEntity<TId>
{
    // Default database name
    private const string Database = "5by5";

    // Count default options
    private readonly CountOptions _countOpt = new() { Limit = 1 };

    // Replace default options
    private readonly ReplaceOptions _replaceOpt = new() { IsUpsert = true };

    // Access the MongoDB collection associated with the TEntity type.
    protected readonly IMongoCollection<TEntity> Collection = client
        .GetDatabase(Database)
        .GetCollection<TEntity>(typeof(TEntity).Name);


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