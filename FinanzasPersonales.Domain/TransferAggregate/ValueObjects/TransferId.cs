using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.TransferAggregate.ValueObjects;

public sealed class TransferId : ValueObject
{
    public Guid Value { get; }

    private TransferId(Guid value)
    {
        Value = value;
    }

    public static TransferId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static TransferId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}