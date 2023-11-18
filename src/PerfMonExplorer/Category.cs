using System.Diagnostics;
using LanguageExt;

namespace PerfMonExplorer;

public sealed class Category : IComparable<Category>, IEquatable<Category>
{
    private readonly PerformanceCounterCategory _perfCat;

    private Category(PerformanceCounterCategory inner)
    {
        _perfCat = inner;
    }

    public static bool operator <(Category? left, Category? right) => Compare(left, right) < 0;
    public static bool operator >(Category? left, Category? right) => Compare(left, right) > 0;
    public static bool operator <=(Category? left, Category? right) => Compare(left, right) <= 0;
    public static bool operator >=(Category? left, Category? right) => Compare(left, right) >= 0;
    public static bool operator ==(Category? left, Category? right) => Compare(left, right) == 0;
    public static bool operator !=(Category? left, Category? right) => Compare(left, right) != 0;

    public Try<string> Help => () => _perfCat.CategoryHelp;

    public static Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return Task.Run(GetCategories);
    }

    public Task<IEnumerable<Counter>> GetCountersAsync(string? instance)
    {
        return Task.Run(() => GetCounters(instance));
    }

    public Task<string[]> GetInstancesNamesAsync()
    {
        return Task.Run(GetInstancesNames);
    }

    private static IEnumerable<Category> GetCategories()
    {
        return PerformanceCounterCategory.GetCategories()
            .Select(static it => new Category(it));
    }

    private IEnumerable<Counter> GetCounters(string? instance)
    {
        return _perfCat.GetCounters(instance ?? "")
            .Select(static it => new Counter(it));
    }

    private string[] GetInstancesNames()
    {
        return _perfCat.GetInstanceNames();
    }

    public override string ToString()
    {
        return _perfCat.CategoryName;
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(_perfCat.CategoryName);
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is Category other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Category)}");
    }

    public int CompareTo(Category? other)
    {
        return other is not null ? string.CompareOrdinal(_perfCat.CategoryName, other._perfCat.CategoryName) : 1;
    }

    public bool Equals(Category? other) => CompareTo(other) == 0;

    public override bool Equals(object? obj)
    {
        return obj is Category other ? Equals(other) : throw new ArgumentException($"Object must be of type {nameof(Category)}");
    }

    private static int Compare(Category? left, Category? right)
    {
        if (ReferenceEquals(left, right)) return 0;
        if (left is null) return -1;
        return left.CompareTo(right);
    }
}
