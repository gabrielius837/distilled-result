using System.Runtime.CompilerServices;

namespace DistilledResult.FunctionalResultExtensions;

/// <summary>Map extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class MapResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TValue, TError, TNewValue>(
        this Result<TValue, TError> result,
        Func<TValue, TNewValue> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this Result<TValue, TError> result,
        Func<TValue, Task<TNewValue>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TValue, TError, TNewValue>(Result<TValue, TError>, Func<TValue, Task<TNewValue>>)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this Result<TValue, TError> result,
        Func<TValue, ValueTask<TNewValue>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TValue, TError, TNewValue, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, TNewValue> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg1, arg2)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg1, arg2, arg3)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, Task<TNewValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TValue, TError, TNewValue, TArg>(Result<TValue, TError>, Func<TValue, TArg, Task<TNewValue>>, TArg)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, ValueTask<TNewValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TValue, TError, TNewValue, TArg1, TArg2>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, Task<TNewValue>>, TArg1, TArg2)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, TArg3, Task<TNewValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TError, TNewValue>(
        this Result<Unit, TError> result,
        Func<TNewValue> func)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func()
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this Result<Unit, TError> result,
        Func<Task<TNewValue>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TError, TNewValue>(Result<Unit, TError>, Func<Task<TNewValue>>)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this Result<Unit, TError> result,
        Func<ValueTask<TNewValue>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TError, TNewValue, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, TNewValue> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success ? func(arg) : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TError, TNewValue, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success ? func(arg1, arg2) : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success ? func(arg1, arg2, arg3) : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, Task<TNewValue>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TError, TNewValue, TArg>(Result<Unit, TError>, Func<TArg, Task<TNewValue>>, TArg)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, ValueTask<TNewValue>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TError, TNewValue, TArg1, TArg2>(Result<Unit, TError>, Func<TArg1, TArg2, Task<TNewValue>>, TArg1, TArg2)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapResultExtensions.Map<TError, TNewValue, TArg1, TArg2, TArg3>(Result<Unit, TError>, Func<TArg1, TArg2, TArg3, Task<TNewValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}

/// <summary>Map extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class MapTaskResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TNewValue> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TValue, TError, TNewValue>(Task<Result<TValue, TError>>, Func<TValue, ValueTask<TNewValue>>)
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, Task<TNewValue>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, TNewValue> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value, arg)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value, arg1, arg2)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value, arg1, arg2, arg3)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TValue, TError, TNewValue, TArg>(Task<Result<TValue, TError>>, Func<TValue, TArg, ValueTask<TNewValue>>, TArg)
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task<TNewValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TValue, TError, TNewValue, TArg1, TArg2>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, ValueTask<TNewValue>>, TArg1, TArg2)
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, ValueTask<TNewValue>>, TArg1, TArg2, TArg3)
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TNewValue> func)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func()
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TError, TNewValue>(Task<Result<Unit, TError>>, Func<ValueTask<TNewValue>>)
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this Task<Result<Unit, TError>> resultTask,
        Func<Task<TNewValue>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, TNewValue> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(arg)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(arg1, arg2)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(arg1, arg2, arg3)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TError, TNewValue, TArg>(Task<Result<Unit, TError>>, Func<TArg, ValueTask<TNewValue>>, TArg)
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, Task<TNewValue>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TError, TNewValue, TArg1, TArg2>(Task<Result<Unit, TError>>, Func<TArg1, TArg2, ValueTask<TNewValue>>, TArg1, TArg2)
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapTaskResultExtensions.Map<TError, TNewValue, TArg1, TArg2, TArg3>(Task<Result<Unit, TError>>, Func<TArg1, TArg2, TArg3, ValueTask<TNewValue>>, TArg1, TArg2, TArg3)
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask<TNewValue>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask<TNewValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this Task<Result<Unit, TError>> resultTask,
        Func<ValueTask<TNewValue>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, ValueTask<TNewValue>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}

/// <summary>Map extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class MapValueTaskResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TNewValue> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TValue, TError, TNewValue>(ValueTask<Result<TValue, TError>>, Func<TValue, Task<TNewValue>>)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask<TNewValue>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, TNewValue> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value, arg)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value, arg1, arg2)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(result.Value, arg1, arg2, arg3)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TValue, TError, TNewValue, TArg>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg, Task<TNewValue>>, TArg)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask<TNewValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TValue, TError, TNewValue, TArg1, TArg2>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, Task<TNewValue>>, TArg1, TArg2)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, Task<TNewValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TNewValue> func)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func()
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TError, TNewValue>(ValueTask<Result<Unit, TError>>, Func<Task<TNewValue>>)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<ValueTask<TNewValue>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, TNewValue> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(arg)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(arg1, arg2)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, TNewValue> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? func(arg1, arg2, arg3)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TError, TNewValue, TArg>(ValueTask<Result<Unit, TError>>, Func<TArg, Task<TNewValue>>, TArg)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, ValueTask<TNewValue>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TError, TNewValue, TArg1, TArg2>(ValueTask<Result<Unit, TError>>, Func<TArg1, TArg2, Task<TNewValue>>, TArg1, TArg2)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // MapValueTaskResultExtensions.Map<TError, TNewValue, TArg1, TArg2, TArg3>(ValueTask<Result<Unit, TError>>, Func<TArg1, TArg2, TArg3, Task<TNewValue>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, Task<TNewValue>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task<TNewValue>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<Task<TNewValue>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func().ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, Task<TNewValue>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2).ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Map<TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<TNewValue>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            return result.Error;
        }

        return await func(arg1, arg2, arg3).ConfigureAwait(false);
    }
}
