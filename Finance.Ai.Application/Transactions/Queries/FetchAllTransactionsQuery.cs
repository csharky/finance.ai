using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Transactions.Dto;

namespace Finance.Ai.Application.Transactions.Queries;

public class FetchAllTransactionsQuery : IQuery<FetchAllTransactionsDto>
{
    public Guid UserId { get; set; }
}