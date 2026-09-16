namespace DistilledResult;

/// <summary>
/// A definition used where a type argument is required but there is
/// nothing to carry.
/// </summary>
public readonly struct Unit
{
    /// <summary>The singleton instance of <see cref="Unit"/>.</summary>
    public static Unit Value { get; } = default;
}
