using FinanzasPersonales.Domain.CategoryAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;


public interface ICategoryRepository
{
    void Add(Category cateogry);
    Category? GetCategoryById(Guid id);
    Category? GetCategoryByUserId(Guid userId);

    void Update(Category category);
    void Delete(Category category);
}