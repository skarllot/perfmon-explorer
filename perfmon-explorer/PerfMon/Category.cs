using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace perfmon_explorer.PerfMon
{
    class Category : IComparable
    {
        PerformanceCounterCategory perfCat;

        Category(PerformanceCounterCategory inner)
        {
            perfCat = inner;
        }

        public string[] GetInstancesNames()
        {
            return perfCat.GetInstanceNames();
        }

        public Counter[] GetCounters(string instance)
        {
            PerformanceCounter[] counters = perfCat.GetCounters(instance ?? "");
            Counter[] ret = new Counter[counters.Length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new Counter(counters[i]);
            }

            return ret;
        }

        public override string ToString()
        {
            return perfCat.CategoryName;
        }

        public static Category[] GetCategories()
        {
            PerformanceCounterCategory[] perfCats = PerformanceCounterCategory.GetCategories();
            Category[] ret = new Category[perfCats.Length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new Category(perfCats[i]);
            }

            return ret;
        }

        int IComparable.CompareTo(object obj)
        {
            return this.perfCat.CategoryName.CompareTo(obj.ToString());
        }
    }
}
