namespace FinanzasPersonales.Contracts.Categories;

public record CategoryResponse(
    Guid Id,
    string Name,
    string Description,
    Guid? UserId
);