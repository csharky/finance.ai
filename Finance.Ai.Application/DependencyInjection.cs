using Finance.Ai.Application.Abstractions.Behaviour;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Finance.Ai.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining<AssemblyReference>();
            configuration.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssemblyContaining<AssemblyReference>();
        return services;
    }
}