using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Domain.Users;

public class User
{
    public User(Guid id, Email email)
    {
        Id = id;
        Email = email;
    }

    public Guid Id { get; }
    public Email Email { get; }
}