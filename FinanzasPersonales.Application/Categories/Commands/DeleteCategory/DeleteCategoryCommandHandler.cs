using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Obtener la categoria
        var category = _categoryRepository.GetCategoryById(request.Id);

        if (category is null)
        {
            throw new Exception("La categoría no existe");
        }

        // Eliminar la categoria
        category.Delete(category);
        _categoryRepository.Delete(category);

        // Retornar

        return Unit.Value;
        
    }
}