using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class IterResultExtensionTests
{
    // ---- Result<TValue, TError>, sync action ----

    [Test]
    public async Task Iter_Sync_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).Iter(x => seen = x);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_Sync_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").Iter(x => seen = x);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action ----

    [Test]
    public async Task Iter_Task_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(x =>
        {
            seen = x;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_Task_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(x =>
        {
            seen = x;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action ----

    [Test]
    public async Task Iter_ValueTask_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(x =>
        {
            seen = x;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_ValueTask_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(x =>
        {
            seen = x;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, sync action, 1 arg ----

    [Test]
    public async Task Iter_SyncWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).Iter((x, arg) => seen = x + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task Iter_SyncWithArg_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").Iter((x, arg) => seen = x + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action, 1 arg ----

    [Test]
    public async Task Iter_TaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(
            (x, arg) =>
            {
                seen = x + arg;
                return Task.CompletedTask;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task Iter_TaskWithArg_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(
            (x, arg) =>
            {
                seen = x + arg;
                return Task.CompletedTask;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action, 1 arg ----

    [Test]
    public async Task Iter_ValueTaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(
            (x, arg) =>
            {
                seen = x + arg;
                return new ValueTask();
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task Iter_ValueTaskWithArg_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(
            (x, arg) =>
            {
                seen = x + arg;
                return new ValueTask();
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, sync action ----

    [Test]
    public async Task Iter_UnitSync_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<Unit, string>(Unit.Value).Iter(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_UnitSync_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<Unit, string>("error").Iter(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, Task action ----

    [Test]
    public async Task Iter_UnitTask_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(() =>
        {
            seen = 42;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_UnitTask_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(() =>
        {
            seen = 42;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, ValueTask action ----

    [Test]
    public async Task Iter_UnitValueTask_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(() =>
        {
            seen = 42;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_UnitValueTask_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(() =>
        {
            seen = 42;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, sync action, 1 arg ----

    [Test]
    public async Task Iter_UnitSyncWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<Unit, string>(Unit.Value).Iter(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_UnitSyncWithArg_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<Unit, string>("error").Iter(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, Task action, 1 arg ----

    [Test]
    public async Task Iter_UnitTaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(
            arg =>
            {
                seen = arg;
                return Task.CompletedTask;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_UnitTaskWithArg_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(
            arg =>
            {
                seen = arg;
                return Task.CompletedTask;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, ValueTask action, 1 arg ----

    [Test]
    public async Task Iter_UnitValueTaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(
            arg =>
            {
                seen = arg;
                return new ValueTask();
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_UnitValueTaskWithArg_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(
            arg =>
            {
                seen = arg;
                return new ValueTask();
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, sync action, 2 args ----

    [Test]
    public async Task Iter_SyncWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).Iter((x, arg1, arg2) => seen = x + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task Iter_SyncWithTwoArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").Iter((x, arg1, arg2) => seen = x + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action, 2 args ----

    [Test]
    public async Task Iter_TaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(
            (x, arg1, arg2) =>
            {
                seen = x + arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task Iter_TaskWithTwoArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(
            (x, arg1, arg2) =>
            {
                seen = x + arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action, 2 args ----

    [Test]
    public async Task Iter_ValueTaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(
            (x, arg1, arg2) =>
            {
                seen = x + arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task Iter_ValueTaskWithTwoArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(
            (x, arg1, arg2) =>
            {
                seen = x + arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, sync action, 3 args ----

    [Test]
    public async Task Iter_SyncWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<int, string>(5).Iter((x, arg1, arg2, arg3) => seen = x + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task Iter_SyncWithThreeArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<int, string>("error").Iter((x, arg1, arg2, arg3) => seen = x + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, Task action, 3 args ----

    [Test]
    public async Task Iter_TaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(
            (x, arg1, arg2, arg3) =>
            {
                seen = x + arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task Iter_TaskWithThreeArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(
            (x, arg1, arg2, arg3) =>
            {
                seen = x + arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<TValue, TError>, ValueTask action, 3 args ----

    [Test]
    public async Task Iter_ValueTaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(
            (x, arg1, arg2, arg3) =>
            {
                seen = x + arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task Iter_ValueTaskWithThreeArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<int, string>("error").Iter(
            (x, arg1, arg2, arg3) =>
            {
                seen = x + arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, sync action, 2 args ----

    [Test]
    public async Task Iter_UnitSyncWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<Unit, string>(Unit.Value).Iter((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task Iter_UnitSyncWithTwoArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<Unit, string>("error").Iter((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, Task action, 2 args ----

    [Test]
    public async Task Iter_UnitTaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task Iter_UnitTaskWithTwoArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, ValueTask action, 2 args ----

    [Test]
    public async Task Iter_UnitValueTaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task Iter_UnitValueTaskWithTwoArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, sync action, 3 args ----

    [Test]
    public async Task Iter_UnitSyncWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = Result.Ok<Unit, string>(Unit.Value).Iter((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task Iter_UnitSyncWithThreeArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = Result.Fail<Unit, string>("error").Iter((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, Task action, 3 args ----

    [Test]
    public async Task Iter_UnitTaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task Iter_UnitTaskWithThreeArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Result<Unit, TError>, ValueTask action, 3 args ----

    [Test]
    public async Task Iter_UnitValueTaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task Iter_UnitValueTaskWithThreeArgs_DoesNothingOnFailure()
    {
        var seen = 0;
        var result = await Result.Fail<Unit, string>("error").Iter(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Fail<Unit, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }
}

public class IterTaskResultExtensionTests
{
    // ---- Task source, sync action ----

    [Test]
    public async Task Iter_TaskSource_Sync_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(x => seen = x);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_TaskSource_Sync_DoesNothingOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.Iter(x => seen = x);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Task source, Task action ----

    [Test]
    public async Task Iter_TaskSource_Task_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(x =>
        {
            seen = x;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_TaskSource_Task_DoesNothingOnFailure()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));
        var result = await resultTask.Iter(x =>
        {
            seen = x;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- Task source, sync action, 1 arg ----

    [Test]
    public async Task Iter_TaskSource_SyncWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter((x, arg) => seen = x + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- Task source, Task action, 1 arg ----

    [Test]
    public async Task Iter_TaskSource_TaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(
            (x, arg) =>
            {
                seen = x + arg;
                return Task.CompletedTask;
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- Task source, sync action, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitSync_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, Task action, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitTask_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(() =>
        {
            seen = 42;
            return Task.CompletedTask;
        });

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, sync action, 1 arg, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitSyncWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, Task action, 1 arg, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitTaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(
            arg =>
            {
                seen = arg;
                return Task.CompletedTask;
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- Task source, sync action, 2 args ----

    [Test]
    public async Task Iter_TaskSource_SyncWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter((x, arg1, arg2) => seen = x + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- Task source, Task action, 2 args ----

    [Test]
    public async Task Iter_TaskSource_TaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(
            (x, arg1, arg2) =>
            {
                seen = x + arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- Task source, sync action, 3 args ----

    [Test]
    public async Task Iter_TaskSource_SyncWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter((x, arg1, arg2, arg3) => seen = x + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- Task source, Task action, 3 args ----

    [Test]
    public async Task Iter_TaskSource_TaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(
            (x, arg1, arg2, arg3) =>
            {
                seen = x + arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- Task source, sync action, 2 args, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitSyncWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- Task source, Task action, 2 args, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitTaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return Task.CompletedTask;
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- Task source, sync action, 3 args, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitSyncWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    // ---- Task source, Task action, 3 args, Unit ----

    [Test]
    public async Task Iter_TaskSource_UnitTaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return Task.CompletedTask;
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }
}

public class IterValueTaskResultExtensionTests
{
    // ---- ValueTask source, sync action ----

    [Test]
    public async Task Iter_ValueTaskSource_Sync_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(x => seen = x);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_ValueTaskSource_Sync_DoesNothingOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.Iter(x => seen = x);

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- ValueTask source, ValueTask action ----

    [Test]
    public async Task Iter_ValueTaskSource_ValueTask_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(x =>
        {
            seen = x;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_ValueTaskSource_ValueTask_DoesNothingOnFailure()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));
        var result = await resultTask.Iter(x =>
        {
            seen = x;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Fail<int, string>("error"));
        await Assert.That(seen).IsEqualTo(0);
    }

    // ---- ValueTask source, sync action, 1 arg ----

    [Test]
    public async Task Iter_ValueTaskSource_SyncWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter((x, arg) => seen = x + arg, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- ValueTask source, ValueTask action, 1 arg ----

    [Test]
    public async Task Iter_ValueTaskSource_ValueTaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(
            (x, arg) =>
            {
                seen = x + arg;
                return new ValueTask();
            },
            10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    // ---- ValueTask source, sync action, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitSync_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(() => seen = 42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, ValueTask action, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitValueTask_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(() =>
        {
            seen = 42;
            return new ValueTask();
        });

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, sync action, 1 arg, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitSyncWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(arg => seen = arg, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, ValueTask action, 1 arg, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitValueTaskWithArg_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(
            arg =>
            {
                seen = arg;
                return new ValueTask();
            },
            42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- ValueTask source, sync action, 2 args ----

    [Test]
    public async Task Iter_ValueTaskSource_SyncWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter((x, arg1, arg2) => seen = x + arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- ValueTask source, ValueTask action, 2 args ----

    [Test]
    public async Task Iter_ValueTaskSource_ValueTaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(
            (x, arg1, arg2) =>
            {
                seen = x + arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    // ---- ValueTask source, sync action, 3 args ----

    [Test]
    public async Task Iter_ValueTaskSource_SyncWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter((x, arg1, arg2, arg3) => seen = x + arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- ValueTask source, ValueTask action, 3 args ----

    [Test]
    public async Task Iter_ValueTaskSource_ValueTaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(
            (x, arg1, arg2, arg3) =>
            {
                seen = x + arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    // ---- ValueTask source, sync action, 2 args, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitSyncWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter((arg1, arg2) => seen = arg1 + arg2, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- ValueTask source, ValueTask action, 2 args, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitValueTaskWithTwoArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(
            (arg1, arg2) =>
            {
                seen = arg1 + arg2;
                return new ValueTask();
            },
            10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    // ---- ValueTask source, sync action, 3 args, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitSyncWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter((arg1, arg2, arg3) => seen = arg1 + arg2 + arg3, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    // ---- ValueTask source, ValueTask action, 3 args, Unit ----

    [Test]
    public async Task Iter_ValueTaskSource_UnitValueTaskWithThreeArgs_RunsActionOnSuccess()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(
            (arg1, arg2, arg3) =>
            {
                seen = arg1 + arg2 + arg3;
                return new ValueTask();
            },
            10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }
}

public class IterOverloadResolutionTests
{
    [Test]
    public async Task Iter_BareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(async x => { await Task.Yield(); seen = x; });

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(async (x, arg) => { await Task.Yield(); seen = x + arg; }, 10);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task Iter_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(async () => { await Task.Yield(); seen = 42; });

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(async arg => { await Task.Yield(); seen = arg; }, 42);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_TaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Ok<int, string>(5)).Iter(async x => { await Task.Yield(); seen = x; });

        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_TaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Ok<int, string>(5)).Iter(async (x, arg) => { await Task.Yield(); seen = x + arg; }, 10);

        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task Iter_TaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Ok<Unit, string>(Unit.Value)).Iter(async () => { await Task.Yield(); seen = 42; });

        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_TaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await Task.FromResult(Result.Ok<Unit, string>(Unit.Value)).Iter(async arg => { await Task.Yield(); seen = arg; }, 42);

        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_ValueTaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Iter(async x => { await Task.Yield(); seen = x; });

        await Assert.That(seen).IsEqualTo(5);
    }

    [Test]
    public async Task Iter_ValueTaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Iter(async (x, arg) => { await Task.Yield(); seen = x + arg; }, 10);

        await Assert.That(seen).IsEqualTo(15);
    }

    [Test]
    public async Task Iter_ValueTaskSource_UnitBareAsyncLambda_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<Unit, string>>(Result.Ok<Unit, string>(Unit.Value)).Iter(async () => { await Task.Yield(); seen = 42; });

        await Assert.That(seen).IsEqualTo(42);
    }

    [Test]
    public async Task Iter_ValueTaskSource_UnitBareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var seen = 0;
        await new ValueTask<Result<Unit, string>>(Result.Ok<Unit, string>(Unit.Value)).Iter(async arg => { await Task.Yield(); seen = arg; }, 42);

        await Assert.That(seen).IsEqualTo(42);
    }

    // ---- A bare `async` lambda resolves to the ValueTask overload (2 and 3 extra arguments) ----

    [Test]
    public async Task Iter_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(async (x, arg1, arg2) => { await Task.Yield(); seen = x + arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task Iter_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<int, string>(5).Iter(async (x, arg1, arg2, arg3) => { await Task.Yield(); seen = x + arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task Iter_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(async (arg1, arg2) => { await Task.Yield(); seen = arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task Iter_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var result = await Result.Ok<Unit, string>(Unit.Value).Iter(async (arg1, arg2, arg3) => { await Task.Yield(); seen = arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task Iter_TaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(async (x, arg1, arg2) => { await Task.Yield(); seen = x + arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task Iter_TaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(async (x, arg1, arg2, arg3) => { await Task.Yield(); seen = x + arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task Iter_TaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(async (arg1, arg2) => { await Task.Yield(); seen = arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task Iter_TaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        var resultTask = Task.FromResult(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(async (arg1, arg2, arg3) => { await Task.Yield(); seen = arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }

    [Test]
    public async Task Iter_ValueTaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(async (x, arg1, arg2) => { await Task.Yield(); seen = x + arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(115);
    }

    [Test]
    public async Task Iter_ValueTaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Iter(async (x, arg1, arg2, arg3) => { await Task.Yield(); seen = x + arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<int, string>(5));
        await Assert.That(seen).IsEqualTo(1115);
    }

    [Test]
    public async Task Iter_ValueTaskSource_UnitBareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(async (arg1, arg2) => { await Task.Yield(); seen = arg1 + arg2; }, 10, 100);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(110);
    }

    [Test]
    public async Task Iter_ValueTaskSource_UnitBareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var seen = 0;
        ValueTask<Result<Unit, string>> resultTask = new(Result.Ok<Unit, string>(Unit.Value));
        var result = await resultTask.Iter(async (arg1, arg2, arg3) => { await Task.Yield(); seen = arg1 + arg2 + arg3; }, 10, 100, 1000);

        await Assert.That(result).IsEqualTo(Result.Ok<Unit, string>(Unit.Value));
        await Assert.That(seen).IsEqualTo(1110);
    }
}
