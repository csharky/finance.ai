using Finance.Ai.Application.Categories;
using Finance.Ai.Application.Transactions;
using Finance.Ai.Application.Users;
using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.Users;
using Finance.Ai.Infrastructure.Persistence;
using Finance.Ai.Infrastructure.Persistence.Categories;
using Finance.Ai.Infrastructure.Persistence.Transactions;
using Finance.Ai.Infrastructure.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Finance.Ai.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;

namespace Finance.Ai.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(
            configuration.GetSection(DatabaseOptions.SectionName));
        
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var dbOptions = configuration
                .GetSection(DatabaseOptions.SectionName)
                .Get<DatabaseOptions>();
            
            options.UseNpgsql(dbOptions.ConnectionString, npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure(
                    maxRetryCount: dbOptions.MaxRetryCount,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorCodesToAdd: null);
                npgsqlOptions.CommandTimeout(dbOptions.CommandTimeout);
            });
        });

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddHealthChecks()
            .AddNpgSql(configuration.GetSection(DatabaseOptions.SectionName)
                .Get<DatabaseOptions>()?.ConnectionString ?? string.Empty);

        return services;
    }
}