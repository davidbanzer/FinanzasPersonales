using FinanzasPersonales.Domain.Category.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Movement.ValueObjects;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.Category;

public sealed class Category : AggregateRoot<CategoryId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public UserId UserId { get; private set; }

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

#pragma warning disable CS8618
    private Category()
    {
    }
#pragma warning restore CS8618

}