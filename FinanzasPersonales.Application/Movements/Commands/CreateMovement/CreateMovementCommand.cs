using FinanzasPersonales.Application.Movements.Common;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Commands;

public record CreateMovementCommand(
    string Description,
    decimal Amount,
    string Type,
    Guid AccountId,
    Guid CategoryId,
    DateTime CreatedDate
) : IRequest<MovementResult>;