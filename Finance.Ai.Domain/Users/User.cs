using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Domain.Users;

public class User(Guid Id, Email Email)
{
    public Guid Id { get; } = Id;
    public Email Email { get; } = Email;
}