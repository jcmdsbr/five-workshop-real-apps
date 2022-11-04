using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Infra.MongoDb.Repositories.v1;
using Five.Bank.Infra.Services.Clients.v1;
using MongoDB.Driver;

namespace Five.Bank.Api;

public static class Bootstrapper
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services)
    {
        var connectionString = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");

        var client = new MongoClient(connectionString);
        services.AddSingleton<IMongoClient>(client);
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        return services;
    }

    public static IServiceCollection AddAddressClient(this IServiceCollection services)
    {
        services.AddHttpClient<IAddressClient, AddressClient>(client =>
        {
            client.BaseAddress = new Uri("https://viacep.com.br/ws/");
        });

        return services;
    }
}