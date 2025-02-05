using Finance.Ai.Domain.Models.Transactions;

namespace Finance.Ai.Application.Transactions;

public interface ITransactionsRepository
{
    Task<IEnumerable<Transaction>?> FetchAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Transaction>?> FetchAllByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<Transaction?> AddAsync(Guid userId, Guid categoryId, DateTime dateTime, string name, decimal amount, CancellationToken cancellationToken = default);
    Task<Transaction?> GetAsync(Guid transactionId, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid transactionId, CancellationToken cancellationToken = default);
}