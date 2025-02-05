using Finance.Ai.Domain.Models.Transactions;
using Finance.Ai.Domain.Models.Users;
using Finance.Ai.Infrastructure.Persistence.Abstactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Ai.Infrastructure.Persistence.Categories;

internal class CategoryEntityTypeConfiguration : EntityTypeConfiguration<Category>
{
    protected override void OnConfigure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50); 

        builder
            .HasOne<User>()                 
            .WithMany()                     
            .HasForeignKey(c => c.UserId)   
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.ToTable("Categories");
    }
}
