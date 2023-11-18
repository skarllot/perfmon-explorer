using System.Diagnostics;
using LanguageExt;

namespace PerfMonExplorer;

public sealed class Counter : IComparable<Counter>, IEquatable<Counter>
{
    private readonly PerformanceCounter _perfCount;

    internal Counter(PerformanceCounter inner)
    {
        _perfCount = inner;
    }

    public static bool operator <(Counter? left, Counter? right) => Compare(left, right) < 0;
    public static bool operator >(Counter? left, Counter? right) => Compare(left, right) > 0;
    public static bool operator <=(Counter? left, Counter? right) => Compare(left, right) <= 0;
    public static bool operator >=(Counter? left, Counter? right) => Compare(left, right) >= 0;
    public static bool operator ==(Counter? left, Counter? right) => Compare(left, right) == 0;
    public static bool operator !=(Counter? left, Counter? right) => Compare(left, right) != 0;

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

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(_perfCount.CounterName);
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is Counter other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Counter)}");
    }

    public int CompareTo(Counter? other)
    {
        return other is not null ? string.CompareOrdinal(_perfCount.CounterName, other._perfCount.CounterName) : 1;
    }

    public bool Equals(Counter? other) => CompareTo(other) == 0;

    public override bool Equals(object? obj)
    {
        return obj is Counter other ? Equals(other) : throw new ArgumentException($"Object must be of type {nameof(Counter)}");
    }

    private static int Compare(Counter? left, Counter? right)
    {
        if (ReferenceEquals(left, right)) return 0;
        if (left is null) return -1;
        return left.CompareTo(right);
    }
}
