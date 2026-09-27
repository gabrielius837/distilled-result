namespace DistilledResult.FunctionalResultExtensions;

/// <summary>DefaultValue extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class DefaultValueResultExtensions
{
    /// <summary>Returns the success value, or <paramref name="defaultValue"/> on failure.</summary>
    public static TValue DefaultValue<TValue, TError>(
        this Result<TValue, TError> result,
        TValue defaultValue)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? result.Value
            : defaultValue;
    }
}

/// <summary>DefaultValue extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class DefaultValueTaskResultExtensions
{
    /// <summary>Returns the success value, or <paramref name="defaultValue"/> on failure.</summary>
    public static async Task<TValue> DefaultValue<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        TValue defaultValue)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : defaultValue;
    }
}

/// <summary>DefaultValue extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class DefaultValueValueTaskResultExtensions
{
    /// <summary>Returns the success value, or <paramref name="defaultValue"/> on failure.</summary>
    public static async ValueTask<TValue> DefaultValue<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        TValue defaultValue)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : defaultValue;
    }
}
