using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace perfmon_explorer.PerfMon
{
    class Counter : IComparable
    {
        PerformanceCounter perfCount;

        internal Counter(PerformanceCounter inner)
        {
            perfCount = inner;
        }

        public override string ToString()
        {
            return perfCount.CounterName;
        }

        int IComparable.CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}
