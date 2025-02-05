using Finance.Ai.Domain.Models.Users;
using Finance.Ai.Domain.Users;
using Finance.Ai.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Finance.Ai.Infrastructure.Persistence.Users;

internal class UsersRepository : IUsersRepository
{
    private readonly AppDbContext _dbContext;

    public UsersRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user != null && user.Email == email, cancellationToken: cancellationToken);
    }

    public async Task<User?> CreateAsync(Guid id, Email email, CancellationToken cancellationToken = default)
    {
        var newUser = new User(id, email);

        _dbContext.Users.Add(newUser);

        return newUser;
    }

}