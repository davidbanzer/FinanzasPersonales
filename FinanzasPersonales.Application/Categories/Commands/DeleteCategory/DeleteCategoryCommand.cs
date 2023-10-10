using MediatR;

namespace FinanzasPersonales.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(
    Guid Id
) : IRequest<Unit>;