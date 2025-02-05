using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Domain.Models.Users;

public class User : Entity
{
    public User(Guid id, Email email)
    {
        Id = id;
        Email = email;
    }

    public Guid Id { get; }
    public Email Email { get; }
}