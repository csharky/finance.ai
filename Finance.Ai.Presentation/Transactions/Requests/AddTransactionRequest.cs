namespace Finance.Ai.Presentation.Transactions.Requests;

public class AddTransactionRequest
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime TransactionTime { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
}