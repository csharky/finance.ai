namespace Finance.Ai.Domain.Models.Transactions;

public class Category : Entity
{
    public Guid UserId { get; init; }
    
    public string Name { get; set; }

    public static Category Create(Guid ownerId, string name)
    {
        return new Category()
        {
            Name = name,
            UserId = ownerId
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}