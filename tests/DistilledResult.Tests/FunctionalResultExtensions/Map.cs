using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class MapResultExtensionTests
{
    // ---- Result<TValue, TError>, sync selector ----

    [Test]
    public async Task Map_Sync_TransformsSuccessValue()
    {
        var result = Result.Ok<int, string>(5).Map(x => x * 2);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_Sync_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Map(x =>
        {
            called = true;
            return x * 2;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector ----
    // Uses a named method (MapSelectors.DoubleTaskAsync), not a bare `async` lambda - see the class remarks
    // on why an untyped lambda would be ambiguous here.

    [Test]
    public async Task Map_Task_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map(MapSelectors.DoubleTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_Task_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(x =>
        {
            called = true;
            return MapSelectors.DoubleTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector ----

    [Test]
    public async Task Map_ValueTask_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map(MapSelectors.DoubleValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_ValueTask_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(x =>
        {
            called = true;
            return MapSelectors.DoubleValueTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync selector, 1 arg ----

    [Test]
    public async Task Map_SyncWithArg_TransformsSuccessValue()
    {
        var result = Result.Ok<int, string>(5).Map(static (x, arg) => x + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_SyncWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Map(
            (x, arg) =>
            {
                called = true;
                return x + arg;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector, 1 arg ----

    [Test]
    public async Task Map_TaskWithArg_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map(MapSelectors.AddTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_TaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(
            (x, arg) =>
            {
                called = true;
                return MapSelectors.AddTaskAsync(x, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector, 1 arg ----

    [Test]
    public async Task Map_ValueTaskWithArg_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map(MapSelectors.AddValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_ValueTaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(
            (x, arg) =>
            {
                called = true;
                return MapSelectors.AddValueTaskAsync(x, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync selector ----

    [Test]
    public async Task Map_UnitSync_InvokesSelectorOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Map(() => 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_UnitSync_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Map(() =>
        {
            called = true;
            return 42;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task selector ----

    [Test]
    public async Task Map_UnitTask_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(MapSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_UnitTask_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(() =>
        {
            called = true;
            return MapSelectors.FortyTwoTaskAsync();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask selector ----

    [Test]
    public async Task Map_UnitValueTask_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(MapSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_UnitValueTask_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(() =>
        {
            called = true;
            return MapSelectors.FortyTwoValueTaskAsync();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync selector, 1 arg ----

    [Test]
    public async Task Map_UnitSyncWithArg_InvokesSelectorOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Map(static arg => arg, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_UnitSyncWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Map(
            arg =>
            {
                called = true;
                return arg;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task selector, 1 arg ----

    [Test]
    public async Task Map_UnitTaskWithArg_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(MapSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_UnitTaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(
            arg =>
            {
                called = true;
                return MapSelectors.ArgTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask selector, 1 arg ----

    [Test]
    public async Task Map_UnitValueTaskWithArg_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(MapSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_UnitValueTaskWithArg_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(
            arg =>
            {
                called = true;
                return MapSelectors.ArgValueTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync selector, 2 args ----

    [Test]
    public async Task Map_SyncWithTwoArgs_TransformsSuccessValue()
    {
        var result = Result.Ok<int, string>(5).Map((x, arg1, arg2) => x + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Map_SyncWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Map(
            (x, arg1, arg2) =>
            {
                called = true;
                return x + arg1 + arg2;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector, 2 args ----

    [Test]
    public async Task Map_TaskWithTwoArgs_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map((x, arg1, arg2) => Task.FromResult(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Map_TaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(
            (x, arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(x + arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector, 2 args ----

    [Test]
    public async Task Map_ValueTaskWithTwoArgs_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map((x, arg1, arg2) => new ValueTask<int>(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Map_ValueTaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(
            (x, arg1, arg2) =>
            {
                called = true;
                return new ValueTask<int>(x + arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync selector, 3 args ----

    [Test]
    public async Task Map_SyncWithThreeArgs_TransformsSuccessValue()
    {
        var result = Result.Ok<int, string>(5).Map((x, arg1, arg2, arg3) => x + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Map_SyncWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("error").Map(
            (x, arg1, arg2, arg3) =>
            {
                called = true;
                return x + arg1 + arg2 + arg3;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector, 3 args ----

    [Test]
    public async Task Map_TaskWithThreeArgs_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map((x, arg1, arg2, arg3) => Task.FromResult(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Map_TaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(
            (x, arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(x + arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector, 3 args ----

    [Test]
    public async Task Map_ValueTaskWithThreeArgs_TransformsSuccessValue()
    {
        var result = await Result.Ok<int, string>(5).Map((x, arg1, arg2, arg3) => new ValueTask<int>(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Map_ValueTaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("error").Map(
            (x, arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<int>(x + arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync selector, 2 args ----

    [Test]
    public async Task Map_UnitSyncWithTwoArgs_InvokesSelectorOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Map((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Map_UnitSyncWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Map(
            (arg1, arg2) =>
            {
                called = true;
                return arg1 + arg2;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task selector, 2 args ----

    [Test]
    public async Task Map_UnitTaskWithTwoArgs_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map((arg1, arg2) => Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Map_UnitTaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(
            (arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask selector, 2 args ----

    [Test]
    public async Task Map_UnitValueTaskWithTwoArgs_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map((arg1, arg2) => new ValueTask<int>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Map_UnitValueTaskWithTwoArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(
            (arg1, arg2) =>
            {
                called = true;
                return new ValueTask<int>(arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, sync selector, 3 args ----

    [Test]
    public async Task Map_UnitSyncWithThreeArgs_InvokesSelectorOnSuccess()
    {
        var result = Result.Ok<Unit, string>(Unit.Value).Map((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Map_UnitSyncWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = Result.Fail<Unit, string>("error").Map(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return arg1 + arg2 + arg3;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, Task selector, 3 args ----

    [Test]
    public async Task Map_UnitTaskWithThreeArgs_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map((arg1, arg2, arg3) => Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Map_UnitTaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<Unit, TError>, ValueTask selector, 3 args ----

    [Test]
    public async Task Map_UnitValueTaskWithThreeArgs_InvokesSelectorOnSuccess()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map((arg1, arg2, arg3) => new ValueTask<int>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Map_UnitValueTaskWithThreeArgs_PassesThroughFailure()
    {
        var called = false;
        var result = await Result.Fail<Unit, string>("error").Map(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<int>(arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }
}

public class MapTaskResultExtensionTests
{
    // ---- Task<Result<TValue, TError>> source ----

    [Test]
    public async Task Map_TaskSource_Sync_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));

        var result = await resultTask.Map(x => x * 2);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_TaskSource_Sync_PassesThroughFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));

        var result = await resultTask.Map(x =>
        {
            called = true;
            return x * 2;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    [Test]
    public async Task Map_TaskSource_Task_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));

        var result = await resultTask.Map(MapSelectors.DoubleTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_TaskSource_Task_PassesThroughFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));

        var result = await resultTask.Map(x =>
        {
            called = true;
            return MapSelectors.DoubleTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    [Test]
    public async Task Map_TaskSource_SyncWithArg_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));

        var result = await resultTask.Map(static (x, arg) => x + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_TaskSource_TaskWithArg_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));

        var result = await resultTask.Map(MapSelectors.AddTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_TaskSource_UnitSync_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(() => 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_TaskSource_UnitTask_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(MapSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_TaskSource_UnitSyncWithArg_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(static arg => arg, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_TaskSource_UnitTaskWithArg_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(MapSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- Task source, sync selector, 2 args ----

    [Test]
    public async Task Map_TaskSource_SyncWithTwoArgs_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2) => x + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- Task source, Task selector, 2 args ----

    [Test]
    public async Task Map_TaskSource_TaskWithTwoArgs_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2) => Task.FromResult(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- Task source, sync selector, 3 args ----

    [Test]
    public async Task Map_TaskSource_SyncWithThreeArgs_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2, arg3) => x + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- Task source, Task selector, 3 args ----

    [Test]
    public async Task Map_TaskSource_TaskWithThreeArgs_TransformsSuccessValue()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2, arg3) => Task.FromResult(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- Task source, sync selector, 2 args, Unit ----

    [Test]
    public async Task Map_TaskSource_UnitSyncWithTwoArgs_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- Task source, Task selector, 2 args, Unit ----

    [Test]
    public async Task Map_TaskSource_UnitTaskWithTwoArgs_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2) => Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- Task source, sync selector, 3 args, Unit ----

    [Test]
    public async Task Map_TaskSource_UnitSyncWithThreeArgs_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    // ---- Task source, Task selector, 3 args, Unit ----

    [Test]
    public async Task Map_TaskSource_UnitTaskWithThreeArgs_InvokesSelectorOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2, arg3) => Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }
}

public class MapValueTaskResultExtensionTests
{
    // ---- ValueTask<Result<TValue, TError>> source ----

    [Test]
    public async Task Map_ValueTaskSource_Sync_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));

        var result = await resultTask.Map(x => x * 2);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_ValueTaskSource_Sync_PassesThroughFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));

        var result = await resultTask.Map(x =>
        {
            called = true;
            return x * 2;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    [Test]
    public async Task Map_ValueTaskSource_ValueTask_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));

        var result = await resultTask.Map(MapSelectors.DoubleValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_ValueTaskSource_ValueTask_PassesThroughFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));

        var result = await resultTask.Map(x =>
        {
            called = true;
            return MapSelectors.DoubleValueTaskAsync(x);
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(called).IsFalse();
    }

    [Test]
    public async Task Map_ValueTaskSource_SyncWithArg_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));

        var result = await resultTask.Map(static (x, arg) => x + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_ValueTaskSource_ValueTaskWithArg_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));

        var result = await resultTask.Map(MapSelectors.AddValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitSync_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(() => 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitValueTask_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(MapSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitSyncWithArg_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(static arg => arg, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitValueTaskWithArg_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));

        var result = await resultTask.Map(MapSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- ValueTask source, sync selector, 2 args ----

    [Test]
    public async Task Map_ValueTaskSource_SyncWithTwoArgs_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2) => x + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- ValueTask source, ValueTask selector, 2 args ----

    [Test]
    public async Task Map_ValueTaskSource_ValueTaskWithTwoArgs_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2) => new ValueTask<int>(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    // ---- ValueTask source, sync selector, 3 args ----

    [Test]
    public async Task Map_ValueTaskSource_SyncWithThreeArgs_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2, arg3) => x + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- ValueTask source, ValueTask selector, 3 args ----

    [Test]
    public async Task Map_ValueTaskSource_ValueTaskWithThreeArgs_TransformsSuccessValue()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Map((x, arg1, arg2, arg3) => new ValueTask<int>(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    // ---- ValueTask source, sync selector, 2 args, Unit ----

    [Test]
    public async Task Map_ValueTaskSource_UnitSyncWithTwoArgs_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- ValueTask source, ValueTask selector, 2 args, Unit ----

    [Test]
    public async Task Map_ValueTaskSource_UnitValueTaskWithTwoArgs_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2) => new ValueTask<int>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    // ---- ValueTask source, sync selector, 3 args, Unit ----

    [Test]
    public async Task Map_ValueTaskSource_UnitSyncWithThreeArgs_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    // ---- ValueTask source, ValueTask selector, 3 args, Unit ----

    [Test]
    public async Task Map_ValueTaskSource_UnitValueTaskWithThreeArgs_InvokesSelectorOnSuccess()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map((arg1, arg2, arg3) => new ValueTask<int>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }
}

public class MapOverloadResolutionTests
{
    [Test]
    public async Task Map_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Map(async x => await Task.FromResult(x * 2));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Map(async (x, arg) => await Task.FromResult(x + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_TaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<int, string>(5)).Map(async x => await Task.FromResult(x * 2));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_TaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<int, string>(5)).Map(async (x, arg) => await Task.FromResult(x + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_TaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<Unit, string>(Unit.Value)).Map(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_TaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<Unit, string>(Unit.Value)).Map(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_ValueTaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Map(async x => await Task.FromResult(x * 2));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(10));
    }

    [Test]
    public async Task Map_ValueTaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Map(async (x, arg) => await Task.FromResult(x + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(15));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<Unit, string>>(Result.Ok<Unit, string>(Unit.Value)).Map(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<Unit, string>>(Result.Ok<Unit, string>(Unit.Value)).Map(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(42));
    }

    // ---- A bare `async` lambda resolves to the ValueTask overload (2 and 3 extra arguments) ----

    [Test]
    public async Task Map_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Map(async (x, arg1, arg2) => await Task.FromResult(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Map_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Map(async (x, arg1, arg2, arg3) => await Task.FromResult(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Map_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Map_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<Unit, string>(Unit.Value).Map(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Map_TaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Map(async (x, arg1, arg2) => await Task.FromResult(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Map_TaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Map(async (x, arg1, arg2, arg3) => await Task.FromResult(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Map_TaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Map_TaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }

    [Test]
    public async Task Map_ValueTaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Map(async (x, arg1, arg2) => await Task.FromResult(x + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(115));
    }

    [Test]
    public async Task Map_ValueTaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Map(async (x, arg1, arg2, arg3) => await Task.FromResult(x + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1115));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(110));
    }

    [Test]
    public async Task Map_ValueTaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Map(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(1110));
    }
}

internal static class MapSelectors
{
    public static Task<int> DoubleTaskAsync(int value) => Task.FromResult(value * 2);

    public static ValueTask<int> DoubleValueTaskAsync(int value) => new(value * 2);

    public static Task<int> AddTaskAsync(int value, int arg) => Task.FromResult(value + arg);

    public static ValueTask<int> AddValueTaskAsync(int value, int arg) => new(value + arg);

    public static Task<int> FortyTwoTaskAsync() => Task.FromResult(42);

    public static ValueTask<int> FortyTwoValueTaskAsync() => new(42);

    public static Task<int> ArgTaskAsync(int arg) => Task.FromResult(arg);

    public static ValueTask<int> ArgValueTaskAsync(int arg) => new(arg);
}
