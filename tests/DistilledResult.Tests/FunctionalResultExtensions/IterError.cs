using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class IterErrorResultExtensionTests
{
    // ---- Result<TValue, TError>, sync action ----

    [Test]
    public async Task IterError_Sync_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").IterError(e => seen = e.Length);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_Sync_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).IterError(e => seen = e.Length);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action ----

    [Test]
    public async Task IterError_Task_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(e =>
        {
            seen = e.Length;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_Task_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(e =>
        {
            seen = e.Length;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action ----

    [Test]
    public async Task IterError_ValueTask_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(e =>
        {
            seen = e.Length;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_ValueTask_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(e =>
        {
            seen = e.Length;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, sync action, 1 arg ----

    [Test]
    public async Task IterError_SyncWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").IterError((e, arg) => seen = e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task IterError_SyncWithArg_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).IterError((e, arg) => seen = e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action, 1 arg ----

    [Test]
    public async Task IterError_TaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(
            (e, arg) =>
            {
                seen = e.Length + arg;
                return Task.CompletedTask;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task IterError_TaskWithArg_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(
            (e, arg) =>
            {
                seen = e.Length + arg;
                return Task.CompletedTask;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action, 1 arg ----

    [Test]
    public async Task IterError_ValueTaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(
            (e, arg) =>
            {
                seen = e.Length + arg;
                return new ValueTask();
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task IterError_ValueTaskWithArg_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(
            (e, arg) =>
            {
                seen = e.Length + arg;
                return new ValueTask();
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, sync action ----

    [Test]
    public async Task IterError_UnitSync_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, Unit>(Unit.Value).IterError(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_UnitSync_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, Unit>(5).IterError(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, Task action ----

    [Test]
    public async Task IterError_UnitTask_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(() =>
        {
            seen = 42;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_UnitTask_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(() =>
        {
            seen = 42;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, ValueTask action ----

    [Test]
    public async Task IterError_UnitValueTask_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(() =>
        {
            seen = 42;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_UnitValueTask_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(() =>
        {
            seen = 42;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, sync action, 1 arg ----

    [Test]
    public async Task IterError_UnitSyncWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, Unit>(Unit.Value).IterError(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_UnitSyncWithArg_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, Unit>(5).IterError(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, Task action, 1 arg ----

    [Test]
    public async Task IterError_UnitTaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(
            arg =>
            {
                seen = arg;
                return Task.CompletedTask;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_UnitTaskWithArg_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(
            arg =>
            {
                seen = arg;
                return Task.CompletedTask;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, ValueTask action, 1 arg ----

    [Test]
    public async Task IterError_UnitValueTaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(
            arg =>
            {
                seen = arg;
                return new ValueTask();
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_UnitValueTaskWithArg_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(
            arg =>
            {
                seen = arg;
                return new ValueTask();
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, sync action, 2 args ----

    [Test]
    public async Task IterError_SyncWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").IterError((e, arg1, arg2) => seen = e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task IterError_SyncWithTwoArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).IterError((e, arg1, arg2) => seen = e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action, 2 args ----

    [Test]
    public async Task IterError_TaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(
            (e, arg1, arg2) =>
            {
                seen = e.Length + arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task IterError_TaskWithTwoArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(
            (e, arg1, arg2) =>
            {
                seen = e.Length + arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action, 2 args ----

    [Test]
    public async Task IterError_ValueTaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(
            (e, arg1, arg2) =>
            {
                seen = e.Length + arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task IterError_ValueTaskWithTwoArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(
            (e, arg1, arg2) =>
            {
                seen = e.Length + arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, sync action, 3 args ----

    [Test]
    public async Task IterError_SyncWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").IterError((e, arg1, arg2, arg3) => seen = e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task IterError_SyncWithThreeArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).IterError((e, arg1, arg2, arg3) => seen = e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action, 3 args ----

    [Test]
    public async Task IterError_TaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(
            (e, arg1, arg2, arg3) =>
            {
                seen = e.Length + arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task IterError_TaskWithThreeArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(
            (e, arg1, arg2, arg3) =>
            {
                seen = e.Length + arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action, 3 args ----

    [Test]
    public async Task IterError_ValueTaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(
            (e, arg1, arg2, arg3) =>
            {
                seen = e.Length + arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task IterError_ValueTaskWithThreeArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).IterError(
            (e, arg1, arg2, arg3) =>
            {
                seen = e.Length + arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, sync action, 2 args ----

    [Test]
    public async Task IterError_UnitSyncWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, Unit>(Unit.Value).IterError((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task IterError_UnitSyncWithTwoArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, Unit>(5).IterError((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, Task action, 2 args ----

    [Test]
    public async Task IterError_UnitTaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task IterError_UnitTaskWithTwoArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, ValueTask action, 2 args ----

    [Test]
    public async Task IterError_UnitValueTaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task IterError_UnitValueTaskWithTwoArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, sync action, 3 args ----

    [Test]
    public async Task IterError_UnitSyncWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, Unit>(Unit.Value).IterError((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task IterError_UnitSyncWithThreeArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, Unit>(5).IterError((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, Task action, 3 args ----

    [Test]
    public async Task IterError_UnitTaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task IterError_UnitTaskWithThreeArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, Unit>, ValueTask action, 3 args ----

    [Test]
    public async Task IterError_UnitValueTaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task IterError_UnitValueTaskWithThreeArgs_DoesNothingOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, Unit>(5).IterError(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, Unit>(5));
        await Assert.That(seen).IsEqualTo(0);
    }
}

public class IterErrorTaskResultExtensionTests
{
    // ---- Task source, sync action ----

    [Test]
    public async Task IterError_TaskSource_Sync_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(e => seen = e.Length);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_TaskSource_Sync_DoesNothingOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.IterError(e => seen = e.Length);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Task source, Task action ----

    [Test]
    public async Task IterError_TaskSource_Task_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(e =>
        {
            seen = e.Length;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_TaskSource_Task_DoesNothingOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.IterError(e =>
        {
            seen = e.Length;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Task source, sync action, 1 arg ----

    [Test]
    public async Task IterError_TaskSource_SyncWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError((e, arg) => seen = e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- Task source, Task action, 1 arg ----

    [Test]
    public async Task IterError_TaskSource_TaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(
            (e, arg) =>
            {
                seen = e.Length + arg;
                return Task.CompletedTask;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- Task source, sync action, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitSync_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, Task action, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitTask_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(() =>
        {
            seen = 42;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, sync action, 1 arg, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitSyncWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, Task action, 1 arg, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitTaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(
            arg =>
            {
                seen = arg;
                return Task.CompletedTask;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, sync action, 2 args ----

    [Test]
    public async Task IterError_TaskSource_SyncWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError((e, arg1, arg2) => seen = e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- Task source, Task action, 2 args ----

    [Test]
    public async Task IterError_TaskSource_TaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(
            (e, arg1, arg2) =>
            {
                seen = e.Length + arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- Task source, sync action, 3 args ----

    [Test]
    public async Task IterError_TaskSource_SyncWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError((e, arg1, arg2, arg3) => seen = e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- Task source, Task action, 3 args ----

    [Test]
    public async Task IterError_TaskSource_TaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(
            (e, arg1, arg2, arg3) =>
            {
                seen = e.Length + arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- Task source, sync action, 2 args, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitSyncWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- Task source, Task action, 2 args, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitTaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- Task source, sync action, 3 args, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitSyncWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    // ---- Task source, Task action, 3 args, Unit ----

    [Test]
    public async Task IterError_TaskSource_UnitTaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }
}

public class IterErrorValueTaskResultExtensionTests
{
    // ---- ValueTask source, sync action ----

    [Test]
    public async Task IterError_ValueTaskSource_Sync_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(e => seen = e.Length);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_ValueTaskSource_Sync_DoesNothingOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.IterError(e => seen = e.Length);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- ValueTask source, ValueTask action ----

    [Test]
    public async Task IterError_ValueTaskSource_ValueTask_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(e =>
        {
            seen = e.Length;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_ValueTaskSource_ValueTask_DoesNothingOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.IterError(e =>
        {
            seen = e.Length;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- ValueTask source, sync action, 1 arg ----

    [Test]
    public async Task IterError_ValueTaskSource_SyncWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError((e, arg) => seen = e.Length + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- ValueTask source, ValueTask action, 1 arg ----

    [Test]
    public async Task IterError_ValueTaskSource_ValueTaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(
            (e, arg) =>
            {
                seen = e.Length + arg;
                return new ValueTask();
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- ValueTask source, sync action, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitSync_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, ValueTask action, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitValueTask_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(() =>
        {
            seen = 42;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, sync action, 1 arg, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitSyncWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, ValueTask action, 1 arg, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitValueTaskWithArg_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(
            arg =>
            {
                seen = arg;
                return new ValueTask();
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, sync action, 2 args ----

    [Test]
    public async Task IterError_ValueTaskSource_SyncWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError((e, arg1, arg2) => seen = e.Length + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- ValueTask source, ValueTask action, 2 args ----

    [Test]
    public async Task IterError_ValueTaskSource_ValueTaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(
            (e, arg1, arg2) =>
            {
                seen = e.Length + arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- ValueTask source, sync action, 3 args ----

    [Test]
    public async Task IterError_ValueTaskSource_SyncWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError((e, arg1, arg2, arg3) => seen = e.Length + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- ValueTask source, ValueTask action, 3 args ----

    [Test]
    public async Task IterError_ValueTaskSource_ValueTaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(
            (e, arg1, arg2, arg3) =>
            {
                seen = e.Length + arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- ValueTask source, sync action, 2 args, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitSyncWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- ValueTask source, ValueTask action, 2 args, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitValueTaskWithTwoArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- ValueTask source, sync action, 3 args, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitSyncWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    // ---- ValueTask source, ValueTask action, 3 args, Unit ----

    [Test]
    public async Task IterError_ValueTaskSource_UnitValueTaskWithThreeArgs_RunsActionOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }
}

public class IterErrorOverloadResolutionTests
{
    [Test]
    public async Task IterError_BareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(async e => { await Task.Yield(); seen = e.Length; });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(async (e, arg) => { await Task.Yield(); seen = e.Length + arg; }, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task IterError_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(async () => { await Task.Yield(); seen = 42; });

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(async arg => { await Task.Yield(); seen = arg; }, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_TaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Fail<int, string>("error")).IterError(async e => { await Task.Yield(); seen = e.Length; });

        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_TaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Fail<int, string>("error")).IterError(async (e, arg) => { await Task.Yield(); seen = e.Length + arg; }, 10);

        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task IterError_TaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Fail<int, Unit>(Unit.Value)).IterError(async () => { await Task.Yield(); seen = 42; });

        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_TaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Fail<int, Unit>(Unit.Value)).IterError(async arg => { await Task.Yield(); seen = arg; }, 42);

        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_ValueTaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<int, string>>(Result.Fail<int, string>("error")).IterError(async e => { await Task.Yield(); seen = e.Length; });

        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task IterError_ValueTaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<int, string>>(Result.Fail<int, string>("error")).IterError(async (e, arg) => { await Task.Yield(); seen = e.Length + arg; }, 10);

        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task IterError_ValueTaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<int, Unit>>(Result.Fail<int, Unit>(Unit.Value)).IterError(async () => { await Task.Yield(); seen = 42; });

        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task IterError_ValueTaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<int, Unit>>(Result.Fail<int, Unit>(Unit.Value)).IterError(async arg => { await Task.Yield(); seen = arg; }, 42);

        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- A bare `async` lambda resolves to the ValueTask overload (2 and 3 extra arguments) ----

    [Test]
    public async Task IterError_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(async (e, arg1, arg2) => { await Task.Yield(); seen = e.Length + arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task IterError_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").IterError(async (e, arg1, arg2, arg3) => { await Task.Yield(); seen = e.Length + arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task IterError_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(async (arg1, arg2) => { await Task.Yield(); seen = arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task IterError_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Fail<int, Unit>(Unit.Value).IterError(async (arg1, arg2, arg3) => { await Task.Yield(); seen = arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task IterError_TaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(async (e, arg1, arg2) => { await Task.Yield(); seen = e.Length + arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task IterError_TaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(async (e, arg1, arg2, arg3) => { await Task.Yield(); seen = e.Length + arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task IterError_TaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(async (arg1, arg2) => { await Task.Yield(); seen = arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task IterError_TaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(async (arg1, arg2, arg3) => { await Task.Yield(); seen = arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task IterError_ValueTaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(async (e, arg1, arg2) => { await Task.Yield(); seen = e.Length + arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task IterError_ValueTaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.IterError(async (e, arg1, arg2, arg3) => { await Task.Yield(); seen = e.Length + arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task IterError_ValueTaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(async (arg1, arg2) => { await Task.Yield(); seen = arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task IterError_ValueTaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<int, Unit>> resultTask = new(Result.Fail<int, Unit>(Unit.Value));
        var result = await resultTask.IterError(async (arg1, arg2, arg3) => { await Task.Yield(); seen = arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, Unit>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }
}
