namespace FinanzasPersonales.Contracts.Movements;

public record CreateMovementRequest(
    string Description,
    decimal Amount,
    string Type,
    Guid AccountId,
    Guid CategoryId
);