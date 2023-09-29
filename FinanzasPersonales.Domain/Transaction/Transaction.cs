using FinanzasPersonales.Domain.Account.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.Movement.ValueObjects;
using FinanzasPersonales.Domain.Transaction.ValueObjects;

namespace FinanzasPersonales.Domain.Transaction;

public sealed class Transaction : AggregateRoot<TransactionId>
{
    public string Description { get; }
    public Amount Amount { get; }
    public AccountId OriginAccountId { get; }
    public AccountId DestinationAccountId { get; }
    public MovementId OriginMovementId { get; }
    public MovementId DestinationMovementId { get; }
    public DateTime CreatedDate { get; }

    private Transaction(
        TransactionId transactionId,
        string description,
        Amount amount,
        AccountId originAccountId,
        AccountId destinationAccountId,
        MovementId originMovementId,
        MovementId destinationMovementId,
        DateTime createdDate
    ) : base(transactionId)
    {
        Id = transactionId;
        Description = description;
        Amount = amount;
        OriginAccountId = originAccountId;
        DestinationAccountId = destinationAccountId;
        OriginMovementId = originMovementId;
        DestinationMovementId = destinationMovementId;
        CreatedDate = createdDate;
    }

    public static Transaction Create(
        string description,
        Amount amount,
        AccountId originAccountId,
        AccountId destinationAccountId,
        MovementId originMovementId,
        MovementId destinationMovementId,
        DateTime createdDate
    )
    {
        return new(
            TransactionId.CreateUnique(),
            description,
            amount,
            originAccountId,
            destinationAccountId,
            originMovementId,
            destinationMovementId,
            createdDate
        );
    }
}