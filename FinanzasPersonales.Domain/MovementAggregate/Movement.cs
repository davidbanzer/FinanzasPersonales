using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovemenAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.MovemenAggregate;

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
        CategoryId categoryId
    )
    {
        return new(
            MovementId.CreateUnique(),
            description,
            amount,
            type,
            accountId,
            categoryId,
            DateTime.UtcNow
        );
    }
    
#pragma warning disable CS8618
    private Movement()
    {
    }
#pragma warning restore CS8618
}