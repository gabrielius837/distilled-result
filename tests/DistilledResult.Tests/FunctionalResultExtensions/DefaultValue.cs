using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Tests.FunctionalResultExtensions;

public class DefaultValueResultExtensionTests
{
    [Test]
    public async Task DefaultValue_ReturnsFallbackOnFailure()
    {
        var result = Result.Fail<int, string>("error").DefaultValue(-1);

        await Assert.That(result).IsEqualTo(-1);
    }

    [Test]
    public async Task DefaultValue_ReturnsValueOnSuccess()
    {
        var result = Result.Ok<int, string>(5).DefaultValue(-1);

        await Assert.That(result).IsEqualTo(5);
    }
}

public class DefaultValueTaskResultExtensionTests
{
    [Test]
    public async Task DefaultValue_TaskSource_ReturnsFallbackOnFailure()
    {
        var resultTask = Task.FromResult(Result.Fail<int, string>("error"));

        var result = await resultTask.DefaultValue(-1);

        await Assert.That(result).IsEqualTo(-1);
    }

    [Test]
    public async Task DefaultValue_TaskSource_ReturnsValueOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Ok<int, string>(5));

        var result = await resultTask.DefaultValue(-1);

        await Assert.That(result).IsEqualTo(5);
    }
}

public class DefaultValueValueTaskResultExtensionTests
{
    [Test]
    public async Task DefaultValue_ValueTaskSource_ReturnsFallbackOnFailure()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Fail<int, string>("error"));

        var result = await resultTask.DefaultValue(-1);

        await Assert.That(result).IsEqualTo(-1);
    }

    [Test]
    public async Task DefaultValue_ValueTaskSource_ReturnsValueOnSuccess()
    {
        ValueTask<Result<int, string>> resultTask = new(Result.Ok<int, string>(5));

        var result = await resultTask.DefaultValue(-1);

        await Assert.That(result).IsEqualTo(5);
    }
}
