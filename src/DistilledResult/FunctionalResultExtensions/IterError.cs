using System.Runtime.CompilerServices;

namespace DistilledResult.FunctionalResultExtensions;

/// <summary>IterError extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class IterErrorResultExtensions
{
    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> IterError<TValue, TError>(
        this Result<TValue, TError> result,
        Action<TError> action)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            action(result.Error);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TError, Task> action)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue, TError>(Result<TValue, TError>, Func<TError, Task>)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TError, ValueTask> action)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> IterError<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Action<TError, TArg> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            action(result.Error, arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> IterError<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Action<TError, TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            action(result.Error, arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, TError> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Action<TError, TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            action(result.Error, arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, Task> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue, TError, TArg>(Result<TValue, TError>, Func<TError, TArg, Task>, TArg)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this Result<TValue, TError> result,
        Func<TError, TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue, TError, TArg1, TArg2>(Result<TValue, TError>, Func<TError, TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue, TError, TArg1, TArg2, TArg3>(Result<TValue, TError>, Func<TError, TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TError, TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        if (result.Failure)
        {
            await action(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, Unit> IterError<TValue>(
        this Result<TValue, Unit> result,
        Action action)
        where TValue : notnull
    {
        if (result.Failure)
        {
            action();
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue>(
        this Result<TValue, Unit> result,
        Func<Task> action)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue>(Result<TValue, Unit>, Func<Task>)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue>(
        this Result<TValue, Unit> result,
        Func<ValueTask> action)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, Unit> IterError<TValue, TArg>(
        this Result<TValue, Unit> result,
        Action<TArg> action,
        TArg arg)
        where TValue : notnull
    {
        if (result.Failure)
        {
            action(arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, Unit> IterError<TValue, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Action<TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        if (result.Failure)
        {
            action(arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static Result<TValue, Unit> IterError<TValue, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Action<TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        if (result.Failure)
        {
            action(arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, Task> action,
        TArg arg)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue, TArg>(Result<TValue, Unit>, Func<TArg, Task>, TArg)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg>(
        this Result<TValue, Unit> result,
        Func<TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue, TArg1, TArg2>(Result<TValue, Unit>, Func<TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorResultExtensions.IterError<TValue, TArg1, TArg2, TArg3>(Result<TValue, Unit>, Func<TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this Result<TValue, Unit> result,
        Func<TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        if (result.Failure)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }
}

/// <summary>IterError extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class IterErrorTaskResultExtensions
{
    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TError> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue, TError>(Task<Result<TValue, TError>>, Func<TError, ValueTask>)
    public static async Task<Result<TValue, TError>> IterError<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, Task> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TError, TArg> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error, arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TError, TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error, arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Action<TError, TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error, arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue, TError, TArg>(Task<Result<TValue, TError>>, Func<TError, TArg, ValueTask>, TArg)
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, Task> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue, TError, TArg1, TArg2>(Task<Result<TValue, TError>>, Func<TError, TArg1, TArg2, ValueTask>, TArg1, TArg2)
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue, TError, TArg1, TArg2, TArg3>(Task<Result<TValue, TError>>, Func<TError, TArg1, TArg2, TArg3, ValueTask>, TArg1, TArg2, TArg3)
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue>(
        this Task<Result<TValue, Unit>> resultTask,
        Action action)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action();
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue>(Task<Result<TValue, Unit>>, Func<ValueTask>)
    public static async Task<Result<TValue, Unit>> IterError<TValue>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<Task> action)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Action<TArg> action,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Action<TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Action<TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue, TArg>(Task<Result<TValue, Unit>>, Func<TArg, ValueTask>, TArg)
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, Task> action,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue, TArg1, TArg2>(Task<Result<TValue, Unit>>, Func<TArg1, TArg2, ValueTask>, TArg1, TArg2)
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorTaskResultExtensions.IterError<TValue, TArg1, TArg2, TArg3>(Task<Result<TValue, Unit>>, Func<TArg1, TArg2, TArg3, ValueTask>, TArg1, TArg2, TArg3)
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, ValueTask> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<ValueTask> action)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async Task<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }
}

/// <summary>IterError extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class IterErrorValueTaskResultExtensions
{
    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TError> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue, TError>(ValueTask<Result<TValue, TError>>, Func<TError, Task>)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, ValueTask> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TError, TArg> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error, arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TError, TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error, arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Action<TError, TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(result.Error, arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue, TError, TArg>(ValueTask<Result<TValue, TError>>, Func<TError, TArg, Task>, TArg)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue, TError, TArg1, TArg2>(ValueTask<Result<TValue, TError>>, Func<TError, TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue, TError, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, TError>>, Func<TError, TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Action action)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action();
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue>(ValueTask<Result<TValue, Unit>>, Func<Task>)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<ValueTask> action)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Action<TArg> action,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(arg);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Action<TArg1, TArg2> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(arg1, arg2);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Action<TArg1, TArg2, TArg3> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            action(arg1, arg2, arg3);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue, TArg>(ValueTask<Result<TValue, Unit>>, Func<TArg, Task>, TArg)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, ValueTask> action,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue, TArg1, TArg2>(ValueTask<Result<TValue, Unit>>, Func<TArg1, TArg2, Task>, TArg1, TArg2)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    [OverloadResolutionPriority(1)]
    // IterErrorValueTaskResultExtensions.IterError<TValue, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, Unit>>, Func<TArg1, TArg2, TArg3, Task>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, Task> action)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg, Task> action,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, TError>> IterError<TValue, TError, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TError, TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(result.Error, arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<Task> action)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg, Task> action,
        TArg arg)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, Task> action,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>Applies the side effect <paramref name="action"/> on failure, or does nothing on success, then returns the original <see cref="Result{TValue, TError}"/>.</summary>
    public static async ValueTask<Result<TValue, Unit>> IterError<TValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, Unit>> resultTask,
        Func<TArg1, TArg2, TArg3, Task> action,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        if (result.Failure)
        {
            await action(arg1, arg2, arg3).ConfigureAwait(false);
        }

        return result;
    }
}
