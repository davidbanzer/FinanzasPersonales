using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate;
using FinanzasPersonales.Domain.MovementAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanzasPersonales.Infrastructure.Persistance.Configurations;

public class MovementConfigurations : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.ToTable("Movements");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MovementId.Create(value)
            );
        builder.Property(a => a.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Amount)
            .IsRequired()
            .HasConversion(
                amount => amount.Value,
                value => Amount.Create(value)
            );

        builder.Property(a => a.Type)
            .IsRequired();

        builder.Property(a => a.AccountId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value)
            );

        builder.Property(a => a.CategoryId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => CategoryId.Create(value)
            );

        builder.Property(a => a.CreatedDate);        
    }
}