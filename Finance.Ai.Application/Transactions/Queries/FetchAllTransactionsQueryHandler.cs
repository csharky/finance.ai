using Finance.Ai.Application.Abstractions.Messaging;
using Finance.Ai.Application.Transactions.Dto;
using Finance.Ai.Domain.Models.Transactions;
using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Application.Transactions.Queries;

public class FetchAllTransactionsQueryHandler : IQueryHandler<FetchAllTransactionsQuery, FetchAllTransactionsDto>
{
    private readonly ITransactionsRepository _transactionsRepository;

    public FetchAllTransactionsQueryHandler(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    public async Task<Result<FetchAllTransactionsDto>> Handle(
        FetchAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        if (request.UserId == Guid.Empty)
        {
            return Result<FetchAllTransactionsDto>.Fail($"{nameof(request.UserId)} is empty");
        }

        var transactions = await _transactionsRepository.FetchAllByUserIdAsync(request.UserId, cancellationToken);
        transactions ??= Array.Empty<Transaction>();
        
        var dto = new FetchAllTransactionsDto
        {
            Transactions = transactions
                .Select(transaction => new FetchAllTransactionsDto.TransactionDto()
                {
                    Id = transaction.Id,
                    CategoryId = transaction.CategoryId,
                    Name = transaction.Name,
                    Amount = transaction.Amount,
                    DateTime = transaction.DateTime,
                })
                .ToArray()
        };
            
        return Result<FetchAllTransactionsDto>.Success(dto);
    }
}