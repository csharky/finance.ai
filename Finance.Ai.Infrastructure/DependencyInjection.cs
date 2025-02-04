using Finance.Ai.Application.Categories;
using Finance.Ai.Application.Users;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Users;
using Finance.Ai.Infrastructure.Persistence;
using Finance.Ai.Infrastructure.Persistence.Categories;
using Finance.Ai.Infrastructure.Persistence.Transactions;
using Finance.Ai.Infrastructure.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Ai.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Connection string not found");
        }
        
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<ICategoriesRepository, CategoriesRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}