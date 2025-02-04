using Finance.Ai.Domain.Transactions;
using Finance.Ai.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Ai.Infrastructure.Persistence.Categories;

internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Set primary key
        builder.HasKey(c => c.Id);

        // Configure required properties
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50); // Adjust MaxLength as necessary

        // Configure the relationship between Category and User
        builder
            .HasOne<User>(c => c.User)                 // Define the navigation to the User entity
            .WithMany()                     // If User doesn't have navigation for Categories
            .HasForeignKey(c => c.UserId)   // Attach foreign key
            .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete (delete Categories when User is deleted)

        // Set table name (optional, defaults to DbSet name -> "Categories")
        builder.ToTable("Categories");
    }
}
