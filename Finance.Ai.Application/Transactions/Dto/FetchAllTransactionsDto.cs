namespace Finance.Ai.Application.Transactions.Dto;

public class FetchAllTransactionsDto
{
    public IReadOnlyList<TransactionDto> Transactions { get; set; }
    
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}