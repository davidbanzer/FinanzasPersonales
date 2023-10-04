using FinanzasPersonales.Domain.Account.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.Movement.ValueObjects;
using FinanzasPersonales.Domain.User.ValueObjects;

namespace FinanzasPersonales.Domain.Account;

public sealed class Account : AggregateRoot<AccountId>
{
/*     private readonly List<MovementId> _movementsIds = new(); */
    public string Name { get; }
    public string Description { get; }
    public Amount InitialBalance { get; }
/*     public IReadOnlyCollection<MovementId> MovementsIds => _movementsIds.AsReadOnly(); */
    public UserId UserId { get; }

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

/*     public void AddMovement(MovementId movementId)
    {
        _movementsIds.Add(movementId);
    } */
}