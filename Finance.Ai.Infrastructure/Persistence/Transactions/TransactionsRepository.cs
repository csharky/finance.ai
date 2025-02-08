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

    public async Task<IEnumerable<Transaction>?> FetchAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty)
        {
            return Array.Empty<Transaction>();
        }
        
        return _dbContext.Transactions
            .Where(transaction => transaction.UserId == userId)
            .OrderBy(transaction => transaction.DateTime);
    }

    public async Task<IEnumerable<Transaction>?> FetchAllByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        if (categoryId == Guid.Empty)
        {
            return Array.Empty<Transaction>();
        }
        
        return _dbContext.Transactions
            .Where(transaction => transaction.CategoryId == categoryId)
            .OrderBy(transaction => transaction.DateTime);
    }

    public async Task<Transaction?> AddAsync(Guid userId, Guid categoryId, DateTime dateTime, string name, decimal amount,
        CancellationToken cancellationToken = default)
    {
        var transaction = Transaction.Create(userId, categoryId, dateTime, name, amount);
        await _dbContext.Transactions.AddAsync(transaction, cancellationToken);
        return transaction;
    }

    public async Task<Transaction?> GetAsync(Guid transactionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Transactions.FindAsync(transactionId);
    }

    public async Task<Transaction> UpdateAsync(Guid transactionId, Guid categoryId, string name, decimal amount, DateTime transactionTime,
        CancellationToken cancellationToken = default)
    {
        var transaction = await GetAsync(transactionId, cancellationToken);
        if (transaction == null)
        {
            throw new Exception("Transaction not found");
        }
        
        transaction.Update(categoryId, transactionTime, name, amount);
        return transaction;
    }

    public async Task DeleteAsync(Guid transactionId, CancellationToken cancellationToken = default)
    {
        var transaction = await GetAsync(transactionId, cancellationToken);
        if (transaction == null)
        {
            throw new Exception("Transaction not found");
        }
        
        _dbContext.Transactions.Remove(transaction);
    }
}