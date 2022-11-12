using System.Diagnostics;
using LanguageExt;

namespace PerfMonExplorer;

public class Category : IComparable
{
    private readonly PerformanceCounterCategory _perfCat;

    private Category(PerformanceCounterCategory inner)
    {
        _perfCat = inner;
    }

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

    int IComparable.CompareTo(object? obj)
    {
        return string.CompareOrdinal(_perfCat.CategoryName, obj?.ToString());
    }
}