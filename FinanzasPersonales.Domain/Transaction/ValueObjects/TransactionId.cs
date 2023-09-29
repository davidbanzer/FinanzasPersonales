using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.Transaction.ValueObjects;

public sealed class TransactionId : ValueObject
{
    public Guid Value { get; }

    private TransactionId(Guid value)
    {
        Value = value;
    }

    public static TransactionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}