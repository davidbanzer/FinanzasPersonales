using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.Account.ValueObjects;

public sealed class AccountId : ValueObject
{
    public Guid Value { get; }

    private AccountId(Guid value)
    {
        Value = value;
    }

    public static AccountId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}