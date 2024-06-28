using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Pipes.v1;
using Five.Bank.Domain.Services.v1;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Five.Bank.Domain;

public static class Bootstrapper
{
    public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddAutoMapper(typeof(Bootstrapper))
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)))
            .AddScoped<IDomainNotificationService, DomainNotificationServiceHandler>()
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>));
    }
}