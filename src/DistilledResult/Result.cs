using System.Diagnostics.CodeAnalysis;

namespace DistilledResult;

/// <summary>
/// Holds either a success value or an error — never both, and never neither.
/// </summary>
/// <remarks>
/// <para>
/// When <typeparamref name="TValue"/> and <typeparamref name="TError"/> are the same type, the
/// two implicit conversions become indistinguishable and any use of one is ambiguous (CS0457).
/// Such results can only be built through <see cref="Ok"/> and <see cref="Fail"/>.
/// </para>
/// <para>
/// When <typeparamref name="TValue"/> or <typeparamref name="TError"/> should carry nothing,
/// use <see cref="Unit.Value"/>.
/// </para>
/// </remarks>
/// <typeparam name="TValue">Type of the success value.</typeparam>
/// <typeparam name="TError">Type of the error.</typeparam>
public readonly struct Result<TValue, TError>
    where TValue : notnull
    where TError : notnull
{
    /// <summary>Creates a successful result. Use <see cref="Ok"/> instead.</summary>
    private Result(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        Value = value;
        Error = default;
        Success = true;
    }

    /// <summary>Creates a failed result. Use <see cref="Fail"/> instead.</summary>
    private Result(TError error)
    {
        if (error is null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        Value = default;
        Error = error;
        Success = false;
    }

    /// <summary>
    /// The success value or <see langword="default"/> when the result is a failure.
    /// </summary>
    /// <remarks>
    /// Non-null inside a branch guarded by <see cref="Success"/> being <see langword="true"/>
    /// or <see cref="Failure"/> being <see langword="false"/>.
    /// </remarks>
    public TValue? Value { get; }

    /// <summary>
    /// The error or <see langword="default"/> when the result is a success.
    /// </summary>
    /// <remarks>
    /// Non-null inside a branch guarded by <see cref="Failure"/> being <see langword="true"/>
    /// or <see cref="Success"/> being <see langword="false"/>.
    /// </remarks>
    public TError? Error { get; }

    /// <summary>
    /// <see langword="true"/> when the result holds a value, <see langword="false"/> when the result holds an error.
    /// </summary>
    /// <remarks>
    /// Narrows <see cref="Value"/> to non-null when <see langword="true"/>, and
    /// <see cref="Error"/> to non-null when <see langword="false"/>.
    /// </remarks>
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Error))]
    public bool Success { get; }

    /// <summary>
    /// <see langword="true"/> when the result holds an error, <see langword="false"/> when the result holds a value.
    /// </summary>
    /// <remarks>
    /// Narrows <see cref="Error"/> to non-null when <see langword="true"/>, and
    /// <see cref="Value"/> to non-null when <see langword="false"/>.
    /// </remarks>
    [MemberNotNullWhen(false, nameof(Value))]
    [MemberNotNullWhen(true, nameof(Error))]
    public bool Failure => !Success;

    /// <summary>Creates a successful result carrying <paramref name="value"/>.</summary>
    /// <param name="value">The success value.</param>
    /// <returns>A result for which <see cref="Success"/> is <see langword="true"/>.</returns>
    public static Result<TValue, TError> Ok(TValue value) => new(value);

    /// <summary>Creates a failed result carrying <paramref name="error"/>.</summary>
    /// <param name="error">The error.</param>
    /// <returns>A result for which <see cref="Success"/> is <see langword="false"/>.</returns>
    public static Result<TValue, TError> Fail(TError error) => new(error);

    /// <summary>
    /// Converts a value into a successful result.
    /// </summary>
    /// <param name="value">The success value.</param>
    /// <remarks>
    /// Unusable when <typeparamref name="TValue"/> and <typeparamref name="TError"/> are the
    /// same type: both operators then have identical signatures and every conversion is
    /// ambiguous (CS0457). Call <see cref="Ok"/> explicitly in that case.
    /// </remarks>
    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    /// <summary>
    /// Converts an error into a failed result.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <remarks>
    /// Unusable when <typeparamref name="TValue"/> and <typeparamref name="TError"/> are the
    /// same type: both operators then have identical signatures and every conversion is
    /// ambiguous (CS0457). Call <see cref="Fail"/> explicitly in that case.
    /// </remarks>
    public static implicit operator Result<TValue, TError>(TError error) => new(error);
}
