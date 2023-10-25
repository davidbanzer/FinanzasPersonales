namespace FinanzasPersonales.Contracts.Transfers;

public record UpdateTransferRequest(
    string Description,
    decimal Amount,
    Guid OriginAccountId,
    Guid DestinationAccountId,
    Guid CategoryId,
    DateTime CreatedDate
);