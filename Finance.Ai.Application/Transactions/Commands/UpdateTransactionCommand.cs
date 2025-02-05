using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Transactions.Dto;

namespace Finance.Ai.Application.Transactions.Commands;

public class UpdateTransactionCommand : ICommand<UpdateTransactionDto>
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
}