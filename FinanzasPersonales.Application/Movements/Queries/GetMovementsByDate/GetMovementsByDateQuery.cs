using FinanzasPersonales.Application.Movements.Common;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Queries.GetMovementsByDate;

public record GetMovementsByDateQuery(
    string Month,
    Guid UserId
) : IRequest<List<MovementResult>>;
