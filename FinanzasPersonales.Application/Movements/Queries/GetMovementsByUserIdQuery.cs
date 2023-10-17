using FinanzasPersonales.Application.Movements.Common;
using MediatR;

namespace FinanzasPersonales.Application.Movements.Queries;

public record GetMovementsByUserIdQuery(Guid UserId) : IRequest<List<MovementResult>>;