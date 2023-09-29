using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.Common.ValueObjects;

public sealed class Amount : ValueObject
{
    public double Value { get; }

    private Amount(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("La cantidad de dinero debe ser mayor o igual a cero.");
        }

        Value = value;
    }

    public static Amount Create(double value)
    {
        return new Amount(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}