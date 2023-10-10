using FinanzasPersonales.Application.Categories.Common;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    string Description
) : IRequest<CategoryResult>;