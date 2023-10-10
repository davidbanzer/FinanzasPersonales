namespace FinanzasPersonales.Contracts.Accounts;

public record CreateAccountRequest(
    string Name,
    string Description,
    decimal InitialBalance,
    Guid UserId
);