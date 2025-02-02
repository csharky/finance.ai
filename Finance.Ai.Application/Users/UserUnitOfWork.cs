using Finance.Ai.Domain.Abstractions;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Users;

public class UserUnitOfWork : IUnitOfWork
{
    public Task<Result> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}