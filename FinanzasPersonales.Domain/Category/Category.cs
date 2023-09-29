using FinanzasPersonales.Domain.Category.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.User.ValueObjects;

namespace FinanzasPersonales.Domain.Category;

public sealed class Category : AggregateRoot<CategoryId>
{
    public string Name { get; }
    public string Description { get; }
    public UserId UserId { get; }
    private Category(
        CategoryId categoryId,
        string name,
        string description,
        UserId userId
    ) : base(categoryId)
    {
        Id = categoryId;
        Name = name;
        Description = description;
        UserId = userId;
    }
    public static Category Create(
        string name,
        string description,
        UserId userId
    )
    {
        return new(
            CategoryId.CreateUnique(),
            name,
            description,
            userId
        );
    }
    
}