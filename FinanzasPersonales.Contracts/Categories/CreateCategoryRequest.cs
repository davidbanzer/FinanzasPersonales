namespace FinanzasPersonales.Contracts.Categories;

public record CreateCategoryRequest(
    string Name,
    string Description,
    Guid UserId
);