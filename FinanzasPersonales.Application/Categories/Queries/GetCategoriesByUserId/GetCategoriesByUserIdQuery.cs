using FinanzasPersonales.Application.Categories.Common;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Queries.GetCategoriesByUserId;

public record GetCategoriesByUserIdQuery(
  Guid UserId
) : IRequest<List<CategoryResult>>;