using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.AccountAggregate;

public sealed class Account : AggregateRoot<AccountId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Amount InitialBalance { get; private set; }
    public UserId UserId { get; private set; }

    private Account(
        AccountId accountId,
        string name,
        string description,
        Amount initialBalance,
        UserId userId
    ) : base(accountId)
    {
        Id = accountId;
        Name = name;
        Description = description;
        InitialBalance = initialBalance;
        UserId = userId;
    }

    public static Account Create(
        string name,
        string description,
        Amount initialBalance,
        UserId userId
    )
    {
        return new(
            AccountId.CreateUnique(),
            name,
            description,
            initialBalance,
            userId
        );
    }

    public void Update(
            string name,
            string description,
            Amount initialBalance,
            UserId userId
        )
    {
        Name = name;
        Description = description;
        InitialBalance = initialBalance;
        UserId = userId;
    }

#pragma warning disable CS8618
    private Account()
    {
    }
#pragma warning restore CS8618

}