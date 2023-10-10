using FinanzasPersonales.Application.Categories.Common;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    string Description,
    Guid UserId
) : IRequest<CategoryResult>;