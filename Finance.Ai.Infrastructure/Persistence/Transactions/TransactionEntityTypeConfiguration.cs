using Finance.Ai.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Ai.Infrastructure.Persistence.Transactions;

internal class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        // Set primary key
        builder.HasKey(t => t.Id);

        // Configure the foreign key relationship with Category
        builder
            .HasOne<Category>()
            .WithMany() // Assuming no navigation property in Category for Transactions
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade); // Adjust cascade behavior as necessary

        // Set required fields
        builder.Property(t => t.Time).IsRequired();
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100); // MaxLength can be adjusted as needed
        builder.Property(t => t.Amount).IsRequired();

        // Set table name (optional, defaults to DbSet name -> Transactions)
        builder.ToTable("Transactions");

    }
}