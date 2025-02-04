using Finance.Ai.Application.Categories;
using Finance.Ai.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Finance.Ai.Infrastructure.Persistence.Categories;

internal class CategoriesRepository : ICategoriesRepository
{
    private readonly AppDbContext _dbContext;

    public CategoriesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.FindAsync(id);
    }

    public async Task<Category?> CreateAsync(Guid id, Guid userId, string name, CancellationToken cancellationToken = default)
    {
        var category = new Category()
        {
            Id = id,
            UserId = userId,
            Name = name,
        };
        
        await _dbContext.Categories.AddAsync(category, cancellationToken);
        return category;
    }

    public async Task<IReadOnlyList<Category>> FetchAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.Where(c => c.UserId == userId).ToListAsync(cancellationToken: cancellationToken);
    }
}