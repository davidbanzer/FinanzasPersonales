namespace FinanzasPersonales.Contracts.Accounts;

public record UpdateAccountRequest(
    string Name,
    string Description,
    decimal InitialBalance,
    Guid UserId
);