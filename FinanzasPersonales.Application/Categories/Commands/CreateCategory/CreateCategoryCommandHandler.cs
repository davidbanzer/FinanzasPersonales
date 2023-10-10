using FinanzasPersonales.Application.Categories.Common;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.CategoryAggregate;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Crear categoria
        var category = Category.Create(
             request.Name,
             request.Description,
             UserId.Create(request.UserId)
        );

        // Persistir
        _categoryRepository.Add(category);

        // Retornar categoria
        return new CategoryResult(category);
    }
}