using Finance.Ai.Domain.Users;
using Finance.Ai.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Ai.Infrastructure.Persistence.Users;

internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Email)
            .HasConversion(
                email => email.Value,
                emailString => Email.Create(emailString) 
            )
            .IsRequired();

        builder.ToTable("Users");
    }
}