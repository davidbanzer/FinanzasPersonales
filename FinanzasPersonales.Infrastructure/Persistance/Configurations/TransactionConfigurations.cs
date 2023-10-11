using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovemenAggregate.ValueObjects;
using FinanzasPersonales.Domain.TransferAggregate;
using FinanzasPersonales.Domain.TransferAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanzasPersonales.Infrastructure.Persistance.Configurations;

public class TransferConfigurations : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("Transfers");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => TransferId.Create(value)
            );

        builder.Property(a => a.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Amount)
            .HasConversion(
                amount => amount.Value,
                value => Amount.Create(value)
            );

        builder.Property(a => a.OriginAccountId)
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value)
            );

        builder.Property(a => a.DestinationAccountId)
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value)
            );

        builder.Property(a => a.OriginMovementId)
            .HasConversion(
                id => id.Value,
                value => MovementId.Create(value)
            );

        builder.Property(a => a.DestinationMovementId)
            .HasConversion(
                id => id.Value,
                value => MovementId.Create(value)
            );

        builder.Property(a => a.CreatedDate)
            .IsRequired();

    }
}