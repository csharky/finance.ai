using Finance.Ai.Domain.Users;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Infrastructure.Users;

public class UsersRepository : IUsersRepository
{
    public Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByEmailAsync(Email email)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateAsync(Guid user, Email email)
    {
        throw new NotImplementedException();
    }
}