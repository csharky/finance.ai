using Finance.Ai.Domain.Models.Users;
using Finance.Ai.Domain.ValueObjects;
using Finance.Ai.Infrastructure.Persistence.Abstactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Ai.Infrastructure.Persistence.Users;

internal class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
{
    protected override void OnConfigure(EntityTypeBuilder<User> builder)
    {
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