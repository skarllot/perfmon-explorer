using System.Collections;

namespace PerfMonExplorer;

public static class Utils
{
    public static int[] IndexOfAll<T>(T[] list, T? item)
        where T : IComparable
    {
        var indexes = new List<int>();
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].CompareTo(item) == 0)
                indexes.Add(i);
        }

        return indexes.ToArray();
    }

    public static void AddRange(this IList collection, IEnumerable<object> items)
    {
        foreach (object item in items)
        {
            collection.Add(item);
        }
    }
}