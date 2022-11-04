using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Infra.MongoDb.Repositories.v1;
using MongoDB.Driver;

namespace Five.Bank.Api;

public static class Bootstrapper
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services)
    {
        var connectionString = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
        
        var mongoClient = new MongoClient(connectionString);
        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }
}