using System.Runtime.CompilerServices;

namespace DistilledResult.FunctionalResultExtensions;

/// <summary>Match extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class MatchResultExtensions
{
    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static TOutput Match<TValue, TError, TOutput>(
        this Result<TValue, TError> result,
        Func<TValue, TOutput> onSuccess,
        Func<TError, TOutput> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static Task<TOutput> Match<TValue, TError, TOutput>(
        this Result<TValue, TError> result,
        Func<TValue, Task<TOutput>> onSuccess,
        Func<TError, Task<TOutput>> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchResultExtensions.Match<TValue, TError, TOutput>(Result<TValue, TError>, Func<TValue, Task<TOutput>>, Func<TError, Task<TOutput>>)
    public static ValueTask<TOutput> Match<TValue, TError, TOutput>(
        this Result<TValue, TError> result,
        Func<TValue, ValueTask<TOutput>> onSuccess,
        Func<TError, ValueTask<TOutput>> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static TOutput Match<TValue, TError, TOutput, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, TOutput> onSuccess,
        Func<TError, TArg, TOutput> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static TOutput Match<TValue, TError, TOutput, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TOutput> onSuccess,
        Func<TError, TArg1, TArg2, TOutput> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static TOutput Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, TOutput> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, TOutput> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static Task<TOutput> Match<TValue, TError, TOutput, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, Task<TOutput>> onSuccess,
        Func<TError, TArg, Task<TOutput>> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, Task<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, Task<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, Task<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, Task<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchResultExtensions.Match<TValue, TError, TOutput, TArg>(Result<TValue, TError>, Func<TValue, TArg, Task<TOutput>>, Func<TError, TArg, Task<TOutput>>, TArg)
    public static ValueTask<TOutput> Match<TValue, TError, TOutput, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg, ValueTask<TOutput>> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchResultExtensions.Match<TValue, TError, TOutput, TArg1, TArg2>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, Task<TOutput>>, Func<TError, TArg1, TArg2, Task<TOutput>>, TArg1, TArg2)
    public static ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, ValueTask<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchResultExtensions.Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, TArg3, Task<TOutput>>, Func<TError, TArg1, TArg2, TArg3, Task<TOutput>>, TArg1, TArg2, TArg3)
    public static ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        return result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);
    }
}

/// <summary>Match extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class MatchTaskResultExtensions
{
    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TOutput> onSuccess,
        Func<TError, TOutput> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchTaskResultExtensions.Match<TValue, TError, TOutput>(Task<Result<TValue, TError>>, Func<TValue, ValueTask<TOutput>>, Func<TError, ValueTask<TOutput>>)
    public static async Task<TOutput> Match<TValue, TError, TOutput>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, Task<TOutput>> onSuccess,
        Func<TError, Task<TOutput>> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, TOutput> onSuccess,
        Func<TError, TArg, TOutput> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TOutput> onSuccess,
        Func<TError, TArg1, TArg2, TOutput> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, TOutput> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, TOutput> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchTaskResultExtensions.Match<TValue, TError, TOutput, TArg>(Task<Result<TValue, TError>>, Func<TValue, TArg, ValueTask<TOutput>>, Func<TError, TArg, ValueTask<TOutput>>, TArg)
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task<TOutput>> onSuccess,
        Func<TError, TArg, Task<TOutput>> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchTaskResultExtensions.Match<TValue, TError, TOutput, TArg1, TArg2>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, ValueTask<TOutput>>, Func<TError, TArg1, TArg2, ValueTask<TOutput>>, TArg1, TArg2)
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, Task<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchTaskResultExtensions.Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, ValueTask<TOutput>>, Func<TError, TArg1, TArg2, TArg3, ValueTask<TOutput>>, TArg1, TArg2, TArg3)
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, Task<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask<TOutput>> onSuccess,
        Func<TError, ValueTask<TOutput>> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg, ValueTask<TOutput>> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, ValueTask<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async Task<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);

        return await task.ConfigureAwait(false);
    }
}

/// <summary>Match extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class MatchValueTaskResultExtensions
{
    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TOutput> onSuccess,
        Func<TError, TOutput> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchValueTaskResultExtensions.Match<TValue, TError, TOutput>(ValueTask<Result<TValue, TError>>, Func<TValue, Task<TOutput>>, Func<TError, Task<TOutput>>)
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask<TOutput>> onSuccess,
        Func<TError, ValueTask<TOutput>> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, TOutput> onSuccess,
        Func<TError, TArg, TOutput> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TOutput> onSuccess,
        Func<TError, TArg1, TArg2, TOutput> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, TOutput> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, TOutput> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        return result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchValueTaskResultExtensions.Match<TValue, TError, TOutput, TArg>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg, Task<TOutput>>, Func<TError, TArg, Task<TOutput>>, TArg)
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg, ValueTask<TOutput>> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchValueTaskResultExtensions.Match<TValue, TError, TOutput, TArg1, TArg2>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, Task<TOutput>>, Func<TError, TArg1, TArg2, Task<TOutput>>, TArg1, TArg2)
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, ValueTask<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    [OverloadResolutionPriority(1)]
    // MatchValueTaskResultExtensions.Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, Task<TOutput>>, Func<TError, TArg1, TArg2, TArg3, Task<TOutput>>, TArg1, TArg2, TArg3)
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, ValueTask<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, Task<TOutput>> onSuccess,
        Func<TError, Task<TOutput>> onFailure)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value)
            : onFailure(result.Error);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task<TOutput>> onSuccess,
        Func<TError, TArg, Task<TOutput>> onFailure,
        TArg arg)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg)
            : onFailure(result.Error, arg);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, Task<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2)
            : onFailure(result.Error, arg1, arg2);

        return await task.ConfigureAwait(false);
    }

    /// <summary>Applies <paramref name="onSuccess"/> to the success value or <paramref name="onFailure"/> to the error, returns the value it produces.</summary>
    public static async ValueTask<TOutput> Match<TValue, TError, TOutput, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task<TOutput>> onSuccess,
        Func<TError, TArg1, TArg2, TArg3, Task<TOutput>> onFailure,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
    {
        var result = await resultTask.ConfigureAwait(false);

        var task = result.Success
            ? onSuccess(result.Value, arg1, arg2, arg3)
            : onFailure(result.Error, arg1, arg2, arg3);

        return await task.ConfigureAwait(false);
    }
}
