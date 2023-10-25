using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Commands.DeleteMovement;

public class DeleteMovementCommandHandler : IRequestHandler<DeleteMovementCommand, Unit>
{
    private readonly IMovementRepository _movementRepository;
    private readonly ITransferRepository _transferRepository;

    public DeleteMovementCommandHandler(IMovementRepository movementRepository, ITransferRepository transferRepository)
    {
        _movementRepository = movementRepository;
        _transferRepository = transferRepository;
    }

    public async Task<Unit> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var movement = _movementRepository.GetMovementById(request.Id);

        if (movement is null)
        {
            throw new Exception("No existe el movimiento");
        }

        // Comprobar si el movimiento es de tipo transferencia

        if (_transferRepository.GetTransfersByMovementId(movement.Id.Value) is not null)
        {
            throw new Exception("Para eliminar este movimiento, elimine la transferencia asociada");
        }

        _movementRepository.Delete(movement);

        return Unit.Value;
    }
}