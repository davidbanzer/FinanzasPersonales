namespace FinanzasPersonales.Contracts.Transfers;

public record CreateTransferRequest(
    string Description,
    decimal Amount,
    Guid OriginAccountId,
    Guid DestinationAccountId,
    Guid CategoryId,
    DateTime CreatedDate
);