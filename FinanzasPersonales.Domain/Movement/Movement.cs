using FinanzasPersonales.Domain.Account.ValueObjects;
using FinanzasPersonales.Domain.Category.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.Movement.ValueObjects;

namespace FinanzasPersonales.Domain.Movement;

public sealed class Movement : AggregateRoot<MovementId>
{
    public string Description { get;  }
    public Amount Amount { get; }
    public string Type { get; }
    public AccountId AccountId { get; }

    public CategoryId CategoryId { get; }
    public DateTime CreatedDate { get; }

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
    

}