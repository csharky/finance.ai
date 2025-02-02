using Finance.Ai.Application.Users;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Ai.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UserUnitOfWork>();
        return services;
    }
}