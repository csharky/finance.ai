namespace Finance.Ai.Domain.Transactions;

public class Transaction(Guid id, Guid categoryId, DateTime time, string name, decimal amount)
{
    public Guid Id { get; } = id;
    public Guid CategoryId { get; } = categoryId;
    public DateTime Time { get; } = time;
    public string Name { get; } = name;
    public decimal Amount { get; } = amount;
}