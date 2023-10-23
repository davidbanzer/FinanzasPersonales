using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate.ValueObjects;
using FinanzasPersonales.Domain.TransferAggregate.Events;
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
        MovementId destinationMovementId,
        CategoryId categoryId
    )
    {
        var transfer = new Transfer(
            TransferId.CreateUnique(),
            description,
            amount,
            originAccountId,
            destinationAccountId,
            originMovementId,
            destinationMovementId,
            DateTime.UtcNow
        );

        transfer.AddDomainEvent(new TransferCreated(transfer, categoryId));
        return transfer;
    }

    public void UpdateMovements(MovementId originMovement, MovementId destinationMovement)
    {
        OriginMovementId = originMovement;
        DestinationMovementId = destinationMovement;
    }

#pragma warning disable CS8618
    private Transfer()
    {
    }
#pragma warning restore CS8618
}