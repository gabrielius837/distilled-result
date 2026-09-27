using System.Runtime.CompilerServices;

namespace DistilledResult.FunctionalResultExtensions;

/// <summary>DefaultWith extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class DefaultWithResultExtensions
{
    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static TValue DefaultWith<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TError, TValue> func)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TError, Task<TValue>> func)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue, TError>(Result<TValue, TError>, Func<TError, Task<TValue>>)
    public static async ValueTask<TValue> DefaultWith<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TError, ValueTask<TValue>> func)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static TValue DefaultWith<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, TValue> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error, arg);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static TValue DefaultWith<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static TValue DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, TValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, Task<TValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue, TError, TArg>(Result<TValue, TError>, Func<TError, TArg, Task<TValue>>, TArg)
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, ValueTask<TValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue, TError, TArg1, TArg2>(Result<TValue, TError>, Func<TError, TArg1, TArg2, Task<TValue>>, TArg1, TArg2)
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(Result<TValue, TError>, Func<TError, TArg1, TArg2, TArg3, Task<TValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static TValue DefaultWith<TValue>(
        this Result<TValue, Unit> result,
        Func<TValue> func)
        where TValue : notnull
    {
        return result.Success
            ? result.Value
            : func();
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue>(
        this Result<TValue, Unit> result,
        Func<Task<TValue>> func)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue>(Result<TValue, Unit>, Func<Task<TValue>>)
    public static async ValueTask<TValue> DefaultWith<TValue>(
        this Result<TValue, Unit> result,
        Func<ValueTask<TValue>> func)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static TValue DefaultWith<TValue, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, TValue> func,
        TArg arg)
        where TValue : notnull
    {
        return result.Success
            ? result.Value
            : func(arg);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static TValue DefaultWith<TValue, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        return result.Success
            ? result.Value
            : func(arg1, arg2);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static TValue DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, TValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        return result.Success
            ? result.Value
            : func(arg1, arg2, arg3);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, Task<TValue>> func,
        TArg arg)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue, TArg>(Result<TValue, Unit>, Func<TArg, Task<TValue>>, TArg)
    public static async ValueTask<TValue> DefaultWith<TValue, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, ValueTask<TValue>> func,
        TArg arg)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue, TArg1, TArg2>(Result<TValue, Unit>, Func<TArg1, TArg2, Task<TValue>>, TArg1, TArg2)
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithResultExtensions.DefaultWith<TValue, TArg1, TArg2, TArg3>(Result<TValue, Unit>, Func<TArg1, TArg2, TArg3, Task<TValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}

/// <summary>DefaultWith extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class DefaultWithTaskResultExtensions
{
    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TValue> func)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue, TError>(Task<Result<TValue, TError>>, Func<TError, ValueTask<TValue>>)
    public static async Task<TValue> DefaultWith<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, Task<TValue>> func)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, TValue> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, TValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue, TError, TArg>(Task<Result<TValue, TError>>, Func<TError, TArg, ValueTask<TValue>>, TArg)
    public static async Task<TValue> DefaultWith<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, Task<TValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue, TError, TArg1, TArg2>(Task<Result<TValue, TError>>, Func<TError, TArg1, TArg2, ValueTask<TValue>>, TArg1, TArg2)
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(Task<Result<TValue, TError>>, Func<TError, TArg1, TArg2, TArg3, ValueTask<TValue>>, TArg1, TArg2, TArg3)
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TValue> func)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func();
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue>(Task<Result<TValue, Unit>>, Func<ValueTask<TValue>>)
    public static async Task<TValue> DefaultWith<TValue>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<Task<TValue>> func)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, TValue> func,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, TValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2, arg3);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue, TArg>(Task<Result<TValue, Unit>>, Func<TArg, ValueTask<TValue>>, TArg)
    public static async Task<TValue> DefaultWith<TValue, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, Task<TValue>> func,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue, TArg1, TArg2>(Task<Result<TValue, Unit>>, Func<TArg1, TArg2, ValueTask<TValue>>, TArg1, TArg2)
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithTaskResultExtensions.DefaultWith<TValue, TArg1, TArg2, TArg3>(Task<Result<TValue, Unit>>, Func<TArg1, TArg2, TArg3, ValueTask<TValue>>, TArg1, TArg2, TArg3)
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, ValueTask<TValue>> func)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, ValueTask<TValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<ValueTask<TValue>> func)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, ValueTask<TValue>> func,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async Task<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}

/// <summary>DefaultWith extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class DefaultWithValueTaskResultExtensions
{
    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TValue> func)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue, TError>(ValueTask<Result<TValue, TError>>, Func<TError, Task<TValue>>)
    public static async ValueTask<TValue> DefaultWith<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, ValueTask<TValue>> func)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, TValue> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, TValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue, TError, TArg>(ValueTask<Result<TValue, TError>>, Func<TError, TArg, Task<TValue>>, TArg)
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, ValueTask<TValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue, TError, TArg1, TArg2>(ValueTask<Result<TValue, TError>>, Func<TError, TArg1, TArg2, Task<TValue>>, TArg1, TArg2)
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, TError>>, Func<TError, TArg1, TArg2, TArg3, Task<TValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TValue> func)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func();
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue>(ValueTask<Result<TValue, Unit>>, Func<Task<TValue>>)
    public static async ValueTask<TValue> DefaultWith<TValue>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<ValueTask<TValue>> func)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, TValue> func,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, TValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? result.Value
            : func(arg1, arg2, arg3);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue, TArg>(ValueTask<Result<TValue, Unit>>, Func<TArg, Task<TValue>>, TArg)
    public static async ValueTask<TValue> DefaultWith<TValue, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, ValueTask<TValue>> func,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue, TArg1, TArg2>(ValueTask<Result<TValue, Unit>>, Func<TArg1, TArg2, Task<TValue>>, TArg1, TArg2)
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    [OverloadResolutionPriority(1)]
    // DefaultWithValueTaskResultExtensions.DefaultWith<TValue, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, Unit>>, Func<TArg1, TArg2, TArg3, Task<TValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, Task<TValue>> func)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, Task<TValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes from the error on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<Task<TValue>> func)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, Task<TValue>> func,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Returns the success value, or the value <paramref name="func"/> computes on failure.</summary>
    public static async ValueTask<TValue> DefaultWith<TValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<TValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            return result.Value;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}
