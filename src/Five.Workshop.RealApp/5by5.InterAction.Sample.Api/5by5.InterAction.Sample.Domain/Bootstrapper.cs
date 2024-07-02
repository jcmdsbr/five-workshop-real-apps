using _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Pipes.v1;
using _5by5.InterAction.Sample.Domain.Services.v1;
using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _5by5.InterAction.Sample.Domain.Queries.v1.GetCustomerById;

namespace _5by5.InterAction.Sample.Domain;

public static class Bootstrapper
{
    public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddAutoMapper(typeof(Bootstrapper))
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)))
            .AddScoped<IDomainNotificationService, DomainNotificationServiceHandler>()
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>))
            .AddCommands()
            .AddQueries()
            .AddValidators();
    }

    private static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddTransient<CreateCustomerCommandHandler>();
        
        return services;
    }

    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddTransient<GetCustomerByIdQueryHandler>();

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
        return services;
    }
}