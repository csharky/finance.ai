using Finance.Ai.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Ai.Infrastructure.Persistence.Abstactions;

public abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Created).IsRequired();
        builder.Property(t => t.LastModified).IsRequired();

        OnConfigure(builder);
    }

    protected abstract void OnConfigure(EntityTypeBuilder<T> builder);
}
