using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.MovemenAggregate.ValueObjects;

public sealed class MovementId : ValueObject
{
    public Guid Value { get; }

    private MovementId(Guid value)
    {
        Value = value;
    }

    public static MovementId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}