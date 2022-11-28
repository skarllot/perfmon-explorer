using Gobie;

namespace PerfMonExplorer.Generators;

public sealed class ComparableOperatorsGenerator : GobieClassGenerator
{
    [GobieTemplate]
    private const string Template = @"
#nullable enable
    public static bool operator <({{ClassName}}? left, {{ClassName}}? right) => Compare(left, right) < 0;
    public static bool operator >({{ClassName}}? left, {{ClassName}}? right) => Compare(left, right) > 0;
    public static bool operator <=({{ClassName}}? left, {{ClassName}}? right) => Compare(left, right) <= 0;
    public static bool operator >=({{ClassName}}? left, {{ClassName}}? right) => Compare(left, right) >= 0;
    public static bool operator ==({{ClassName}}? left, {{ClassName}}? right) => Compare(left, right) == 0;
    public static bool operator !=({{ClassName}}? left, {{ClassName}}? right) => Compare(left, right) != 0;

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is {{ClassName}} other ? CompareTo(other) : throw new ArgumentException($""Object must be of type {nameof({{ClassName}})}"");
    }

    public bool Equals({{ClassName}}? other) => CompareTo(other) == 0;

    public override bool Equals(object? obj)
    {
        return obj is {{ClassName}} other ? Equals(other) : throw new ArgumentException($""Object must be of type {nameof({{ClassName}})}"");
    }

    private static int Compare({{ClassName}}? left, {{ClassName}}? right)
    {
        if (ReferenceEquals(left, right)) return 0;
        if (left is null) return -1;
        return left.CompareTo(right);
    }
#nullable restore
";
}