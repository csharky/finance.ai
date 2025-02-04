using Finance.Ai.Domain.Transactions;

namespace Finance.Ai.Application.Categories;

public interface ICategoriesRepository
{
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Category?> CreateAsync(Guid id, Guid userId, string name, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Category>> FetchAllAsync(Guid userId, CancellationToken cancellationToken = default);
}