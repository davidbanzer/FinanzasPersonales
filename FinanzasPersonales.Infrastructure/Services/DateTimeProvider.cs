using FinanzasPersonales.Application.Common.Interfaces.Services;

namespace FinanzasPersonales.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}