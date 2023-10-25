using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.TransferAggregate.Events;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Events;

public class TransferUpdatedHandler : INotificationHandler<TransferUpdated>
{
    private readonly IMovementRepository _movementRepository;

    public TransferUpdatedHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public Task Handle(TransferUpdated notification, CancellationToken cancellationToken)
    {
        // Actualizar el movimiento de egreso de la cuenta de origen
        var originMovement = _movementRepository.GetMovementById(notification.Transfer.OriginMovementId.Value);

        if (originMovement is null)
        {
            throw new Exception("El movimiento de origen no existe");
        }

        originMovement.Update(
            notification.Transfer.Description,
            Amount.Create(notification.Transfer.Amount.Value),
            originMovement.Type,
            CategoryId.Create(notification.CategoryId.Value),
            AccountId.Create(notification.Transfer.OriginAccountId.Value),
            notification.Transfer.CreatedDate
        );

        _movementRepository.Update(originMovement);

        // Actualizar el movimiento de ingreso de la cuenta de destino

        var destinationMovement = _movementRepository.GetMovementById(notification.Transfer.DestinationMovementId.Value);

        if (destinationMovement is null)
        {
            throw new Exception("El movimiento de destino no existe");
        }

        destinationMovement.Update(
            notification.Transfer.Description,
            Amount.Create(notification.Transfer.Amount.Value),
            destinationMovement.Type,
            CategoryId.Create(notification.CategoryId.Value),
            AccountId.Create(notification.Transfer.DestinationAccountId.Value),
            notification.Transfer.CreatedDate
        );

        _movementRepository.Update(destinationMovement);

        return Task.CompletedTask;

    }
}