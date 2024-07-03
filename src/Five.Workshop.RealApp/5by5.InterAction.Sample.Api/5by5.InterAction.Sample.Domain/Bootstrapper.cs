using _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Pipes.v1;
using _5by5.InterAction.Sample.Domain.Services.v1;
using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _5by5.InterAction.Sample.Domain;

public static class Bootstrapper
{
    public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)))
            .AddScoped<IDomainNotificationService, DomainNotificationServiceHandler>()
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>))
            .AddCommands()
            .AddValidators()
            .AddAutoMapper(typeof(CreateCustomerCommandProfile));
    }

    private static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddTransient<CreateCustomerCommandHandler>();

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
        return services;
    }
}