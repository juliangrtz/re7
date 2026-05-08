using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

var config = DefaultConfig.Instance
    .AddJob(Job.Default
        .WithId("short")
        .WithLaunchCount(1)
        .WithWarmupCount(1)
        .WithIterationCount(3))
    .AddColumn(RankColumn.Arabic);

BenchmarkSwitcher
    .FromAssembly(typeof(Program).Assembly)
    .Run(args, config);
