using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Infra.Repositories;
using _5by5.InterAction.Sample.Infra.Repositories.Customer.v1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace _5by5.InterAction.Sample.Infra;

public static class Bootstrapper
{
    // Create MongoDB client settings.
    public static IServiceCollection AddInfraContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Create MongoDB client settings.
        var connectionString = configuration.GetConnectionString("Mongo");
        var clientSettings = MongoClientSettings.FromConnectionString(connectionString);
        var client = new MongoClient(clientSettings);

        // Register a custom BSON serializer for DateTime objects.
        BsonSerializer.RegisterSerializer(typeof(DateTime), DateTimeSerializer.LocalInstance);

        // Register services in the service collection.
        return services
            .AddSingleton(clientSettings)
            .AddSingleton<IMongoClient>(client)
            .AddScoped(typeof(IRepository<,>), typeof(BaseDbRepository<,>))
            .AddScoped<ICustomerRepository, CustomerRepository>();
    }
}