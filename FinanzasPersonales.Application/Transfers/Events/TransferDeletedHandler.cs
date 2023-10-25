using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.TransferAggregate.Events;
using MediatR;

namespace FinanzasPersonales.Application.Transfers.Events;

public class TransferDeletedHandler : INotificationHandler<TransferDeleted>
{
    private readonly IMovementRepository _movementRepository;

    public TransferDeletedHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public Task Handle(TransferDeleted notification, CancellationToken cancellationToken)
    {

        // Eliminar el movimiento de egreso de la cuenta de origen
        var originMovement = _movementRepository.GetMovementById(notification.Transfer.OriginMovementId.Value);

        if (originMovement is null)
        {
            throw new Exception("El movimiento de origen no existe");
        }

        _movementRepository.Delete(originMovement);

        // Eliminar el movimiento de ingreso de la cuenta de destino
        var destinationMovement = _movementRepository.GetMovementById(notification.Transfer.DestinationMovementId.Value);

        if (destinationMovement is null)
        {
            throw new Exception("El movimiento de destino no existe");
        }

        _movementRepository.Delete(destinationMovement);

        return Task.CompletedTask;
    }
}