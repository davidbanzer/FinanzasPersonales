using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovemenAggregate.ValueObjects;
using FinanzasPersonales.Domain.TransactionAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.TransactionAggregate;

public sealed class Transaction : AggregateRoot<TransactionId>
{
    public string Description { get; private set; }
    public Amount Amount { get; private set; }
    public AccountId OriginAccountId { get; private set; }
    public AccountId DestinationAccountId { get; private set; }
    public MovementId OriginMovementId { get; private set; }
    public MovementId DestinationMovementId { get; private set; }
    public DateTime CreatedDate { get; private set; }

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

#pragma warning disable CS8618
    private Transaction()
    {
    }
#pragma warning restore CS8618
}