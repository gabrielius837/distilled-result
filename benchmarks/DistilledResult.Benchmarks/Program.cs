using BenchmarkDotNet.Running;
using DistilledResult.Benchmarks;

BenchmarkSwitcher.FromTypes([typeof(ResultVsExceptionBenchmark), typeof(MapBindChainBenchmark)]).Run(args);
