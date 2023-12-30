using CompanyGear.Core.Abstractions;

namespace CompanyGear.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}