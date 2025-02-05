using Finance.Ai.Domain.Models.Transactions;
using Finance.Ai.Domain.Models.Users;
using Finance.Ai.Infrastructure.Persistence.Abstactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Ai.Infrastructure.Persistence.Transactions;

internal class TransactionEntityTypeConfiguration : EntityTypeConfiguration<Transaction>
{
    protected override void OnConfigure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .HasOne<Category>()
            .WithMany() 
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne<User>()
            .WithMany() 
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t => t.Time).IsRequired();
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(t => t.Amount).IsRequired();

        builder.ToTable("Transactions");
    }
}