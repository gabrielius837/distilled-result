using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class DefaultWithResultExtensionTests
{
    // ---- Result<TValue, TError>, sync thunk ----

    [Test]
    public async Task DefaultWith_Sync_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, string>("error").DefaultWith(e => e.Length);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_Sync_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(7).DefaultWith(e =>
        {
            called = true;
            return e.Length;
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task thunk ----

    [Test]
    public async Task DefaultWith_Task_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(DefaultWithSelectors.LengthTaskAsync);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_Task_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(e =>
        {
            called = true;
            return DefaultWithSelectors.LengthTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask thunk ----

    [Test]
    public async Task DefaultWith_ValueTask_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(DefaultWithSelectors.LengthValueTaskAsync);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_ValueTask_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(e =>
        {
            called = true;
            return DefaultWithSelectors.LengthValueTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_SyncWithArg_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, string>("error").DefaultWith((e, arg) => e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(15);
    }

    [Test]
    public async Task DefaultWith_SyncWithArg_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(7).DefaultWith(
            (e, arg) =>
            {
                called = true;
                return e.Length + arg;
            },
            10);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_TaskWithArg_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(DefaultWithSelectors.AddLengthTaskAsync, 10);

        await Assert.That(result).IsEqualTo(15);
    }

    [Test]
    public async Task DefaultWith_TaskWithArg_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(
            (e, arg) =>
            {
                called = true;
                return DefaultWithSelectors.AddLengthTaskAsync(e, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_ValueTaskWithArg_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(DefaultWithSelectors.AddLengthValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(15);
    }

    [Test]
    public async Task DefaultWith_ValueTaskWithArg_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(
            (e, arg) =>
            {
                called = true;
                return DefaultWithSelectors.AddLengthValueTaskAsync(e, arg);
            },
            10);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync thunk ----

    [Test]
    public async Task DefaultWith_UnitSync_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).DefaultWith(() => 42);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_UnitSync_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(7).DefaultWith(() =>
        {
            called = true;
            return 42;
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task thunk ----

    [Test]
    public async Task DefaultWith_UnitTask_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(DefaultWithSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_UnitTask_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(() =>
        {
            called = true;
            return DefaultWithSelectors.FortyTwoTaskAsync();
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask thunk ----

    [Test]
    public async Task DefaultWith_UnitValueTask_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(DefaultWithSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_UnitValueTask_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(() =>
        {
            called = true;
            return DefaultWithSelectors.FortyTwoValueTaskAsync();
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_UnitSyncWithArg_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).DefaultWith(arg => arg, 42);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_UnitSyncWithArg_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(7).DefaultWith(
            arg =>
            {
                called = true;
                return arg;
            },
            42);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_UnitTaskWithArg_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(DefaultWithSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_UnitTaskWithArg_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(
            arg =>
            {
                called = true;
                return DefaultWithSelectors.ArgTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_UnitValueTaskWithArg_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(DefaultWithSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_UnitValueTaskWithArg_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(
            arg =>
            {
                called = true;
                return DefaultWithSelectors.ArgValueTaskAsync(arg);
            },
            42);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync thunk, 2 args ----

    [Test]
    public async Task DefaultWith_SyncWithTwoArgs_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, string>("error").DefaultWith((e, arg1, arg2) => e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    [Test]
    public async Task DefaultWith_SyncWithTwoArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(7).DefaultWith(
            (e, arg1, arg2) =>
            {
                called = true;
                return e.Length + arg1 + arg2;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task thunk, 2 args ----

    [Test]
    public async Task DefaultWith_TaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith((e, arg1, arg2) => Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    [Test]
    public async Task DefaultWith_TaskWithTwoArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(
            (e, arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(e.Length + arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask thunk, 2 args ----

    [Test]
    public async Task DefaultWith_ValueTaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith((e, arg1, arg2) => new ValueTask<int>(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    [Test]
    public async Task DefaultWith_ValueTaskWithTwoArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(
            (e, arg1, arg2) =>
            {
                called = true;
                return new ValueTask<int>(e.Length + arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync thunk, 3 args ----

    [Test]
    public async Task DefaultWith_SyncWithThreeArgs_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, string>("error").DefaultWith((e, arg1, arg2, arg3) => e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    [Test]
    public async Task DefaultWith_SyncWithThreeArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, string>(7).DefaultWith(
            (e, arg1, arg2, arg3) =>
            {
                called = true;
                return e.Length + arg1 + arg2 + arg3;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task thunk, 3 args ----

    [Test]
    public async Task DefaultWith_TaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith((e, arg1, arg2, arg3) => Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    [Test]
    public async Task DefaultWith_TaskWithThreeArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(
            (e, arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(e.Length + arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask thunk, 3 args ----

    [Test]
    public async Task DefaultWith_ValueTaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith((e, arg1, arg2, arg3) => new ValueTask<int>(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    [Test]
    public async Task DefaultWith_ValueTaskWithThreeArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, string>(7).DefaultWith(
            (e, arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<int>(e.Length + arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync thunk, 2 args ----

    [Test]
    public async Task DefaultWith_UnitSyncWithTwoArgs_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).DefaultWith((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    [Test]
    public async Task DefaultWith_UnitSyncWithTwoArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(7).DefaultWith(
            (arg1, arg2) =>
            {
                called = true;
                return arg1 + arg2;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task thunk, 2 args ----

    [Test]
    public async Task DefaultWith_UnitTaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith((arg1, arg2) => Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    [Test]
    public async Task DefaultWith_UnitTaskWithTwoArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(
            (arg1, arg2) =>
            {
                called = true;
                return Task.FromResult(arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask thunk, 2 args ----

    [Test]
    public async Task DefaultWith_UnitValueTaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith((arg1, arg2) => new ValueTask<int>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    [Test]
    public async Task DefaultWith_UnitValueTaskWithTwoArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(
            (arg1, arg2) =>
            {
                called = true;
                return new ValueTask<int>(arg1 + arg2);
            },
            10, 100);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, sync thunk, 3 args ----

    [Test]
    public async Task DefaultWith_UnitSyncWithThreeArgs_ComputesFallbackOnFailure()
    {
        var result = Result.Fail<int, Unit>(Unit.Value).DefaultWith((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }

    [Test]
    public async Task DefaultWith_UnitSyncWithThreeArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = Result.Ok<int, Unit>(7).DefaultWith(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return arg1 + arg2 + arg3;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, Task thunk, 3 args ----

    [Test]
    public async Task DefaultWith_UnitTaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith((arg1, arg2, arg3) => Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }

    [Test]
    public async Task DefaultWith_UnitTaskWithThreeArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return Task.FromResult(arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, Unit>, ValueTask thunk, 3 args ----

    [Test]
    public async Task DefaultWith_UnitValueTaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith((arg1, arg2, arg3) => new ValueTask<int>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }

    [Test]
    public async Task DefaultWith_UnitValueTaskWithThreeArgs_ReturnsValueOnSuccess()
    {
        var called = false;
        var result = await Result.Ok<int, Unit>(7).DefaultWith(
            (arg1, arg2, arg3) =>
            {
                called = true;
                return new ValueTask<int>(arg1 + arg2 + arg3);
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }
}

public class DefaultWithTaskResultExtensionTests
{
    // ---- Task source, sync thunk ----

    [Test]
    public async Task DefaultWith_TaskSource_Sync_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(e => e.Length);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_TaskSource_Sync_ReturnsValueOnSuccess()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Ok<int, string>(7));
        var result = await resultTask.DefaultWith(e =>
        {
            called = true;
            return e.Length;
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, Task thunk ----

    [Test]
    public async Task DefaultWith_TaskSource_Task_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.LengthTaskAsync);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_TaskSource_Task_ReturnsValueOnSuccess()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Ok<int, string>(7));
        var result = await resultTask.DefaultWith(e =>
        {
            called = true;
            return DefaultWithSelectors.LengthTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, sync thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_TaskSource_SyncWithArg_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg) => e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(15);
    }

    // ---- Task source, Task thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_TaskSource_TaskWithArg_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.AddLengthTaskAsync, 10);

        await Assert.That(result).IsEqualTo(15);
    }

    // ---- Task source, sync thunk, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitSync_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(() => 42);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- Task source, Task thunk, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitTask_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.FortyTwoTaskAsync);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- Task source, sync thunk, 1 arg, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitSyncWithArg_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(arg => arg, 42);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- Task source, Task thunk, 1 arg, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitTaskWithArg_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.ArgTaskAsync, 42);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- Task source, sync thunk, 2 args ----

    [Test]
    public async Task DefaultWith_TaskSource_SyncWithTwoArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2) => e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    // ---- Task source, Task thunk, 2 args ----

    [Test]
    public async Task DefaultWith_TaskSource_TaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2) => Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    // ---- Task source, sync thunk, 3 args ----

    [Test]
    public async Task DefaultWith_TaskSource_SyncWithThreeArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2, arg3) => e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    // ---- Task source, Task thunk, 3 args ----

    [Test]
    public async Task DefaultWith_TaskSource_TaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2, arg3) => Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    // ---- Task source, sync thunk, 2 args, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitSyncWithTwoArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    // ---- Task source, Task thunk, 2 args, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitTaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2) => Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    // ---- Task source, sync thunk, 3 args, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitSyncWithThreeArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }

    // ---- Task source, Task thunk, 3 args, Unit ----

    [Test]
    public async Task DefaultWith_TaskSource_UnitTaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2, arg3) => Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }
}

public class DefaultWithValueTaskResultExtensionTests
{
    // ---- ValueTask source, sync thunk ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_Sync_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(e => e.Length);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_Sync_ReturnsValueOnSuccess()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(7));
        var result = await resultTask.DefaultWith(e =>
        {
            called = true;
            return e.Length;
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, ValueTask thunk ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_ValueTask_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.LengthValueTaskAsync);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_ValueTask_ReturnsValueOnSuccess()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(7));
        var result = await resultTask.DefaultWith(e =>
        {
            called = true;
            return DefaultWithSelectors.LengthValueTaskAsync(e);
        });

        await Assert.That(result).IsEqualTo(7);
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, sync thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_SyncWithArg_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg) => e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(15);
    }

    // ---- ValueTask source, ValueTask thunk, 1 arg ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_ValueTaskWithArg_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.AddLengthValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo(15);
    }

    // ---- ValueTask source, sync thunk, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitSync_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(() => 42);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- ValueTask source, ValueTask thunk, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitValueTask_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.FortyTwoValueTaskAsync);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- ValueTask source, sync thunk, 1 arg, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitSyncWithArg_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(arg => arg, 42);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- ValueTask source, ValueTask thunk, 1 arg, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitValueTaskWithArg_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(DefaultWithSelectors.ArgValueTaskAsync, 42);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- ValueTask source, sync thunk, 2 args ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_SyncWithTwoArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2) => e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    // ---- ValueTask source, ValueTask thunk, 2 args ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_ValueTaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2) => new ValueTask<int>(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    // ---- ValueTask source, sync thunk, 3 args ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_SyncWithThreeArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2, arg3) => e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    // ---- ValueTask source, ValueTask thunk, 3 args ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_ValueTaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith((e, arg1, arg2, arg3) => new ValueTask<int>(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    // ---- ValueTask source, sync thunk, 2 args, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitSyncWithTwoArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2) => arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    // ---- ValueTask source, ValueTask thunk, 2 args, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitValueTaskWithTwoArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2) => new ValueTask<int>(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    // ---- ValueTask source, sync thunk, 3 args, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitSyncWithThreeArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2, arg3) => arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }

    // ---- ValueTask source, ValueTask thunk, 3 args, Unit ----

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitValueTaskWithThreeArgs_ComputesFallbackOnFailure()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith((arg1, arg2, arg3) => new ValueTask<int>(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }
}

public class DefaultWithOverloadResolutionTests
{
    [Test]
    public async Task DefaultWith_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(async e => await Task.FromResult(e.Length));

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(async (e, arg) => await Task.FromResult(e.Length + arg), 10);

        await Assert.That(result).IsEqualTo(15);
    }

    [Test]
    public async Task DefaultWith_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_TaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, string>("error")).DefaultWith(async e => await Task.FromResult(e.Length));

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_TaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, string>("error")).DefaultWith(async (e, arg) => await Task.FromResult(e.Length + arg), 10);

        await Assert.That(result).IsEqualTo(15);
    }

    [Test]
    public async Task DefaultWith_TaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, Unit>(Unit.Value)).DefaultWith(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_TaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Fail<int, Unit>(Unit.Value)).DefaultWith(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Fail<int, string>("error")).DefaultWith(async e => await Task.FromResult(e.Length));

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Fail<int, string>("error")).DefaultWith(async (e, arg) => await Task.FromResult(e.Length + arg), 10);

        await Assert.That(result).IsEqualTo(15);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, Unit>>(Result.Fail<int, Unit>(Unit.Value)).DefaultWith(async () => await Task.FromResult(42));

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, Unit>>(Result.Fail<int, Unit>(Unit.Value)).DefaultWith(async arg => await Task.FromResult(arg), 42);

        await Assert.That(result).IsEqualTo(42);
    }

    // ---- A bare `async` lambda resolves to the ValueTask overload (2 and 3 extra arguments) ----

    [Test]
    public async Task DefaultWith_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(async (e, arg1, arg2) => await Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    [Test]
    public async Task DefaultWith_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, string>("error").DefaultWith(async (e, arg1, arg2, arg3) => await Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    [Test]
    public async Task DefaultWith_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    [Test]
    public async Task DefaultWith_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Fail<int, Unit>(Unit.Value).DefaultWith(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }

    [Test]
    public async Task DefaultWith_TaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(async (e, arg1, arg2) => await Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    [Test]
    public async Task DefaultWith_TaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(async (e, arg1, arg2, arg3) => await Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    [Test]
    public async Task DefaultWith_TaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    [Test]
    public async Task DefaultWith_TaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(async (e, arg1, arg2) => await Task.FromResult(e.Length + arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(115);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.DefaultWith(async (e, arg1, arg2, arg3) => await Task.FromResult(e.Length + arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1115);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(async (arg1, arg2) => await Task.FromResult(arg1 + arg2), 10, 100);

        await Assert.That(result).IsEqualTo(110);
    }

    [Test]
    public async Task DefaultWith_ValueTaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.DefaultWith(async (arg1, arg2, arg3) => await Task.FromResult(arg1 + arg2 + arg3), 10, 100, 1000);

        await Assert.That(result).IsEqualTo(1110);
    }
}

internal static class DefaultWithSelectors
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
