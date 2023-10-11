using MediatR;

namespace FinanzasPersonales.Application.Movements.Commands.DeleteMovement;

public record DeleteMovementCommand(
    Guid Id
): IRequest<Unit>;