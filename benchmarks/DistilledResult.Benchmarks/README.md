# DistilledResult.Benchmarks

| Method              |     Mean |     Error |    StdDev |   Median | Ratio | MannWhitney(5%) | RatioSD |   Gen0 | Allocated | Alloc Ratio |
| ------------------- | -------: | --------: | --------: | -------: | ----: | --------------- | ------: | -----: | --------: | ----------: |
| Result_Success      | 1.180 μs | 0.0232 μs | 0.0355 μs | 1.192 μs |  1.00 | Baseline        |    0.04 | 0.0286 |     247 B |        1.00 |
| Result_Error        | 1.167 μs | 0.0228 μs | 0.0342 μs | 1.162 μs |  0.99 | Same            |    0.04 | 0.0248 |     223 B |        0.90 |
| Exception_NotThrown | 1.186 μs | 0.0228 μs | 0.0263 μs | 1.192 μs |  1.01 | Same            |    0.04 | 0.0248 |     215 B |        0.87 |
| Exception_Thrown    | 7.855 μs | 0.2720 μs | 0.7762 μs | 7.630 μs |  6.66 | Slower          |    0.68 | 0.1526 |    1324 B |        5.36 |

## Running

```
dotnet run --project benchmarks/DistilledResult.Benchmarks -c Release
```
