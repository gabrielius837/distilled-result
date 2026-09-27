using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class BindResultExtensionTests
{
    // ---- Result<TValue, TError>, sync binder ----

    [Test]
    public async Task Bind_Sync_ChainsSuccess()
    {
        var result = Result.Ok<int, string>(5).Bind(x => Result.Ok<int, string>(x * 2));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_Sync_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Bind(x =>
        {
            called = true;
            return Result.Ok<int, string>(x * 2);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    [Test]
    public async Task Bind_Sync_ChainsSuccessIntoFailure()
    {
        var result = Result.Ok<int, string>(5).Bind(_ => Result.Fail<int, string>("failed downstream"));

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("failed downstream"));
    }

    // ---- Result<TValue, TError>, Task binder ----

    [Test]
    public async Task Bind_Task_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind(BindSelectors.DoubleTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_Task_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(x =>
        {
            called = true;
            return BindSelectors.DoubleTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask binder ----

    [Test]
    public async Task Bind_ValueTask_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind(BindSelectors.DoubleValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_ValueTask_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(x =>
        {
            called = true;
            return BindSelectors.DoubleValueTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    [Test]
    public async Task Bind_Task_ThrowsSynchronouslyWhenBinderThrows()
    {
        Func<int, Task<Result<int, string>>> binder = _ => throw new InvalidOperationException("boom");

        var exception = Assert.Throws<InvalidOperationException>(() => Result.Ok<int, string>(5).Bind(binder));

        await Assert.That(exception.Message).IsEqualTo("boom");
    }

    [Test]
    public async Task Bind_ValueTask_ThrowsSynchronouslyWhenBinderThrows()
    {
        Func<int, ValueTask<Result<int, string>>> binder = _ => throw new InvalidOperationException("boom");

        var exception = Assert.Throws<InvalidOperationException>(() => Result.Ok<int, string>(5).Bind(binder));

        await Assert.That(exception.Message).IsEqualTo("boom");
    }

    // ---- Result<TValue, TError>, sync binder, 1 arg ----

    [Test]
    public async Task Bind_SyncWithArg_ChainsSuccess()
    {
        var result = Result.Ok<int, string>(5).Bind((x, arg) => Result.Ok<int, string>(x + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Bind_SyncWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Bind(
            (x, arg) =>
            {
                called = true;
                return Result.Ok<int, string>(x + arg);
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task binder, 1 arg ----

    [Test]
    public async Task Bind_TaskWithArg_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind(BindSelectors.AddTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Bind_TaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(
            (x, arg) =>
            {
                called = true;
                return BindSelectors.AddTaskAsync(x, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask binder, 1 arg ----

    [Test]
    public async Task Bind_ValueTaskWithArg_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind(BindSelectors.AddValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Bind_ValueTaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(
            (x, arg) =>
            {
                called = true;
                return BindSelectors.AddValueTaskAsync(x, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync binder ----

    [Test]
    public async Task Bind_UnitSync_InvokesBinderOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Bind(() => Result.Ok<int, string>(42));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_UnitSync_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Bind(() =>
        {
            called = true;
            return Result.Ok<int, string>(42);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task binder ----

    [Test]
    public async Task Bind_UnitTask_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(BindSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_UnitTask_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(() =>
        {
            called = true;
            return BindSelectors.FortyTwoTaskAsync();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask binder ----

    [Test]
    public async Task Bind_UnitValueTask_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(BindSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_UnitValueTask_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(() =>
        {
            called = true;
            return BindSelectors.FortyTwoValueTaskAsync();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync binder, 1 arg ----

    [Test]
    public async Task Bind_UnitSyncWithArg_InvokesBinderOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Bind(arg => Result.Ok<int, string>(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_UnitSyncWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Bind(
            arg =>
            {
                called = true;
                return Result.Ok<int, string>(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task binder, 1 arg ----

    [Test]
    public async Task Bind_UnitTaskWithArg_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(BindSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_UnitTaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(
            arg =>
            {
                called = true;
                return BindSelectors.ArgTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask binder, 1 arg ----

    [Test]
    public async Task Bind_UnitValueTaskWithArg_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(BindSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_UnitValueTaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(
            arg =>
            {
                called = true;
                return BindSelectors.ArgValueTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync binder, 2 args ----

    [Test]
    public async Task Bind_SyncWithTwoArgs_ChainsSuccess()
    {
        var result = Result.Ok<int, string>(5).Bind((x, arg1, arg2) => Result.Ok<int, string>(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Bind_SyncWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Bind(
            (x, arg1, arg2) =>
            {
                called = true;
                return Result.Ok<int, string>(x + arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task binder, 2 args ----

    [Test]
    public async Task Bind_TaskWithTwoArgs_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind((x, arg1, arg2) => Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Bind_TaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(
            (x, arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2));
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask binder, 2 args ----

    [Test]
    public async Task Bind_ValueTaskWithTwoArgs_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind((x, arg1, arg2) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(x + arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Bind_ValueTaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(
            (x, arg1, arg2) =>
            {
                called = true;
                return new ValueTask<Result<int, string>>(Result.Ok<int, string>(x + arg1 + arg2));
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync binder, 3 args ----

    [Test]
    public async Task Bind_SyncWithThreeArgs_ChainsSuccess()
    {
        var result = Result.Ok<int, string>(5).Bind((x, arg1, arg2, arg3) => Result.Ok<int, string>(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Bind_SyncWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Bind(
            (x, arg1, arg2, arg3) =>
            {
                called = true;
                return Result.Ok<int, string>(x + arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task binder, 3 args ----

    [Test]
    public async Task Bind_TaskWithThreeArgs_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind((x, arg1, arg2, arg3) => Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Bind_TaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(
            (x, arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2 + arg3));
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask binder, 3 args ----

    [Test]
    public async Task Bind_ValueTaskWithThreeArgs_ChainsSuccess()
    {
        var result = await Result.Ok<int, string>(5).Bind((x, arg1, arg2, arg3) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(x + arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Bind_ValueTaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Bind(
            (x, arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<Result<int, string>>(Result.Ok<int, string>(x + arg1 + arg2 + arg3));
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync binder, 2 args ----

    [Test]
    public async Task Bind_UnitSyncWithTwoArgs_InvokesBinderOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Bind((arg1, arg2) => Result.Ok<int, string>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Bind_UnitSyncWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Bind(
            (arg1, arg2) =>
            {
                called = true;
                return Result.Ok<int, string>(arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task binder, 2 args ----

    [Test]
    public async Task Bind_UnitTaskWithTwoArgs_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind((arg1, arg2) => Task.FromResult(Result.Ok<int, string>(arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Bind_UnitTaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(
            (arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(Result.Ok<int, string>(arg1 + arg2));
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask binder, 2 args ----

    [Test]
    public async Task Bind_UnitValueTaskWithTwoArgs_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind((arg1, arg2) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Bind_UnitValueTaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(
            (arg1, arg2) =>
            {
                called = true;
                return new ValueTask<Result<int, string>>(Result.Ok<int, string>(arg1 + arg2));
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync binder, 3 args ----

    [Test]
    public async Task Bind_UnitSyncWithThreeArgs_InvokesBinderOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Bind((arg1, arg2, arg3) => Result.Ok<int, string>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Bind_UnitSyncWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Bind(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return Result.Ok<int, string>(arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task binder, 3 args ----

    [Test]
    public async Task Bind_UnitTaskWithThreeArgs_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind((arg1, arg2, arg3) => Task.FromResult(Result.Ok<int, string>(arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Bind_UnitTaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(Result.Ok<int, string>(arg1 + arg2 + arg3));
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask binder, 3 args ----

    [Test]
    public async Task Bind_UnitValueTaskWithThreeArgs_InvokesBinderOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind((arg1, arg2, arg3) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Bind_UnitValueTaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Bind(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<Result<int, string>>(Result.Ok<int, string>(arg1 + arg2 + arg3));
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }
}

public class BindTaskResultExtensionTests
{
    // ---- Task source, sync binder ----

    [Test]
    public async Task Bind_TaskSource_Sync_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(x => Result.Ok<int, string>(x * 2));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_TaskSource_Sync_PassesThroughFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.Bind(x =>
        {
            called = true;
            return Result.Ok<int, string>(x * 2);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, Task binder ----

    [Test]
    public async Task Bind_TaskSource_Task_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(BindSelectors.DoubleTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_TaskSource_Task_PassesThroughFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.Bind(x =>
        {
            called = true;
            return BindSelectors.DoubleTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, sync binder, 1 arg ----

    [Test]
    public async Task Bind_TaskSource_SyncWithArg_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg) => Result.Ok<int, string>(x + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    // ---- Task source, Task binder, 1 arg ----

    [Test]
    public async Task Bind_TaskSource_TaskWithArg_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(BindSelectors.AddTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    // ---- Task source, sync binder, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitSync_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(() => Result.Ok<int, string>(42));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- Task source, Task binder, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitTask_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(BindSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- Task source, sync binder, 1 arg, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitSyncWithArg_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(arg => Result.Ok<int, string>(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- Task source, Task binder, 1 arg, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitTaskWithArg_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(BindSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- Task source, sync binder, 2 args ----

    [Test]
    public async Task Bind_TaskSource_SyncWithTwoArgs_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2) => Result.Ok<int, string>(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- Task source, Task binder, 2 args ----

    [Test]
    public async Task Bind_TaskSource_TaskWithTwoArgs_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2) => Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- Task source, sync binder, 3 args ----

    [Test]
    public async Task Bind_TaskSource_SyncWithThreeArgs_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2, arg3) => Result.Ok<int, string>(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- Task source, Task binder, 3 args ----

    [Test]
    public async Task Bind_TaskSource_TaskWithThreeArgs_ChainsSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2, arg3) => Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- Task source, sync binder, 2 args, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitSyncWithTwoArgs_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2) => Result.Ok<int, string>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- Task source, Task binder, 2 args, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitTaskWithTwoArgs_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2) => Task.FromResult(Result.Ok<int, string>(arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- Task source, sync binder, 3 args, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitSyncWithThreeArgs_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2, arg3) => Result.Ok<int, string>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    // ---- Task source, Task binder, 3 args, Unit ----

    [Test]
    public async Task Bind_TaskSource_UnitTaskWithThreeArgs_InvokesBinderOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2, arg3) => Task.FromResult(Result.Ok<int, string>(arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }
}

public class BindValueTaskResultExtensionTests
{
    // ---- ValueTask source, sync binder ----

    [Test]
    public async Task Bind_ValueTaskSource_Sync_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(x => Result.Ok<int, string>(x * 2));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_ValueTaskSource_Sync_PassesThroughFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.Bind(x =>
        {
            called = true;
            return Result.Ok<int, string>(x * 2);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, ValueTask binder ----

    [Test]
    public async Task Bind_ValueTaskSource_ValueTask_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(BindSelectors.DoubleValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_ValueTaskSource_ValueTask_PassesThroughFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.Bind(x =>
        {
            called = true;
            return BindSelectors.DoubleValueTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, sync binder, 1 arg ----

    [Test]
    public async Task Bind_ValueTaskSource_SyncWithArg_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg) => Result.Ok<int, string>(x + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    // ---- ValueTask source, ValueTask binder, 1 arg ----

    [Test]
    public async Task Bind_ValueTaskSource_ValueTaskWithArg_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(BindSelectors.AddValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    // ---- ValueTask source, sync binder, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitSync_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(() => Result.Ok<int, string>(42));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- ValueTask source, ValueTask binder, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitValueTask_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(BindSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- ValueTask source, sync binder, 1 arg, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitSyncWithArg_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(arg => Result.Ok<int, string>(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- ValueTask source, ValueTask binder, 1 arg, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitValueTaskWithArg_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(BindSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- ValueTask source, sync binder, 2 args ----

    [Test]
    public async Task Bind_ValueTaskSource_SyncWithTwoArgs_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2) => Result.Ok<int, string>(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- ValueTask source, ValueTask binder, 2 args ----

    [Test]
    public async Task Bind_ValueTaskSource_ValueTaskWithTwoArgs_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(x + arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- ValueTask source, sync binder, 3 args ----

    [Test]
    public async Task Bind_ValueTaskSource_SyncWithThreeArgs_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2, arg3) => Result.Ok<int, string>(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- ValueTask source, ValueTask binder, 3 args ----

    [Test]
    public async Task Bind_ValueTaskSource_ValueTaskWithThreeArgs_ChainsSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind((x, arg1, arg2, arg3) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(x + arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- ValueTask source, sync binder, 2 args, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitSyncWithTwoArgs_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2) => Result.Ok<int, string>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- ValueTask source, ValueTask binder, 2 args, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitValueTaskWithTwoArgs_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- ValueTask source, sync binder, 3 args, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitSyncWithThreeArgs_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2, arg3) => Result.Ok<int, string>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    // ---- ValueTask source, ValueTask binder, 3 args, Unit ----

    [Test]
    public async Task Bind_ValueTaskSource_UnitValueTaskWithThreeArgs_InvokesBinderOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind((arg1, arg2, arg3) => new ValueTask<Result<int, string>>(Result.Ok<int, string>(arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }
}

public class BindOverloadResolutionTests
{
    [Test]
    public async Task Bind_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Bind(async x => await Task.FromResult(Result.Ok<int, string>(x * 2)));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Bind(async (x, arg) => await Task.FromResult(Result.Ok<int, string>(x + arg)), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Bind_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(async () => await Task.FromResult(Result.Ok<int, string>(42)));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(async arg => await Task.FromResult(Result.Ok<int, string>(arg)), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_TaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<int, string>(5)).Bind(async x => await Task.FromResult(Result.Ok<int, string>(x * 2)));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_TaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<int, string>(5)).Bind(async (x, arg) => await Task.FromResult(Result.Ok<int, string>(x + arg)), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Bind_TaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<Unit, string>(Unit.Value)).Bind(async () => await Task.FromResult(Result.Ok<int, string>(42)));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_TaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<Unit, string>(Unit.Value)).Bind(async arg => await Task.FromResult(Result.Ok<int, string>(arg)), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_ValueTaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Bind(async x => await Task.FromResult(Result.Ok<int, string>(x * 2)));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Bind_ValueTaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Bind(async (x, arg) => await Task.FromResult(Result.Ok<int, string>(x + arg)), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Bind_ValueTaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<Unit, string>>(Result.Ok<Unit, string>(Unit.Value)).Bind(async () => await Task.FromResult(Result.Ok<int, string>(42)));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Bind_ValueTaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<Unit, string>>(Result.Ok<Unit, string>(Unit.Value)).Bind(async arg => await Task.FromResult(Result.Ok<int, string>(arg)), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- A bare `async` lambda resolves to the ValueTask overload (2 and 3 extra arguments) ----

    [Test]
    public async Task Bind_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Bind(async (x, arg1, arg2) => await Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Bind_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Bind(async (x, arg1, arg2, arg3) => await Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Bind_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(async (arg1, arg2) => await Task.FromResult(Result.Ok<int, string>(arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Bind_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Bind(async (arg1, arg2, arg3) => await Task.FromResult(Result.Ok<int, string>(arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Bind_TaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(async (x, arg1, arg2) => await Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Bind_TaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(async (x, arg1, arg2, arg3) => await Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Bind_TaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(async (arg1, arg2) => await Task.FromResult(Result.Ok<int, string>(arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Bind_TaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(async (arg1, arg2, arg3) => await Task.FromResult(Result.Ok<int, string>(arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Bind_ValueTaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(async (x, arg1, arg2) => await Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Bind_ValueTaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Bind(async (x, arg1, arg2, arg3) => await Task.FromResult(Result.Ok<int, string>(x + arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Bind_ValueTaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(async (arg1, arg2) => await Task.FromResult(Result.Ok<int, string>(arg1 + arg2)), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Bind_ValueTaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Bind(async (arg1, arg2, arg3) => await Task.FromResult(Result.Ok<int, string>(arg1 + arg2 + arg3)), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }
}

internal static class BindSelectors
{
    public static Task<Result<int, string>> DoubleTaskAsync(int value) => Task.FromResult(Result.Ok<int, string>(value * 2));

    public static ValueTask<Result<int, string>> DoubleValueTaskAsync(int value) => new(Result.Ok<int, string>(value * 2));

    public static Task<Result<int, string>> AddTaskAsync(int value, int arg) => Task.FromResult(Result.Ok<int, string>(value + arg));

    public static ValueTask<Result<int, string>> AddValueTaskAsync(int value, int arg) => new(Result.Ok<int, string>(value + arg));

    public static Task<Result<int, string>> FortyTwoTaskAsync() => Task.FromResult(Result.Ok<int, string>(42));

    public static ValueTask<Result<int, string>> FortyTwoValueTaskAsync() => new(Result.Ok<int, string>(42));

    public static Task<Result<int, string>> ArgTaskAsync(int arg) => Task.FromResult(Result.Ok<int, string>(arg));

    public static ValueTask<Result<int, string>> ArgValueTaskAsync(int arg) => new(Result.Ok<int, string>(arg));
}
