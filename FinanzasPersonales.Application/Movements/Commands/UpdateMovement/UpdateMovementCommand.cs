using FinanzasPersonales.Application.Movements.Common;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Commands.UpdateMovement;

public record UpdateMovementCommand(
    Guid Id,
    string Description,
    decimal Amount,
    string Type,
    Guid CategoryId,
    DateTime CreatedDate
) : IRequest<MovementResult>;
