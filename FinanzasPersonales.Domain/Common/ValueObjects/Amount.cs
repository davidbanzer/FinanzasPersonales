using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.Common.ValueObjects;

public sealed class Amount : ValueObject
{
    public decimal Value { get; }

    private Amount(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("La cantidad de dinero debe ser mayor o igual a cero.");
        }

        Value = value;
    }

    public static Amount Create(decimal value)
    {
        return new Amount(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}