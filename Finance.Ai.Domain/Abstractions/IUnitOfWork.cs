using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Domain.Abstractions;

public interface IUnitOfWork
{
    Task<Result> SaveChangesAsync();
}