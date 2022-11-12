using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace perfmon_explorer.PerfMon
{
    internal class Category : IComparable
    {
        private readonly PerformanceCounterCategory perfCat;

        private Category(PerformanceCounterCategory inner)
        {
            perfCat = inner;
        }

        public string? Help
        {
            get
            {
                try
                {
                    return perfCat.CategoryHelp;
                }
                catch
                {
                    return null;
                }
            }
        }

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
            return perfCat.GetCounters(instance ?? "")
                .Select(static it => new Counter(it));
        }

        private string[] GetInstancesNames()
        {
            return perfCat.GetInstanceNames();
        }

        public override string ToString()
        {
            return perfCat.CategoryName;
        }

        int IComparable.CompareTo(object? obj)
        {
            return string.CompareOrdinal(perfCat.CategoryName, obj?.ToString());
        }
    }
}