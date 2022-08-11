//
//  Category.cs
//
//  Author:
//       Fabricio Godoy <skarllot@gmail.com>
//
//  Copyright (c) 2013 Fabricio Godoy
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace perfmon_explorer.PerfMon
{
    internal class Category : IComparable
    {
        private PerformanceCounterCategory perfCat;

        private Category(PerformanceCounterCategory inner)
        {
            perfCat = inner;
        }

        public string Help
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

        public static Task<Category[]> GetCategoriesAsync()
        {
            return Task.Run(GetCategories);
        }

        public Task<Counter[]> GetCountersAsync(string instance)
        {
            return Task.Run(() => GetCounters(instance));
        }

        public Task<string[]> GetInstancesNamesAsync()
        {
            return Task.Run(GetInstancesNames);
        }

        private static Category[] GetCategories()
        {
            return PerformanceCounterCategory.GetCategories()
                .Select(static it => new Category(it))
                .ToArray();
        }

        private Counter[] GetCounters(string instance)
        {
            return perfCat.GetCounters(instance ?? "")
                .Select(static it => new Counter(it))
                .ToArray();
        }

        private string[] GetInstancesNames()
        {
            return perfCat.GetInstanceNames();
        }

        public override string ToString()
        {
            return perfCat.CategoryName;
        }

        int IComparable.CompareTo(object obj)
        {
            return string.CompareOrdinal(perfCat.CategoryName, obj.ToString());
        }
    }
}