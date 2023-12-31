using FinanzasPersonales.Domain.CategoryAggregate.Events;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.CategoryAggregate;

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

    public void Update(
        string name,
        string description
    )
    {
        Name = name;
        Description = description;
    }

    public void Delete()
    {
        AddDomainEvent(new CategoryDeleted(this));
    }

#pragma warning disable CS8618
    private Category()
    {
    }
#pragma warning restore CS8618

}