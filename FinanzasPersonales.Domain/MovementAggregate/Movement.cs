using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.MovementAggregate;

public sealed class Movement : AggregateRoot<MovementId>
{
    public string Description { get; private set;  }
    public Amount Amount { get; private set; }
    public string Type { get; private set; }
    public AccountId AccountId { get; private set; }

    public CategoryId CategoryId { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private Movement(
        MovementId movementId,
        string description,
        Amount amount,
        string type,
        AccountId accountId,
        CategoryId categoryId,
        DateTime createdDate
    ) : base(movementId)
    {
        Id = movementId;
        Description = description;
        Amount = amount;
        Type = type;
        AccountId = accountId;
        CategoryId = categoryId;
        CreatedDate = createdDate;
    }
    public static Movement Create(
        string description,
        Amount amount,
        string type,
        AccountId accountId,
        CategoryId categoryId,
        DateTime createdDate
    )
    {
        return new(
            MovementId.CreateUnique(),
            description,
            amount,
            type,
            accountId,
            categoryId,
            createdDate
        );
    }

    public void Update(
        string description,
        Amount amount,
        string type,
        CategoryId categoryId,
        AccountId accountId,
        DateTime createdDate
    )
    {
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
        AccountId = accountId;
        CreatedDate = createdDate;
    }
    
#pragma warning disable CS8618
    private Movement()
    {
    }
#pragma warning restore CS8618
}