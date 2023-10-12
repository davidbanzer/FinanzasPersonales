namespace FinanzasPersonales.Contracts.Transfers;

public record TransferResponse(
    Guid Id,
    string Description,
    decimal Amount,
    Guid OriginAccountId,
    Guid DestinationAccountId,
    Guid OriginMovementId,
    Guid DestinationMovementId,
    DateTime CreatedDate
);