namespace FinanzasPersonales.Contracts.Categories;

public record UpdateCategoryRequest(
    string Name,
    string Description
);