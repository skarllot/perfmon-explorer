using System.Diagnostics;
using LanguageExt;

namespace PerfMonExplorer;

public class Counter : IComparable
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

    int IComparable.CompareTo(object? obj)
    {
        return string.CompareOrdinal(ToString(), obj?.ToString());
    }
}