using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Domain.Users;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(Email email);
    Task<User> CreateAsync(Guid user, Email email);
}