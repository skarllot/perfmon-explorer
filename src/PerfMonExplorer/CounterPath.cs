using System.Text;
using Microsoft.Win32;

namespace PerfMonExplorer;

public struct CounterPath
{
    private const string KeyPerflibCurlang = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\CurrentLanguage";
    private const string KeyPerflibDefault = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\009";
    private static readonly int[] IdListEn = Array.Empty<int>();
    private static readonly int[] IdListLang = Array.Empty<int>();
    private static readonly string[] NameListEn = Array.Empty<string>();
    private static readonly string[] NameListLang = Array.Empty<string>();

    static CounterPath()
    {
        int pos = 0;

        var regKey = Registry.LocalMachine.OpenSubKey(KeyPerflibDefault);
        if (regKey is null) return;

        var strCounter = regKey.GetValue("Counter") as string[];
        regKey.Close();
        if (strCounter is null) return;

        IdListEn = new int[strCounter.Length / 2];
        NameListEn = new string[strCounter.Length / 2];
        for (int i = 0; i < strCounter.Length; i += 2)
        {
            if (string.IsNullOrEmpty(strCounter[i]) ||
                string.IsNullOrEmpty(strCounter[i + 1]))
            {
                continue;
            }
            IdListEn[pos] = int.Parse(strCounter[i]);
            NameListEn[pos] = strCounter[i + 1];
            pos++;
        }

        // Current Language
        try { regKey = Registry.LocalMachine.OpenSubKey(KeyPerflibCurlang); }
        catch { return; }

        if (regKey is null) return;

        strCounter = regKey.GetValue("Counter") as string[];
        regKey.Close();
        if (strCounter is null) return;

        IdListLang = new int[strCounter.Length / 2];
        NameListLang = new string[strCounter.Length / 2];
        pos = 0;
        for (int i = 0; i < strCounter.Length; i += 2)
        {
            if (string.IsNullOrEmpty(strCounter[i]) ||
                string.IsNullOrEmpty(strCounter[i + 1]))
            {
                continue;
            }
            IdListLang[pos] = int.Parse(strCounter[i]);
            NameListLang[pos] = strCounter[i + 1];
            pos++;
        }
    }

    public int CategoryId { get; set; }

    public string? CategoryName
    {
        get => GetName(CategoryId);
        set => CategoryId = GetId(value);
    }

    public int CounterId { get; set; }

    public string? CounterName
    {
        get => GetName(CounterId);
        set => CounterId = GetNearestCounterId(GetAllIds(value));
    }

    public string InstanceName { get; set; }

    private static int GetId(string? name)
    {
        int idx = Array.IndexOf(NameListLang, name);
        if (idx != -1)
            return IdListLang[idx];

        idx = Array.IndexOf(NameListEn, name);
        if (idx != -1)
            return IdListEn[idx];

        return 0;
    }

    private static int[] GetAllIds(string? name)
    {
        int[] ids;
        int pos = 0;
        int[] indexes = Utils.IndexOfAll(NameListLang, name);
        if (indexes.Length > 0)
        {
            ids = new int[indexes.Length];
            foreach (int item in indexes)
            {
                ids[pos] = IdListLang[item];
                pos++;
            }
            return ids;
        }

        indexes = Utils.IndexOfAll(NameListEn, name);
        if (indexes.Length > 0)
        {
            ids = new int[indexes.Length];
            foreach (int item in indexes)
            {
                ids[pos] = IdListEn[item];
                pos++;
            }
            return ids;
        }

        return Array.Empty<int>();
    }

    public string GetIdPath()
    {
        string path = string.Empty;

        if (CategoryId > 0)
        {
            path = "\\" + CategoryId.ToString();
            if (InstanceName != null)
                path += "(" + InstanceName + ")";
            if (CounterId > 0)
                path += "\\" + CounterId.ToString();
        }

        return path;
    }

    private static string? GetName(int id)
    {
        int idx = Array.IndexOf(IdListLang, id);
        if (idx != -1)
            return NameListLang[idx];

        idx = Array.IndexOf(IdListEn, id);
        if (idx != -1)
            return NameListEn[idx];

        return null;
    }

    private int GetNearestCounterId(int[]? ids)
    {
        if (ids == null ||
            CategoryId == 0 ||
            ids.Length < 1)
            return -1;

        int minor = int.MaxValue;
        int idx = -1, diff;
        for (int i = 0; i < ids.Length; i++)
        {
            diff = Math.Abs(ids[i] - CategoryId);
            if (diff < minor)
            {
                minor = diff;
                idx = i;
            }
        }

        return ids[idx];
    }

    public string GetPath()
    {
        var pathBuilder = new StringBuilder();

        if (CategoryId > 0)
        {
            pathBuilder.AppendFormat("\\{0}", CategoryName);
            if (InstanceName != null)
                pathBuilder.AppendFormat("({0})", InstanceName);
            if (CounterId > 0)
                pathBuilder.AppendFormat("\\{0}", CounterName);
        }

        return pathBuilder.ToString();
    }

    public override string ToString()
    {
        return GetPath();
    }
}