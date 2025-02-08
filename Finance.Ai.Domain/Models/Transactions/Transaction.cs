namespace Finance.Ai.Domain.Models.Transactions;

public class Transaction : Entity
{
    public Guid UserId { get; private set; }
    public Guid CategoryId { get; private set; }
    public DateTime DateTime { get; private set; }
    public string Name { get; private set; }
    public decimal Amount { get; private set; }

    public static Transaction Create(Guid userId, Guid categoryId, DateTime time, string name, decimal amount)
    {
        return new Transaction
        {
            UserId = userId,
            CategoryId = categoryId,
            DateTime = time,
            Name = name,
            Amount = amount
        };
    }
    
    public void Update(Guid categoryId, DateTime time, string name, decimal amount)
    {
        CategoryId = categoryId;
        DateTime = time;
        Name = name;
        Amount = amount;
        
        UpdateLastModified();
    }
}