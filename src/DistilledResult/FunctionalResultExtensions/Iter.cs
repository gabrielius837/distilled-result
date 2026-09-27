using System.Runtime.CompilerServices;

namespace DistilledResult.FunctionalResultExtensions;

/// <summary>Iter extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class IterResultExtensions
{
    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> Iter<TValue, TError>(
        this Result<TValue, TError> result,
        Action<TValue> action)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            action(result.Value);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TValue, Task> action)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TValue, TError>(Result<TValue, TError>, Func<TValue, Task>)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TValue, ValueTask> action)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> Iter<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Action<TValue, TArg> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            action(result.Value, arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> Iter<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Action<TValue, TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            action(result.Value, arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Action<TValue, TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            action(result.Value, arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, Task> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TValue, TError, TArg>(Result<TValue, TError>, Func<TValue, TArg, Task>, TArg)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TValue, TError, TArg1, TArg2>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TValue, TError, TArg1, TArg2, TArg3>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Success)
        {
            await action(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<Unit, TError> Iter<TError>(
        this Result<Unit, TError> result,
        Action action)
        where TError : notnull
    {
        if (result.Success)
        {
            action();
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError>(
        this Result<Unit, TError> result,
        Func<Task> action)
        where TError : notnull
    {
        if (result.Success)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TError>(Result<Unit, TError>, Func<Task>)
    public static async ValueTask<Result<Unit, TError>> Iter<TError>(
        this Result<Unit, TError> result,
        Func<ValueTask> action)
        where TError : notnull
    {
        if (result.Success)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<Unit, TError> Iter<TError, TArg>(
        this Result<Unit, TError> result,
        Action<TArg> action,
        TArg arg)
        where TError : notnull
    {
        if (result.Success)
        {
            action(arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<Unit, TError> Iter<TError, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Action<TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        if (result.Success)
        {
            action(arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<Unit, TError> Iter<TError, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Action<TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        if (result.Success)
        {
            action(arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, Task> action,
        TArg arg)
        where TError : notnull
    {
        if (result.Success)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        if (result.Success)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        if (result.Success)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TError, TArg>(Result<Unit, TError>, Func<TArg, Task>, TArg)
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, ValueTask> action,
        TArg arg)
        where TError : notnull
    {
        if (result.Success)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TError, TArg1, TArg2>(Result<Unit, TError>, Func<TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        if (result.Success)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterResultExtensions.Iter<TError, TArg1, TArg2, TArg3>(Result<Unit, TError>, Func<TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        if (result.Success)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }
}

/// <summary>Iter extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class IterTaskResultExtensions
{
    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TValue> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TValue, TError>(Task<Result<TValue, TError>>, Func<TValue, ValueTask>)
    public static async Task<Result<TValue, TError>> Iter<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, Task> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TValue, TArg> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value, arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TValue, TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value, arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TValue, TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value, arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TValue, TError, TArg>(Task<Result<TValue, TError>>, Func<TValue, TArg, ValueTask>, TArg)
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TValue, TError, TArg1, TArg2>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, ValueTask>, TArg1, TArg2)
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TValue, TError, TArg1, TArg2, TArg3>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, ValueTask>, TArg1, TArg2, TArg3)
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError>(
        this Task<Result<Unit, TError>> resultTask,
        Action action)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action();
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TError>(Task<Result<Unit, TError>>, Func<ValueTask>)
    public static async Task<Result<Unit, TError>> Iter<TError>(
        this Task<Result<Unit, TError>> resultTask,
        Func<Task> action)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Action<TArg> action,
        TArg arg)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Action<TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Action<TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TError, TArg>(Task<Result<Unit, TError>>, Func<TArg, ValueTask>, TArg)
    public static async Task<Result<Unit, TError>> Iter<TError, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, Task> action,
        TArg arg)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TError, TArg1, TArg2>(Task<Result<Unit, TError>>, Func<TArg1, TArg2, ValueTask>, TArg1, TArg2)
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterTaskResultExtensions.Iter<TError, TArg1, TArg2, TArg3>(Task<Result<Unit, TError>>, Func<TArg1, TArg2, TArg3, ValueTask>, TArg1, TArg2, TArg3)
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError>(
        this Task<Result<Unit, TError>> resultTask,
        Func<ValueTask> action)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, ValueTask> action,
        TArg arg)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }
}

/// <summary>Iter extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class IterValueTaskResultExtensions
{
    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TValue> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TValue, TError>(ValueTask<Result<TValue, TError>>, Func<TValue, Task>)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TValue, TArg> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value, arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TValue, TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value, arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TValue, TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(result.Value, arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TValue, TError, TArg>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg, Task>, TArg)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TValue, TError, TArg1, TArg2>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TValue, TError, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Action action)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action();
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TError>(ValueTask<Result<Unit, TError>>, Func<Task>)
    public static async ValueTask<Result<Unit, TError>> Iter<TError>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<ValueTask> action)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Action<TArg> action,
        TArg arg)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Action<TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Action<TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            action(arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TError, TArg>(ValueTask<Result<Unit, TError>>, Func<TArg, Task>, TArg)
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, ValueTask> action,
        TArg arg)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TError, TArg1, TArg2>(ValueTask<Result<Unit, TError>>, Func<TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterValueTaskResultExtensions.Iter<TError, TArg1, TArg2, TArg3>(ValueTask<Result<Unit, TError>>, Func<TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, Task> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> Iter<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(result.Value, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<Task> action)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, Task> action,
        TArg arg)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on success, or does nothing on failure, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<Unit, TError>> Iter<TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Success)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }
}
