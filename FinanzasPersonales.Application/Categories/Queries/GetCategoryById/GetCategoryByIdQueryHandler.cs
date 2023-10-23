using FinanzasPersonales.Application.Categories.Common;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler: IRequestHandler<GetCategoryByIdQuery, CategoryResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var category = _categoryRepository.GetCategoryById(request.Id);

        if(category is null)
        {
            throw new Exception("La categoria no existe");
        }
        
        return new CategoryResult(category);
    }
}