using Finance.Ai.Domain.Transactions;
using Finance.Ai.Domain.Users;
using Finance.Ai.Infrastructure.Persistence.Categories;
using Finance.Ai.Infrastructure.Persistence.Transactions;
using Finance.Ai.Infrastructure.Persistence.Users;
using Microsoft.EntityFrameworkCore;

namespace Finance.Ai.Infrastructure.Persistence;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
    }
}