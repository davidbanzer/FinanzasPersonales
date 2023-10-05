using FinanzasPersonales.Domain.Account;
using FinanzasPersonales.Domain.Account.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanzasPersonales.Infrastructure.Persistance.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        ConfigureAccountTable(builder);
    }

    private void ConfigureAccountTable(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value)
            );
        builder.Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Description)
            .HasMaxLength(500);

        builder.Property(a => a.InitialBalance)
            .HasConversion(
                amount => amount.Value,
                value => Amount.Create(value)
            ).IsRequired();

        builder.Property(a => a.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            ).IsRequired();
    }
}