using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Commands.DeleteMovement;

public class DeleteMovementCommandHandler : IRequestHandler<DeleteMovementCommand, Unit>
{
    private readonly IMovementRepository _movementRepository;

    public DeleteMovementCommandHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<Unit> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var movement = _movementRepository.GetMovementById(request.Id);

        if (movement is null)
        {
            throw new Exception("No existe el movimiento");
        }

        if(movement.Type == "I")
        {
            throw new Exception("No se puede eliminar un ingreso");
        }

        _movementRepository.Delete(movement);

        return Unit.Value;
    }
}