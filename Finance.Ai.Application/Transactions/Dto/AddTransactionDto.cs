namespace Finance.Ai.Application.Transactions.Dto;

public class AddTransactionDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
}