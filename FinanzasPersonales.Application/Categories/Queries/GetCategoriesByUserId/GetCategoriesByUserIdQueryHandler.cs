using FinanzasPersonales.Application.Categories.Common;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Queries.GetCategoriesByUserId;

public class GetCategoriesByUserIdQueryHandler : IRequestHandler<GetCategoriesByUserIdQuery, List<CategoryResult>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesByUserIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryResult>> Handle(GetCategoriesByUserIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Obtener las categorias

        var categories = _categoryRepository.GetCategoriesByUserId(request.UserId);

        if (categories is null)
        {
            return new List<CategoryResult>();
        }

        // Retornar
        return categories.Select(account => new CategoryResult(account)).ToList();

    }
}