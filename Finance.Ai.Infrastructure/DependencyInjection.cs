using Finance.Ai.Application.Users;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Users;
using Finance.Ai.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Ai.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<IUnitOfWork, UserUnitOfWork>();
        return services;
    }
}