using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Infrastructure.Persistence;

internal class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync();
        return Result.Success();
    }
}