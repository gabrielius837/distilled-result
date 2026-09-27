using System.Runtime.CompilerServices;

namespace DistilledResult.FunctionalResultExtensions;

/// <summary>MapError extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class MapErrorResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TError, TNewError>(
        this Result<TValue, TError> result,
        Func<TError, TNewError> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this Result<TValue, TError> result,
        Func<TError, Task<TNewError>> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TError, TNewError>(Result<TValue, TError>, Func<TError, Task<TNewError>>)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this Result<TValue, TError> result,
        Func<TError, ValueTask<TNewError>> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TError, TNewError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, TNewError> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error, arg);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TNewError> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, TNewError> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, Task<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TError, TNewError, TArg>(Result<TValue, TError>, Func<TError, TArg, Task<TNewError>>, TArg)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, ValueTask<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TError, TNewError, TArg1, TArg2>(Result<TValue, TError>, Func<TError, TArg1, TArg2, Task<TNewError>>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(Result<TValue, TError>, Func<TError, TArg1, TArg2, TArg3, Task<TNewError>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TNewError>(
        this Result<TValue, Unit> result,
        Func<TNewError> func)
        where TValue : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func();
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this Result<TValue, Unit> result,
        Func<Task<TNewError>> func)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TNewError>(Result<TValue, Unit>, Func<Task<TNewError>>)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this Result<TValue, Unit> result,
        Func<ValueTask<TNewError>> func)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TNewError, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, TNewError> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func(arg);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TNewError, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TNewError> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func(arg1, arg2);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static Result<TValue, TNewError> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, TNewError> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        return result.Success
            ? result.Value
            : func(arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, Task<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TNewError, TArg>(Result<TValue, Unit>, Func<TArg, Task<TNewError>>, TArg)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, ValueTask<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TNewError, TArg1, TArg2>(Result<TValue, Unit>, Func<TArg1, TArg2, Task<TNewError>>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorResultExtensions.MapError<TValue, TNewError, TArg1, TArg2, TArg3>(Result<TValue, Unit>, Func<TArg1, TArg2, TArg3, Task<TNewError>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}

/// <summary>MapError extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class MapErrorTaskResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TNewError> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TError, TNewError>(Task<Result<TValue, TError>>, Func<TError, ValueTask<TNewError>>)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, Task<TNewError>> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, TNewError> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TNewError> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, TNewError> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TError, TNewError, TArg>(Task<Result<TValue, TError>>, Func<TError, TArg, ValueTask<TNewError>>, TArg)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, Task<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TError, TNewError, TArg1, TArg2>(Task<Result<TValue, TError>>, Func<TError, TArg1, TArg2, ValueTask<TNewError>>, TArg1, TArg2)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(Task<Result<TValue, TError>>, Func<TError, TArg1, TArg2, TArg3, ValueTask<TNewError>>, TArg1, TArg2, TArg3)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TNewError> func)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func();
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TNewError>(Task<Result<TValue, Unit>>, Func<ValueTask<TNewError>>)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<Task<TNewError>> func)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, TNewError> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TNewError> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, TNewError> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TNewError, TArg>(Task<Result<TValue, Unit>>, Func<TArg, ValueTask<TNewError>>, TArg)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, Task<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TNewError, TArg1, TArg2>(Task<Result<TValue, Unit>>, Func<TArg1, TArg2, ValueTask<TNewError>>, TArg1, TArg2)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorTaskResultExtensions.MapError<TValue, TNewError, TArg1, TArg2, TArg3>(Task<Result<TValue, Unit>>, Func<TArg1, TArg2, TArg3, ValueTask<TNewError>>, TArg1, TArg2, TArg3)
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, ValueTask<TNewError>> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, ValueTask<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<ValueTask<TNewError>> func)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, ValueTask<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async Task<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}

/// <summary>MapError extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class MapErrorValueTaskResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TNewError> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TError, TNewError>(ValueTask<Result<TValue, TError>>, Func<TError, Task<TNewError>>)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, ValueTask<TNewError>> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, TNewError> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TNewError> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, TNewError> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TError, TNewError, TArg>(ValueTask<Result<TValue, TError>>, Func<TError, TArg, Task<TNewError>>, TArg)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, ValueTask<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TError, TNewError, TArg1, TArg2>(ValueTask<Result<TValue, TError>>, Func<TError, TArg1, TArg2, Task<TNewError>>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, TError>>, Func<TError, TArg1, TArg2, TArg3, Task<TNewError>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TNewError> func)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func();
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TNewError>(ValueTask<Result<TValue, Unit>>, Func<Task<TNewError>>)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<ValueTask<TNewError>> func)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, TNewError> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TNewError> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, TNewError> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TNewError, TArg>(ValueTask<Result<TValue, Unit>>, Func<TArg, Task<TNewError>>, TArg)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, ValueTask<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TNewError, TArg1, TArg2>(ValueTask<Result<TValue, Unit>>, Func<TArg1, TArg2, Task<TNewError>>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    [OverloadResolutionPriority(1)]
    // MapErrorValueTaskResultExtensions.MapError<TValue, TNewError, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, Unit>>, Func<TArg1, TArg2, TArg3, Task<TNewError>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, Task<TNewError>> func)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, Task<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TError, TNewError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<Task<TNewError>> func)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, Task<TNewError>> func,
        TArg arg)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the error and returns its result, otherwise returns the value.</summary>
    public static async ValueTask<Result<TValue, TNewError>> MapError<TValue, TNewError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<TNewError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TNewError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}
