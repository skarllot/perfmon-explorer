using System.Diagnostics;
using Gobie;
using LanguageExt;

namespace PerfMonExplorer;

[ComparableOperators]
public sealed partial class Counter : IComparable<Counter>, IEquatable<Counter>
{
    private readonly PerformanceCounter _perfCount;

    internal Counter(PerformanceCounter inner)
    {
        _perfCount = inner;
    }

    public long RawValue => _perfCount.RawValue;

    public Try<string> Help => () => _perfCount.CounterHelp;

    public float NextValue()
    {
        return _perfCount.NextValue();
    }

    public override string ToString()
    {
        return _perfCount.CounterName;
    }

    public int CompareTo(Counter? other)
    {
        return other is not null ? string.CompareOrdinal(_perfCount.CounterName, other._perfCount.CounterName) : 1;
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(_perfCount.CounterName);
    }
}