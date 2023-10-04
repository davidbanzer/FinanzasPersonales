namespace FinanzasPersonales.Contracts.Accounts;

public record AccountResponse(
    Guid Id,
    string Name,
    string Description,
    decimal InitialBalance,
    List<Guid> MovementsIds,
    Guid UserId
);