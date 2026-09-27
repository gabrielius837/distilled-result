using System.Runtime.CompilerServices;

namespace DistilledResult.FunctionalResultExtensions;

/// <summary>Bind extension methods for a <see cref="Result{TValue, TError}"/>.</summary>
public static class BindResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Bind<TValue, TError, TNewValue>(
        this Result<TValue, TError> result,
        Func<TValue, Result<TNewValue, TError>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this Result<TValue, TError> result,
        Func<TValue, Task<Result<TNewValue, TError>>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value)
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TValue, TError, TNewValue>(Result<TValue, TError>, Func<TValue, Task<Result<TNewValue, TError>>>)
    public static ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this Result<TValue, TError> result,
        Func<TValue, ValueTask<Result<TNewValue, TError>>> func)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value)
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Bind<TValue, TError, TNewValue, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, Result<TNewValue, TError>> func,
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
    public static Result<TNewValue, TError> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, Result<TNewValue, TError>> func,
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
    public static Result<TNewValue, TError> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, Result<TNewValue, TError>> func,
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
    public static Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, Task<Result<TNewValue, TError>>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg)
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, Task<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg1, arg2)
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg1, arg2, arg3)
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TValue, TError, TNewValue, TArg>(Result<TValue, TError>, Func<TValue, TArg, Task<Result<TNewValue, TError>>>, TArg)
    public static ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this Result<TValue, TError> result,
        Func<TValue, TArg, ValueTask<Result<TNewValue, TError>>> func,
        TArg arg)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg)
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TValue, TError, TNewValue, TArg1, TArg2>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, Task<Result<TNewValue, TError>>>, TArg1, TArg2)
    public static ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, ValueTask<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg1, arg2)
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(Result<TValue, TError>, Func<TValue, TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>>, TArg1, TArg2, TArg3)
    public static ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<TValue, TError> result,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TValue : notnull
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(result.Value, arg1, arg2, arg3)
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Bind<TError, TNewValue>(
        this Result<Unit, TError> result,
        Func<Result<TNewValue, TError>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func()
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Task<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this Result<Unit, TError> result,
        Func<Task<Result<TNewValue, TError>>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func()
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TError, TNewValue>(Result<Unit, TError>, Func<Task<Result<TNewValue, TError>>>)
    public static ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this Result<Unit, TError> result,
        Func<ValueTask<Result<TNewValue, TError>>> func)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func()
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Bind<TError, TNewValue, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, Result<TNewValue, TError>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Bind<TError, TNewValue, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, Result<TNewValue, TError>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg1, arg2)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Result<TNewValue, TError> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, Result<TNewValue, TError>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg1, arg2, arg3)
            : result.Error;
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, Task<Result<TNewValue, TError>>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg)
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, Task<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg1, arg2)
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg1, arg2, arg3)
            : Task.FromResult<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TError, TNewValue, TArg>(Result<Unit, TError>, Func<TArg, Task<Result<TNewValue, TError>>>, TArg)
    public static ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this Result<Unit, TError> result,
        Func<TArg, ValueTask<Result<TNewValue, TError>>> func,
        TArg arg)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg)
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TError, TNewValue, TArg1, TArg2>(Result<Unit, TError>, Func<TArg1, TArg2, Task<Result<TNewValue, TError>>>, TArg1, TArg2)
    public static ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, ValueTask<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg1, arg2)
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }

    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    [OverloadResolutionPriority(1)]
    // BindResultExtensions.Bind<TError, TNewValue, TArg1, TArg2, TArg3>(Result<Unit, TError>, Func<TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>>, TArg1, TArg2, TArg3)
    public static ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Result<Unit, TError> result,
        Func<TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>> func,
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
        where TError : notnull
        where TNewValue : notnull
    {
        return result.Success
            ? func(arg1, arg2, arg3)
            : new ValueTask<Result<TNewValue, TError>>(result.Error);
    }
}

/// <summary>Bind extension methods for a <see cref="Task"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class BindTaskResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, Result<TNewValue, TError>> func)
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
    // BindTaskResultExtensions.Bind<TValue, TError, TNewValue>(Task<Result<TValue, TError>>, Func<TValue, ValueTask<Result<TNewValue, TError>>>)
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, Task<Result<TNewValue, TError>>> func)
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
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Result<TNewValue, TError>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Result<TNewValue, TError>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Result<TNewValue, TError>> func,
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
    // BindTaskResultExtensions.Bind<TValue, TError, TNewValue, TArg>(Task<Result<TValue, TError>>, Func<TValue, TArg, ValueTask<Result<TNewValue, TError>>>, TArg)
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task<Result<TNewValue, TError>>> func,
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
    // BindTaskResultExtensions.Bind<TValue, TError, TNewValue, TArg1, TArg2>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, ValueTask<Result<TNewValue, TError>>>, TArg1, TArg2)
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task<Result<TNewValue, TError>>> func,
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
    // BindTaskResultExtensions.Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(Task<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>>, TArg1, TArg2, TArg3)
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this Task<Result<Unit, TError>> resultTask,
        Func<Result<TNewValue, TError>> func)
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
    // BindTaskResultExtensions.Bind<TError, TNewValue>(Task<Result<Unit, TError>>, Func<ValueTask<Result<TNewValue, TError>>>)
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this Task<Result<Unit, TError>> resultTask,
        Func<Task<Result<TNewValue, TError>>> func)
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, Result<TNewValue, TError>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Result<TNewValue, TError>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Result<TNewValue, TError>> func,
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
    // BindTaskResultExtensions.Bind<TError, TNewValue, TArg>(Task<Result<Unit, TError>>, Func<TArg, ValueTask<Result<TNewValue, TError>>>, TArg)
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, Task<Result<TNewValue, TError>>> func,
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
    // BindTaskResultExtensions.Bind<TError, TNewValue, TArg1, TArg2>(Task<Result<Unit, TError>>, Func<TArg1, TArg2, ValueTask<Result<TNewValue, TError>>>, TArg1, TArg2)
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Task<Result<TNewValue, TError>>> func,
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
    // BindTaskResultExtensions.Bind<TError, TNewValue, TArg1, TArg2, TArg3>(Task<Result<Unit, TError>>, Func<TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>>, TArg1, TArg2, TArg3)
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask<Result<TNewValue, TError>>> func)
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
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask<Result<TNewValue, TError>>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask<Result<TNewValue, TError>>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this Task<Result<Unit, TError>> resultTask,
        Func<ValueTask<Result<TNewValue, TError>>> func)
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg, ValueTask<Result<TNewValue, TError>>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, ValueTask<Result<TNewValue, TError>>> func,
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
    public static async Task<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this Task<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>> func,
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

/// <summary>Bind extension methods for a <see cref="ValueTask"/> of a <see cref="Result{TValue, TError}"/>.</summary>
public static class BindValueTaskResultExtensions
{
    /// <summary>Applies <paramref name="func"/> to the success value and returns its result, otherwise returns the error.</summary>
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, Result<TNewValue, TError>> func)
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
    // BindValueTaskResultExtensions.Bind<TValue, TError, TNewValue>(ValueTask<Result<TValue, TError>>, Func<TValue, Task<Result<TNewValue, TError>>>)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, ValueTask<Result<TNewValue, TError>>> func)
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Result<TNewValue, TError>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Result<TNewValue, TError>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Result<TNewValue, TError>> func,
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
    // BindValueTaskResultExtensions.Bind<TValue, TError, TNewValue, TArg>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg, Task<Result<TNewValue, TError>>>, TArg)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, ValueTask<Result<TNewValue, TError>>> func,
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
    // BindValueTaskResultExtensions.Bind<TValue, TError, TNewValue, TArg1, TArg2>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, Task<Result<TNewValue, TError>>>, TArg1, TArg2)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, ValueTask<Result<TNewValue, TError>>> func,
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
    // BindValueTaskResultExtensions.Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(ValueTask<Result<TValue, TError>>, Func<TValue, TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<Result<TNewValue, TError>> func)
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
    // BindValueTaskResultExtensions.Bind<TError, TNewValue>(ValueTask<Result<Unit, TError>>, Func<Task<Result<TNewValue, TError>>>)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<ValueTask<Result<TNewValue, TError>>> func)
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, Result<TNewValue, TError>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Result<TNewValue, TError>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Result<TNewValue, TError>> func,
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
    // BindValueTaskResultExtensions.Bind<TError, TNewValue, TArg>(ValueTask<Result<Unit, TError>>, Func<TArg, Task<Result<TNewValue, TError>>>, TArg)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, ValueTask<Result<TNewValue, TError>>> func,
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
    // BindValueTaskResultExtensions.Bind<TError, TNewValue, TArg1, TArg2>(ValueTask<Result<Unit, TError>>, Func<TArg1, TArg2, Task<Result<TNewValue, TError>>>, TArg1, TArg2)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, ValueTask<Result<TNewValue, TError>>> func,
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
    // BindValueTaskResultExtensions.Bind<TError, TNewValue, TArg1, TArg2, TArg3>(ValueTask<Result<Unit, TError>>, Func<TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>>, TArg1, TArg2, TArg3)
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, ValueTask<Result<TNewValue, TError>>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, Task<Result<TNewValue, TError>>> func)
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg, Task<Result<TNewValue, TError>>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, Task<Result<TNewValue, TError>>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TValue, TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<TValue, TError>> resultTask,
        Func<TValue, TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<Task<Result<TNewValue, TError>>> func)
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg, Task<Result<TNewValue, TError>>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, Task<Result<TNewValue, TError>>> func,
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
    public static async ValueTask<Result<TNewValue, TError>> Bind<TError, TNewValue, TArg1, TArg2, TArg3>(
        this ValueTask<Result<Unit, TError>> resultTask,
        Func<TArg1, TArg2, TArg3, Task<Result<TNewValue, TError>>> func,
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
