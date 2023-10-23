using FinanzasPersonales.Application.Categories.Common;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryResult>;