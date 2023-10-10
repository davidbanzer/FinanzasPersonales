using FinanzasPersonales.Application.Categories.Common;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Obtener la categoria
        var category = _categoryRepository.GetCategoryById(request.Id);

        if (category is null)
        {
            throw new Exception("La categoría no existe");
        }

        // Actualizar la categoria
        category.Update(
            request.Name,
            request.Description
        );

        // Persistir
        _categoryRepository.Update(category);

        // Retornar categoria

        return new CategoryResult(category);
    }
}