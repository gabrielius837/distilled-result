using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DistilledResult.Benchmarks;

[SimpleJob(RuntimeMoniker.Net10_0)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
[MemoryDiagnoser]
[StatisticalTestColumn("5%")]
public class ResultVsExceptionBenchmark
{
    [Benchmark(Baseline = true)]
    public async Task<Result<Record, string>> Result_Success() => await FetchResult(1);

    [Benchmark]
    public async Task<Result<Record, string>> Result_Error() => await FetchResult(-1);

    [Benchmark]
    public async Task<Record> Exception_NotThrown() => await FetchThrowing(1);

    [Benchmark]
    public async Task<Record?> Exception_Thrown()
    {
        try
        {
            return await FetchThrowing(id: -1);
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }

    private static async Task<Result<Record, string>> FetchResult(int id)
    {
        await Task.Yield();
        return id > 0 ? new Record(id) : "record not found";
    }

    private static async Task<Record> FetchThrowing(int id)
    {
        await Task.Yield();
        return id > 0 ? new Record(id) : throw new KeyNotFoundException("record not found");
    }
}

public record Record(int Id);
