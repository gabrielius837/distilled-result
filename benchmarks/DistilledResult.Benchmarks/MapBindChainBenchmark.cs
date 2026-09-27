using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

using DistilledResult.FunctionalResultExtensions;

namespace DistilledResult.Benchmarks;

[SimpleJob(RuntimeMoniker.Net10_0)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
[MemoryDiagnoser]
[StatisticalTestColumn("5%")]
public class MapBindChainBenchmark
{
    [Benchmark(Baseline = true)]
    public async Task<Result<int, string>> Task_AlreadyCompleted() =>
        await Task.FromResult(Result.Ok<int, string>(5))
            .Map(x => x * 2)
            .Bind(x => Result.Ok<int, string>(x + 1));

    [Benchmark]
    public async ValueTask<Result<int, string>> ValueTask_AlreadyCompleted() =>
        await new ValueTask<Result<int, string>>(Result.Ok<int, string>(5))
            .Map(x => x * 2)
            .Bind(x => Result.Ok<int, string>(x + 1));

    [Benchmark]
    public async Task<Result<int, string>> Task_GenuinelyPending() =>
        await ProducePendingTaskResult(5)
            .Map(x => x * 2)
            .Bind(x => Result.Ok<int, string>(x + 1));

    [Benchmark]
    public async ValueTask<Result<int, string>> ValueTask_GenuinelyPending() =>
        await ProducePendingValueTaskResult(5)
            .Map(x => x * 2)
            .Bind(x => Result.Ok<int, string>(x + 1));

    private static async Task<Result<int, string>> ProducePendingTaskResult(int value)
    {
        await Task.Yield();
        return value;
    }

    private static async ValueTask<Result<int, string>> ProducePendingValueTaskResult(int value)
    {
        await Task.Yield();
        return value;
    }
}
