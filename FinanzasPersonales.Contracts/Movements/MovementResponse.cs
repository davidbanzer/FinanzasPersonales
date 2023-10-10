namespace FinanzasPersonales.Contracts.Movements;

public record MovementResponse(
    Guid Id,
    string Description,
    decimal Amount,
    string Type,
    Guid AccountId,
    Guid CategoryId,
    DateTime CreatedDate
);