using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Transactions.Dto;

namespace Finance.Ai.Application.Transactions.Commands;

public class AddTransactionCommand(Guid userId, Guid categoryId, DateTime transactionTime, string name, decimal amount)
    : ICommand<AddTransactionDto>
{
    public Guid UserId { get; private init; } = userId;
    public Guid CategoryId { get; private init; } = categoryId;
    public DateTime TransactionTime { get; private init; } = transactionTime;
    public string Name { get; private init; } = name;
    public decimal Amount { get; private init; } = amount;
}