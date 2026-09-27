using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class MatchResultExtensionTests
{
    // ---- sync handlers ----

    [Test]
    public async Task Match_Sync_InvokesOnSuccess()
    {
        var result = Result.Ok<int, string>(5).Match(x => $"value: {x}", e => $"error: {e}");

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_Sync_InvokesOnFailure()
    {
        var result = Result.Fail<int, string>("bad").Match(x => $"value: {x}", e => $"error: {e}");

        await Assert.That(result).IsEqualTo("error: bad");
    }

    // ---- Task handlers ----

    [Test]
    public async Task Match_Task_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match(MatchSelectors.SuccessTaskAsync, MatchSelectors.FailureTaskAsync);

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_Task_InvokesOnFailure()
    {
        var result = await Result.Fail<int, string>("bad").Match(MatchSelectors.SuccessTaskAsync, MatchSelectors.FailureTaskAsync);

        await Assert.That(result).IsEqualTo("error: bad");
    }

    // ---- ValueTask handlers ----

    [Test]
    public async Task Match_ValueTask_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match(MatchSelectors.SuccessValueTaskAsync, MatchSelectors.FailureValueTaskAsync);

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_ValueTask_InvokesOnFailure()
    {
        var result = await Result.Fail<int, string>("bad").Match(MatchSelectors.SuccessValueTaskAsync, MatchSelectors.FailureValueTaskAsync);

        await Assert.That(result).IsEqualTo("error: bad");
    }

    // ---- sync handlers, 1 arg ----

    [Test]
    public async Task Match_SyncWithArg_InvokesOnSuccess()
    {
        var result = Result.Ok<int, string>(5).Match((x, arg) => $"value: {x + arg}", (e, arg) => $"error: {e}{arg}", 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_SyncWithArg_InvokesOnFailure()
    {
        var result = Result.Fail<int, string>("bad").Match((x, arg) => $"value: {x + arg}", (e, arg) => $"error: {e}{arg}", 10);

        await Assert.That(result).IsEqualTo("error: bad10");
    }

    // ---- Task handlers, 1 arg ----

    [Test]
    public async Task Match_TaskWithArg_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match(MatchSelectors.SuccessWithArgTaskAsync, MatchSelectors.FailureWithArgTaskAsync, 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_TaskWithArg_InvokesOnFailure()
    {
        var result = await Result.Fail<int, string>("bad").Match(MatchSelectors.SuccessWithArgTaskAsync, MatchSelectors.FailureWithArgTaskAsync, 10);

        await Assert.That(result).IsEqualTo("error: bad10");
    }

    // ---- ValueTask handlers, 1 arg ----

    [Test]
    public async Task Match_ValueTaskWithArg_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match(MatchSelectors.SuccessWithArgValueTaskAsync, MatchSelectors.FailureWithArgValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_ValueTaskWithArg_InvokesOnFailure()
    {
        var result = await Result.Fail<int, string>("bad").Match(MatchSelectors.SuccessWithArgValueTaskAsync, MatchSelectors.FailureWithArgValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo("error: bad10");
    }

    // ---- Result<TValue, TError>, sync handlers, 2 args ----

    [Test]
    public async Task Match_SyncWithTwoArgs_InvokesOnSuccess()
    {
        var result = Result.Ok<int, string>(5).Match((x, arg1, arg2) => $"value: {x + arg1 + arg2}", (e, arg1, arg2) => $"error: {e}{arg1 + arg2}", 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_SyncWithTwoArgs_InvokesOnFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("bad").Match((x, arg1, arg2) => $"value: {x + arg1 + arg2}", (e, arg1, arg2) => $"error: {e}{arg1 + arg2}", 10, 100);

        await Assert.That(result).IsEqualTo("error: bad110");
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task handlers, 2 args ----

    [Test]
    public async Task Match_TaskWithTwoArgs_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match((x, arg1, arg2) => Task.FromResult($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => Task.FromResult($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_TaskWithTwoArgs_InvokesOnFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("bad").Match((x, arg1, arg2) => Task.FromResult($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => Task.FromResult($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("error: bad110");
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask handlers, 2 args ----

    [Test]
    public async Task Match_ValueTaskWithTwoArgs_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match((x, arg1, arg2) => new ValueTask<string>($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => new ValueTask<string>($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_ValueTaskWithTwoArgs_InvokesOnFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("bad").Match((x, arg1, arg2) => new ValueTask<string>($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => new ValueTask<string>($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("error: bad110");
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, sync handlers, 3 args ----

    [Test]
    public async Task Match_SyncWithThreeArgs_InvokesOnSuccess()
    {
        var result = Result.Ok<int, string>(5).Match((x, arg1, arg2, arg3) => $"value: {x + arg1 + arg2 + arg3}", (e, arg1, arg2, arg3) => $"error: {e}{arg1 + arg2 + arg3}", 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_SyncWithThreeArgs_InvokesOnFailure()
    {
        var called = false;
        var result = Result.Fail<int, string>("bad").Match((x, arg1, arg2, arg3) => $"value: {x + arg1 + arg2 + arg3}", (e, arg1, arg2, arg3) => $"error: {e}{arg1 + arg2 + arg3}", 10, 100, 1000);

        await Assert.That(result).IsEqualTo("error: bad1110");
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, Task handlers, 3 args ----

    [Test]
    public async Task Match_TaskWithThreeArgs_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match((x, arg1, arg2, arg3) => Task.FromResult($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => Task.FromResult($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_TaskWithThreeArgs_InvokesOnFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("bad").Match((x, arg1, arg2, arg3) => Task.FromResult($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => Task.FromResult($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("error: bad1110");
        await Assert.That(called).IsFalse();
    }

    // ---- Result<TValue, TError>, ValueTask handlers, 3 args ----

    [Test]
    public async Task Match_ValueTaskWithThreeArgs_InvokesOnSuccess()
    {
        var result = await Result.Ok<int, string>(5).Match((x, arg1, arg2, arg3) => new ValueTask<string>($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => new ValueTask<string>($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_ValueTaskWithThreeArgs_InvokesOnFailure()
    {
        var called = false;
        var result = await Result.Fail<int, string>("bad").Match((x, arg1, arg2, arg3) => new ValueTask<string>($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => new ValueTask<string>($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("error: bad1110");
        await Assert.That(called).IsFalse();
    }
}

public class MatchTaskResultExtensionTests
{
    // ---- Task source, sync handlers ----

    [Test]
    public async Task Match_TaskSource_Sync_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match(x => $"value: {x}", e => $"error: {e}");

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_TaskSource_Sync_InvokesOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match(x => $"value: {x}", e => $"error: {e}");

        await Assert.That(result).IsEqualTo("error: bad");
    }

    // ---- Task source, Task handlers ----

    [Test]
    public async Task Match_TaskSource_Task_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match(MatchSelectors.SuccessTaskAsync, MatchSelectors.FailureTaskAsync);

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_TaskSource_Task_InvokesOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match(MatchSelectors.SuccessTaskAsync, MatchSelectors.FailureTaskAsync);

        await Assert.That(result).IsEqualTo("error: bad");
    }

    // ---- Task source, sync handlers, 1 arg ----

    [Test]
    public async Task Match_TaskSource_SyncWithArg_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg) => $"value: {x + arg}", (e, arg) => $"error: {e}{arg}", 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_TaskSource_SyncWithArg_InvokesOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg) => $"value: {x + arg}", (e, arg) => $"error: {e}{arg}", 10);

        await Assert.That(result).IsEqualTo("error: bad10");
    }

    // ---- Task source, Task handlers, 1 arg ----

    [Test]
    public async Task Match_TaskSource_TaskWithArg_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match(MatchSelectors.SuccessWithArgTaskAsync, MatchSelectors.FailureWithArgTaskAsync, 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_TaskSource_TaskWithArg_InvokesOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match(MatchSelectors.SuccessWithArgTaskAsync, MatchSelectors.FailureWithArgTaskAsync, 10);

        await Assert.That(result).IsEqualTo("error: bad10");
    }

    // ---- Task source, sync handlers, 2 args ----

    [Test]
    public async Task Match_TaskSource_SyncWithTwoArgs_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2) => $"value: {x + arg1 + arg2}", (e, arg1, arg2) => $"error: {e}{arg1 + arg2}", 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_TaskSource_SyncWithTwoArgs_InvokesOnFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2) => $"value: {x + arg1 + arg2}", (e, arg1, arg2) => $"error: {e}{arg1 + arg2}", 10, 100);

        await Assert.That(result).IsEqualTo("error: bad110");
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, Task handlers, 2 args ----

    [Test]
    public async Task Match_TaskSource_TaskWithTwoArgs_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2) => Task.FromResult($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => Task.FromResult($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_TaskSource_TaskWithTwoArgs_InvokesOnFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2) => Task.FromResult($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => Task.FromResult($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("error: bad110");
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, sync handlers, 3 args ----

    [Test]
    public async Task Match_TaskSource_SyncWithThreeArgs_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => $"value: {x + arg1 + arg2 + arg3}", (e, arg1, arg2, arg3) => $"error: {e}{arg1 + arg2 + arg3}", 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_TaskSource_SyncWithThreeArgs_InvokesOnFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => $"value: {x + arg1 + arg2 + arg3}", (e, arg1, arg2, arg3) => $"error: {e}{arg1 + arg2 + arg3}", 10, 100, 1000);

        await Assert.That(result).IsEqualTo("error: bad1110");
        await Assert.That(called).IsFalse();
    }

    // ---- Task source, Task handlers, 3 args ----

    [Test]
    public async Task Match_TaskSource_TaskWithThreeArgs_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => Task.FromResult($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => Task.FromResult($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_TaskSource_TaskWithThreeArgs_InvokesOnFailure()
    {
        var called = false;
        var resultTask = Task.FromResult(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => Task.FromResult($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => Task.FromResult($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("error: bad1110");
        await Assert.That(called).IsFalse();
    }
}

public class MatchValueTaskResultExtensionTests
{
    // ---- ValueTask source, sync handlers ----

    [Test]
    public async Task Match_ValueTaskSource_Sync_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match(x => $"value: {x}", e => $"error: {e}");

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_ValueTaskSource_Sync_InvokesOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match(x => $"value: {x}", e => $"error: {e}");

        await Assert.That(result).IsEqualTo("error: bad");
    }

    // ---- ValueTask source, ValueTask handlers ----

    [Test]
    public async Task Match_ValueTaskSource_ValueTask_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match(MatchSelectors.SuccessValueTaskAsync, MatchSelectors.FailureValueTaskAsync);

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_ValueTaskSource_ValueTask_InvokesOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match(MatchSelectors.SuccessValueTaskAsync, MatchSelectors.FailureValueTaskAsync);

        await Assert.That(result).IsEqualTo("error: bad");
    }

    // ---- ValueTask source, sync handlers, 1 arg ----

    [Test]
    public async Task Match_ValueTaskSource_SyncWithArg_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg) => $"value: {x + arg}", (e, arg) => $"error: {e}{arg}", 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_ValueTaskSource_SyncWithArg_InvokesOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg) => $"value: {x + arg}", (e, arg) => $"error: {e}{arg}", 10);

        await Assert.That(result).IsEqualTo("error: bad10");
    }

    // ---- ValueTask source, ValueTask handlers, 1 arg ----

    [Test]
    public async Task Match_ValueTaskSource_ValueTaskWithArg_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match(MatchSelectors.SuccessWithArgValueTaskAsync, MatchSelectors.FailureWithArgValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_ValueTaskSource_ValueTaskWithArg_InvokesOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match(MatchSelectors.SuccessWithArgValueTaskAsync, MatchSelectors.FailureWithArgValueTaskAsync, 10);

        await Assert.That(result).IsEqualTo("error: bad10");
    }

    // ---- ValueTask source, sync handlers, 2 args ----

    [Test]
    public async Task Match_ValueTaskSource_SyncWithTwoArgs_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2) => $"value: {x + arg1 + arg2}", (e, arg1, arg2) => $"error: {e}{arg1 + arg2}", 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_ValueTaskSource_SyncWithTwoArgs_InvokesOnFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2) => $"value: {x + arg1 + arg2}", (e, arg1, arg2) => $"error: {e}{arg1 + arg2}", 10, 100);

        await Assert.That(result).IsEqualTo("error: bad110");
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, ValueTask handlers, 2 args ----

    [Test]
    public async Task Match_ValueTaskSource_ValueTaskWithTwoArgs_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2) => new ValueTask<string>($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => new ValueTask<string>($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_ValueTaskSource_ValueTaskWithTwoArgs_InvokesOnFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2) => new ValueTask<string>($"value: {x + arg1 + arg2}"), (e, arg1, arg2) => new ValueTask<string>($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("error: bad110");
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, sync handlers, 3 args ----

    [Test]
    public async Task Match_ValueTaskSource_SyncWithThreeArgs_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => $"value: {x + arg1 + arg2 + arg3}", (e, arg1, arg2, arg3) => $"error: {e}{arg1 + arg2 + arg3}", 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_ValueTaskSource_SyncWithThreeArgs_InvokesOnFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => $"value: {x + arg1 + arg2 + arg3}", (e, arg1, arg2, arg3) => $"error: {e}{arg1 + arg2 + arg3}", 10, 100, 1000);

        await Assert.That(result).IsEqualTo("error: bad1110");
        await Assert.That(called).IsFalse();
    }

    // ---- ValueTask source, ValueTask handlers, 3 args ----

    [Test]
    public async Task Match_ValueTaskSource_ValueTaskWithThreeArgs_InvokesOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => new ValueTask<string>($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => new ValueTask<string>($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_ValueTaskSource_ValueTaskWithThreeArgs_InvokesOnFailure()
    {
        var called = false;
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("bad"));
        var result = await resultTask.Match((x, arg1, arg2, arg3) => new ValueTask<string>($"value: {x + arg1 + arg2 + arg3}"), (e, arg1, arg2, arg3) => new ValueTask<string>($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("error: bad1110");
        await Assert.That(called).IsFalse();
    }
}

public class MatchOverloadResolutionTests
{
    [Test]
    public async Task Match_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Match(async x => await Task.FromResult($"value: {x}"), async e => await Task.FromResult($"error: {e}"));

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Match(async (x, arg) => await Task.FromResult($"value: {x + arg}"), async (e, arg) => await Task.FromResult($"error: {e}{arg}"), 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_TaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<int, string>(5)).Match(async x => await Task.FromResult($"value: {x}"), async e => await Task.FromResult($"error: {e}"));

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_TaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await Task.FromResult(Result.Ok<int, string>(5)).Match(async (x, arg) => await Task.FromResult($"value: {x + arg}"), async (e, arg) => await Task.FromResult($"error: {e}{arg}"), 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    [Test]
    public async Task Match_ValueTaskSource_BareAsyncLambda_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Match(async x => await Task.FromResult($"value: {x}"), async e => await Task.FromResult($"error: {e}"));

        await Assert.That(result).IsEqualTo("value: 5");
    }

    [Test]
    public async Task Match_ValueTaskSource_BareAsyncLambdaWithArg_ResolvesToValueTask()
    {
        var result = await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5)).Match(async (x, arg) => await Task.FromResult($"value: {x + arg}"), async (e, arg) => await Task.FromResult($"error: {e}{arg}"), 10);

        await Assert.That(result).IsEqualTo("value: 15");
    }

    // ---- A bare `async` lambda resolves to the ValueTask overload (2 and 3 extra arguments) ----

    [Test]
    public async Task Match_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Match(async (x, arg1, arg2) => await Task.FromResult($"value: {x + arg1 + arg2}"), async (e, arg1, arg2) => await Task.FromResult($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var result = await Result.Ok<int, string>(5).Match(async (x, arg1, arg2, arg3) => await Task.FromResult($"value: {x + arg1 + arg2 + arg3}"), async (e, arg1, arg2, arg3) => await Task.FromResult($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_TaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match(async (x, arg1, arg2) => await Task.FromResult($"value: {x + arg1 + arg2}"), async (e, arg1, arg2) => await Task.FromResult($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_TaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));
        var result = await resultTask.Match(async (x, arg1, arg2, arg3) => await Task.FromResult($"value: {x + arg1 + arg2 + arg3}"), async (e, arg1, arg2, arg3) => await Task.FromResult($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }

    [Test]
    public async Task Match_ValueTaskSource_BareAsyncLambdaWithTwoArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match(async (x, arg1, arg2) => await Task.FromResult($"value: {x + arg1 + arg2}"), async (e, arg1, arg2) => await Task.FromResult($"error: {e}{arg1 + arg2}"), 10, 100);

        await Assert.That(result).IsEqualTo("value: 115");
    }

    [Test]
    public async Task Match_ValueTaskSource_BareAsyncLambdaWithThreeArgs_ResolvesToValueTask()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));
        var result = await resultTask.Match(async (x, arg1, arg2, arg3) => await Task.FromResult($"value: {x + arg1 + arg2 + arg3}"), async (e, arg1, arg2, arg3) => await Task.FromResult($"error: {e}{arg1 + arg2 + arg3}"), 10, 100, 1000);

        await Assert.That(result).IsEqualTo("value: 1115");
    }
}

internal static class MatchSelectors
{
    public static Task<string> SuccessTaskAsync(int value) => Task.FromResult($"value: {value}");

    public static ValueTask<string> SuccessValueTaskAsync(int value) => new($"value: {value}");

    public static Task<string> FailureTaskAsync(string error) => Task.FromResult($"error: {error}");

    public static ValueTask<string> FailureValueTaskAsync(string error) => new($"error: {error}");

    public static Task<string> SuccessWithArgTaskAsync(int value, int arg) => Task.FromResult($"value: {value + arg}");

    public static ValueTask<string> SuccessWithArgValueTaskAsync(int value, int arg) => new($"value: {value + arg}");

    public static Task<string> FailureWithArgTaskAsync(string error, int arg) => Task.FromResult($"error: {error}{arg}");

    public static ValueTask<string> FailureWithArgValueTaskAsync(string error, int arg) => new($"error: {error}{arg}");
}
