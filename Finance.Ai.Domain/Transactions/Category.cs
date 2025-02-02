namespace Finance.Ai.Domain.Transactions;

public record Category(Guid Id, string Name, Guid UserId)
{
    public Guid Id { get; } = Id;
    public string Name { get; } = Name;
    public Guid UserId { get; } = UserId;
}