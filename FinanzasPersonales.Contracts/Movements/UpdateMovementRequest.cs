namespace FinanzasPersonales.Contracts.Movements;

public record UpdateMovementRequest(
    string Description,
    decimal Amount,
    string Type,
    Guid CategoryId,
    Guid AccountId,
    DateTime CreatedDate
);