using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovemenAggregate.ValueObjects;
using FinanzasPersonales.Domain.TransferAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.TransferAggregate;

public sealed class Transfer : AggregateRoot<TransferId>
{
    public string Description { get; private set; }
    public Amount Amount { get; private set; }
    public AccountId OriginAccountId { get; private set; }
    public AccountId DestinationAccountId { get; private set; }
    public MovementId OriginMovementId { get; private set; }
    public MovementId DestinationMovementId { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private Transfer(
        TransferId TransferId,
        string description,
        Amount amount,
        AccountId originAccountId,
        AccountId destinationAccountId,
        MovementId originMovementId,
        MovementId destinationMovementId,
        DateTime createdDate
    ) : base(TransferId)
    {
        Id = TransferId;
        Description = description;
        Amount = amount;
        OriginAccountId = originAccountId;
        DestinationAccountId = destinationAccountId;
        OriginMovementId = originMovementId;
        DestinationMovementId = destinationMovementId;
        CreatedDate = createdDate;
    }

    public static Transfer Create(
        string description,
        Amount amount,
        AccountId originAccountId,
        AccountId destinationAccountId,
        MovementId originMovementId,
        MovementId destinationMovementId
    )
    {
        return new(
            TransferId.CreateUnique(),
            description,
            amount,
            originAccountId,
            destinationAccountId,
            originMovementId,
            destinationMovementId,
            DateTime.UtcNow
        );
    }

#pragma warning disable CS8618
    private Transfer()
    {
    }
#pragma warning restore CS8618
}