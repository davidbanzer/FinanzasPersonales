using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.CategoryAggregate;

namespace FinanzasPersonales.Infrastructure.Persistance.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly FinanzasPersonalesDbContext _dbContext;

    public CategoryRepository(FinanzasPersonalesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Category cateogry)
    {
        _dbContext.Add(cateogry);
        _dbContext.SaveChanges();
    }

    public void Delete(Category category)
    {
        _dbContext.Remove(category);
        _dbContext.SaveChanges();
    }

    public Category? GetCategoryById(Guid id)
    {
        return _dbContext.Categories
        .AsEnumerable() 
        .SingleOrDefault(u => u.Id.Value == id);
    }

    public List<Category>? GetCategoriesByUserId(Guid userId)
    {
        return _dbContext.Categories
        .AsEnumerable() 
        .Where(u => u.UserId.Value == userId)
        .ToList();
    }

    public void Update(Category category)
    {
        _dbContext.Update(category);
        _dbContext.SaveChanges();
    }
}