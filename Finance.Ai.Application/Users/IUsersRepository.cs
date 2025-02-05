using Finance.Ai.Domain.Models.Users;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Domain.Users;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<User?> CreateAsync(Guid user, Email email, CancellationToken cancellationToken = default);
}