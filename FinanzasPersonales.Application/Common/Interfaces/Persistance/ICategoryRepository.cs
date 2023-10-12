using FinanzasPersonales.Domain.CategoryAggregate;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;


public interface ICategoryRepository
{
    void Add(Category cateogry);
    Category? GetCategoryById(Guid id);
    List<Category>? GetCategoriesByUserId(Guid userId);

    Category? GetTransferCategoryByUserId(Guid userId);
    
    void Update(Category category);
    void Delete(Category category);
}