using Finance.Ai.Domain.Users;

namespace Finance.Ai.Domain.Transactions;

public record Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; } 
    
    public User User { get; set; }
}