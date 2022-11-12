using System.Diagnostics;

namespace perfmon_explorer.PerfMon
{
    public class Counter : IComparable
    {
        private readonly PerformanceCounter perfCount;

        internal Counter(PerformanceCounter inner)
        {
            perfCount = inner;
        }

        public long RawValue
        {
            get { return perfCount.RawValue; }
        }

        public string? Help
        {
            get
            {
                try
                {
                    return perfCount.CounterHelp;
                }
                catch
                {
                    return null;
                }
            }
        }

        public float NextValue()
        {
            return perfCount.NextValue();
        }

        public override string ToString()
        {
            return perfCount.CounterName;
        }

        int IComparable.CompareTo(object? obj)
        {
            return string.CompareOrdinal(ToString(), obj?.ToString());
        }
    }
}
