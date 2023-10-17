using FinanzasPersonales.Domain.MovementAggregate;

namespace FinanzasPersonales.Application.Movements.Common;

public record MovementResult(
    Movement Movement
);