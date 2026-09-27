using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class MapErrorResultExtensionTests
{
    // ---- Result<TValue, TError>, sync selector ----

    [Test]
    public async Task MapError_Sync_TransformsError()
    {
        var result = Result.Fail<int, string>("error").MapError(e => e.Length);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_Sync_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(5).MapError(e =>
        {
            called = true;
            return e.Length;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector ----

    [Test]
    public async Task MapError_Task_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError(MapErrorSelectors.LengthTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_Task_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(e =>
        {
            called = true;
            return MapErrorSelectors.LengthTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector ----

    [Test]
    public async Task MapError_ValueTask_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError(MapErrorSelectors.LengthValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_ValueTask_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(e =>
        {
            called = true;
            return MapErrorSelectors.LengthValueTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync selector, 1 arg ----

    [Test]
    public async Task MapError_SyncWithArg_TransformsError()
    {
        var result = Result.Fail<int, string>("error").MapError((e, arg) => e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    [Test]
    public async Task MapError_SyncWithArg_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(5).MapError(
            (e, arg) =>
            {
                called = true;
                return e.Length + arg;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector, 1 arg ----

    [Test]
    public async Task MapError_TaskWithArg_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError(MapErrorSelectors.AddLengthTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    [Test]
    public async Task MapError_TaskWithArg_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(
            (e, arg) =>
            {
                called = true;
                return MapErrorSelectors.AddLengthTaskAsync(e, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector, 1 arg ----

    [Test]
    public async Task MapError_ValueTaskWithArg_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError(MapErrorSelectors.AddLengthValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    [Test]
    public async Task MapError_ValueTaskWithArg_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(
            (e, arg) =>
            {
                called = true;
                return MapErrorSelectors.AddLengthValueTaskAsync(e, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync selector ----

    [Test]
    public async Task MapError_UnitSync_InvokesSelectorOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).MapError(() => 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_UnitSync_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(5).MapError(() =>
        {
            called = true;
            return 42;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task selector ----

    [Test]
    public async Task MapError_UnitTask_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(MapErrorSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_UnitTask_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(() =>
        {
            called = true;
            return MapErrorSelectors.FortyTwoTaskAsync();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask selector ----

    [Test]
    public async Task MapError_UnitValueTask_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(MapErrorSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_UnitValueTask_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(() =>
        {
            called = true;
            return MapErrorSelectors.FortyTwoValueTaskAsync();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync selector, 1 arg ----

    [Test]
    public async Task MapError_UnitSyncWithArg_InvokesSelectorOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).MapError(arg => arg, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_UnitSyncWithArg_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(5).MapError(
            arg =>
            {
                called = true;
                return arg;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task selector, 1 arg ----

    [Test]
    public async Task MapError_UnitTaskWithArg_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(MapErrorSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_UnitTaskWithArg_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(
            arg =>
            {
                called = true;
                return MapErrorSelectors.ArgTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask selector, 1 arg ----

    [Test]
    public async Task MapError_UnitValueTaskWithArg_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(MapErrorSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_UnitValueTaskWithArg_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(
            arg =>
            {
                called = true;
                return MapErrorSelectors.ArgValueTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync selector, 2 args ----

    [Test]
    public async Task MapError_SyncWithTwoArgs_TransformsError()
    {
        var result = Result.Fail<int, string>("error").MapError((e, arg1, arg2) => e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    [Test]
    public async Task MapError_SyncWithTwoArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(5).MapError(
            (e, arg1, arg2) =>
            {
                called = true;
                return e.Length + arg1 + arg2;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector, 2 args ----

    [Test]
    public async Task MapError_TaskWithTwoArgs_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError((e, arg1, arg2) => Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    [Test]
    public async Task MapError_TaskWithTwoArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(
            (e, arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(e.Length + arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector, 2 args ----

    [Test]
    public async Task MapError_ValueTaskWithTwoArgs_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError((e, arg1, arg2) => new ValueTask<int>(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    [Test]
    public async Task MapError_ValueTaskWithTwoArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(
            (e, arg1, arg2) =>
            {
                called = true;
                return new ValueTask<int>(e.Length + arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync selector, 3 args ----

    [Test]
    public async Task MapError_SyncWithThreeArgs_TransformsError()
    {
        var result = Result.Fail<int, string>("error").MapError((e, arg1, arg2, arg3) => e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    [Test]
    public async Task MapError_SyncWithThreeArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(5).MapError(
            (e, arg1, arg2, arg3) =>
            {
                called = true;
                return e.Length + arg1 + arg2 + arg3;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task selector, 3 args ----

    [Test]
    public async Task MapError_TaskWithThreeArgs_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError((e, arg1, arg2, arg3) => Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    [Test]
    public async Task MapError_TaskWithThreeArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(
            (e, arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(e.Length + arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask selector, 3 args ----

    [Test]
    public async Task MapError_ValueTaskWithThreeArgs_TransformsError()
    {
        var result = await Result.Fail<int, string>("error").MapError((e, arg1, arg2, arg3) => new ValueTask<int>(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    [Test]
    public async Task MapError_ValueTaskWithThreeArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(5).MapError(
            (e, arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<int>(e.Length + arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync selector, 2 args ----

    [Test]
    public async Task MapError_UnitSyncWithTwoArgs_InvokesSelectorOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).MapError((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    [Test]
    public async Task MapError_UnitSyncWithTwoArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(5).MapError(
            (arg1, arg2) =>
            {
                called = true;
                return arg1 + arg2;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task selector, 2 args ----

    [Test]
    public async Task MapError_UnitTaskWithTwoArgs_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError((arg1, arg2) => Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    [Test]
    public async Task MapError_UnitTaskWithTwoArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(
            (arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask selector, 2 args ----

    [Test]
    public async Task MapError_UnitValueTaskWithTwoArgs_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError((arg1, arg2) => new ValueTask<int>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    [Test]
    public async Task MapError_UnitValueTaskWithTwoArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(
            (arg1, arg2) =>
            {
                called = true;
                return new ValueTask<int>(arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync selector, 3 args ----

    [Test]
    public async Task MapError_UnitSyncWithThreeArgs_InvokesSelectorOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).MapError((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }

    [Test]
    public async Task MapError_UnitSyncWithThreeArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(5).MapError(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return arg1 + arg2 + arg3;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task selector, 3 args ----

    [Test]
    public async Task MapError_UnitTaskWithThreeArgs_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError((arg1, arg2, arg3) => Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }

    [Test]
    public async Task MapError_UnitTaskWithThreeArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask selector, 3 args ----

    [Test]
    public async Task MapError_UnitValueTaskWithThreeArgs_InvokesSelectorOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError((arg1, arg2, arg3) => new ValueTask<int>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }

    [Test]
    public async Task MapError_UnitValueTaskWithThreeArgs_PassesThroughSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(5).MapError(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<int>(arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }
}

public class MapErrorTaskResultExtensionTests
{
    // ---- Task source, sync selector ----

    [Test]
    public async Task MapError_TaskSource_Sync_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(e => e.Length);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_TaskSource_Sync_PassesThroughSuccess()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.MapError(e =>
        {
            called = true;
            return e.Length;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, Task selector ----

    [Test]
    public async Task MapError_TaskSource_Task_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(MapErrorSelectors.LengthTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_TaskSource_Task_PassesThroughSuccess()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.MapError(e =>
        {
            called = true;
            return MapErrorSelectors.LengthTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, sync selector, 1 arg ----

    [Test]
    public async Task MapError_TaskSource_SyncWithArg_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg) => e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    // ---- Task source, Task selector, 1 arg ----

    [Test]
    public async Task MapError_TaskSource_TaskWithArg_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(MapErrorSelectors.AddLengthTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    // ---- Task source, sync selector, Unit error ----

    [Test]
    public async Task MapError_TaskSource_UnitSync_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(() => 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- Task source, Task selector, Unit error ----

    [Test]
    public async Task MapError_TaskSource_UnitTask_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(MapErrorSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- Task source, sync selector, 1 arg, Unit error ----

    [Test]
    public async Task MapError_TaskSource_UnitSyncWithArg_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(arg => arg, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- Task source, Task selector, 1 arg, Unit error ----

    [Test]
    public async Task MapError_TaskSource_UnitTaskWithArg_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(MapErrorSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- Task source, sync selector, 2 args ----

    [Test]
    public async Task MapError_TaskSource_SyncWithTwoArgs_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2) => e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    // ---- Task source, Task selector, 2 args ----

    [Test]
    public async Task MapError_TaskSource_TaskWithTwoArgs_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2) => Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    // ---- Task source, sync selector, 3 args ----

    [Test]
    public async Task MapError_TaskSource_SyncWithThreeArgs_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2, arg3) => e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    // ---- Task source, Task selector, 3 args ----

    [Test]
    public async Task MapError_TaskSource_TaskWithThreeArgs_TransformsError()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2, arg3) => Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    // ---- Task source, sync selector, 2 args, Unit ----

    [Test]
    public async Task MapError_TaskSource_UnitSyncWithTwoArgs_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    // ---- Task source, Task selector, 2 args, Unit ----

    [Test]
    public async Task MapError_TaskSource_UnitTaskWithTwoArgs_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2) => Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    // ---- Task source, sync selector, 3 args, Unit ----

    [Test]
    public async Task MapError_TaskSource_UnitSyncWithThreeArgs_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }

    // ---- Task source, Task selector, 3 args, Unit ----

    [Test]
    public async Task MapError_TaskSource_UnitTaskWithThreeArgs_InvokesSelectorOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2, arg3) => Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }
}

public class MapErrorValueTaskResultExtensionTests
{
    // ---- ValueTask source, sync selector ----

    [Test]
    public async Task MapError_ValueTaskSource_Sync_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(e => e.Length);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_ValueTaskSource_Sync_PassesThroughSuccess()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.MapError(e =>
        {
            called = true;
            return e.Length;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, ValueTask selector ----

    [Test]
    public async Task MapError_ValueTaskSource_ValueTask_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(MapErrorSelectors.LengthValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_ValueTaskSource_ValueTask_PassesThroughSuccess()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.MapError(e =>
        {
            called = true;
            return MapErrorSelectors.LengthValueTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, int>(5));
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, sync selector, 1 arg ----

    [Test]
    public async Task MapError_ValueTaskSource_SyncWithArg_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg) => e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    // ---- ValueTask source, ValueTask selector, 1 arg ----

    [Test]
    public async Task MapError_ValueTaskSource_ValueTaskWithArg_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(MapErrorSelectors.AddLengthValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    // ---- ValueTask source, sync selector, Unit error ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitSync_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(() => 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- ValueTask source, ValueTask selector, Unit error ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitValueTask_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(MapErrorSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- ValueTask source, sync selector, 1 arg, Unit error ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitSyncWithArg_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(arg => arg, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- ValueTask source, ValueTask selector, 1 arg, Unit error ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitValueTaskWithArg_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(MapErrorSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- ValueTask source, sync selector, 2 args ----

    [Test]
    public async Task MapError_ValueTaskSource_SyncWithTwoArgs_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2) => e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    // ---- ValueTask source, ValueTask selector, 2 args ----

    [Test]
    public async Task MapError_ValueTaskSource_ValueTaskWithTwoArgs_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2) => new ValueTask<int>(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    // ---- ValueTask source, sync selector, 3 args ----

    [Test]
    public async Task MapError_ValueTaskSource_SyncWithThreeArgs_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2, arg3) => e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    // ---- ValueTask source, ValueTask selector, 3 args ----

    [Test]
    public async Task MapError_ValueTaskSource_ValueTaskWithThreeArgs_TransformsError()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError((e, arg1, arg2, arg3) => new ValueTask<int>(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    // ---- ValueTask source, sync selector, 2 args, Unit ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitSyncWithTwoArgs_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    // ---- ValueTask source, ValueTask selector, 2 args, Unit ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitValueTaskWithTwoArgs_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2) => new ValueTask<int>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    // ---- ValueTask source, sync selector, 3 args, Unit ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitSyncWithThreeArgs_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }

    // ---- ValueTask source, ValueTask selector, 3 args, Unit ----

    [Test]
    public async Task MapError_ValueTaskSource_UnitValueTaskWithThreeArgs_InvokesSelectorOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError((arg1, arg2, arg3) => new ValueTask<int>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }
}

public class MapErrorOverloadResolutionTests
{
    [Test]
    public async Task MapError_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").MapError(async e => await Task.FromResult(e.Length));

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").MapError(async (e, arg) => await Task.FromResult(e.Length + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    [Test]
    public async Task MapError_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_TaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, string>("error")).MapError(async e => await Task.FromResult(e.Length));

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_TaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, string>("error")).MapError(async (e, arg) => await Task.FromResult(e.Length + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    [Test]
    public async Task MapError_TaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, Unit>(Unit.Value)).MapError(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_TaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, Unit>(Unit.Value)).MapError(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_ValueTaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Fail<int, string>("error")).MapError(async e => await Task.FromResult(e.Length));

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(5));
    }

    [Test]
    public async Task MapError_ValueTaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Fail<int, string>("error")).MapError(async (e, arg) => await Task.FromResult(e.Length + arg), 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(15));
    }

    [Test]
    public async Task MapError_ValueTaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, Unit>>(Result.Fail<int, Unit>(Unit.Value)).MapError(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    [Test]
    public async Task MapError_ValueTaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, Unit>>(Result.Fail<int, Unit>(Unit.Value)).MapError(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(42));
    }

    // ---- A bare `async` lambda resolves to the ValueTask overload (2 and 3 extra arguments) ----

    [Test]
    public async Task MapError_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").MapError(async (e, arg1, arg2) => await Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    [Test]
    public async Task MapError_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").MapError(async (e, arg1, arg2, arg3) => await Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    [Test]
    public async Task MapError_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    [Test]
    public async Task MapError_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).MapError(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }

    [Test]
    public async Task MapError_TaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(async (e, arg1, arg2) => await Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    [Test]
    public async Task MapError_TaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(async (e, arg1, arg2, arg3) => await Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    [Test]
    public async Task MapError_TaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    [Test]
    public async Task MapError_TaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }

    [Test]
    public async Task MapError_ValueTaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(async (e, arg1, arg2) => await Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(115));
    }

    [Test]
    public async Task MapError_ValueTaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.MapError(async (e, arg1, arg2, arg3) => await Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1115));
    }

    [Test]
    public async Task MapError_ValueTaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(110));
    }

    [Test]
    public async Task MapError_ValueTaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.MapError(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, int>(1110));
    }
}

internal static class MapErrorSelectors
{
    public static Task<int> LengthTaskAsync(string error) => Task.FromResult(error.Length);

    public static ValueTask<int> LengthValueTaskAsync(string error) => new(error.Length);

    public static Task<int> AddLengthTaskAsync(string error, int arg) => Task.FromResult(error.Length + arg);

    public static ValueTask<int> AddLengthValueTaskAsync(string error, int arg) => new(error.Length + arg);

    public static Task<int> FortyTwoTaskAsync() => Task.FromResult(42);

    public static ValueTask<int> FortyTwoValueTaskAsync() => new(42);

    public static Task<int> ArgTaskAsync(int arg) => Task.FromResult(arg);

    public static ValueTask<int> ArgValueTaskAsync(int arg) => new(arg);
}
