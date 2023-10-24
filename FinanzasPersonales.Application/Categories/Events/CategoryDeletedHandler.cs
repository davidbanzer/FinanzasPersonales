using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.CategoryAggregate;
using FinanzasPersonales.Domain.CategoryAggregate.Events;
using MediatR;

namespace FinanzasPersonales.Application.Categories.Events;

public class CategoryDeletedHandler: INotificationHandler<CategoryDeleted>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMovementRepository _movementRepository;

    public CategoryDeletedHandler(IMovementRepository movementRepository, ICategoryRepository categoryRepository)
    {
        _movementRepository = movementRepository;
        _categoryRepository = categoryRepository;
    }

    public Task Handle(CategoryDeleted notification, CancellationToken cancellationToken)
    {
        
        // obtener todos los movimientos de la categoria
        var movements = _movementRepository.GetMovementsByCategoryId(notification.Category.Id.Value);
        
        if(movements is null)
        {
            return Task.CompletedTask;
        }
        // Crear una categoría "Sin categoría"
        var defaultCategory = Category.Create(
            "Sin categoría",
            "Aquí están los movimientos que no tienen categoría",
            notification.Category.UserId
        );

        _categoryRepository.Add(defaultCategory);
        // actualizar los movimientos con la categoria por defecto

        foreach (var movement in movements)
        {
            movement.Update(
                movement.Description,
                movement.Amount,
                movement.Type,
                defaultCategory.Id,
                movement.AccountId,
                movement.CreatedDate
            );
            _movementRepository.Update(movement);
        }

        return Task.CompletedTask;
    }
}