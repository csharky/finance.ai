using Finance.Ai.Application.Transactions;
using Finance.Ai.Domain.Models.Transactions;

namespace Finance.Ai.Infrastructure.Persistence.Transactions;

internal class TransactionsRepository : ITransactionsRepository
{
    private readonly AppDbContext _dbContext;

    public TransactionsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Transaction>> FetchAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transaction>> FetchAllByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Transaction> AddAsync(Guid userId, Guid categoryId, DateTime dateTime, string name, decimal amount,
        CancellationToken cancellationToken = default)
    {
        var transaction = Transaction.Create(userId, categoryId, dateTime, name, amount);
        await _dbContext.Transactions.AddAsync(transaction, cancellationToken);
        return transaction;
    }

    public async Task<Transaction> GetAsync(Guid transactionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Transactions.FindAsync(transactionId) ?? throw new InvalidOperationException();
    }

    public Task<Transaction> UpdateAsync(Transaction transaction, Guid categoryId, string name, decimal amount, DateTime transactionTime,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Transaction> UpdateAsync(Guid transactionId, Guid categoryId, string name, decimal amount, DateTime transactionTime,
        CancellationToken cancellationToken = default)
    {
        var transaction = await GetAsync(transactionId, cancellationToken);
        transaction.Update(categoryId, transactionTime, name, amount);
        return transaction;
    }

    public Task DeleteAsync(Guid transactionId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}