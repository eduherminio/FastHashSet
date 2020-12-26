using HashSetBench;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<RefCountHashSetVsFastHashSet>();
BenchmarkRunner.Run<SumSmallClassVsStructList>();
BenchmarkRunner.Run<AddSmallClassVsStructList>();
BenchmarkRunner.Run<AddSmallClassVsStructFast3>();
BenchmarkRunner.Run<AddSmallClassVsStructFast>();
BenchmarkRunner.Run<AddSmallClassVsStructFast2>();
BenchmarkRunner.Run<MinMaxIntRangeContains1to100>();
BenchmarkRunner.Run<MinMaxIntRangeContains100to1_000>();
BenchmarkRunner.Run<MinMaxIntRangeContains1_000to10_000>();
BenchmarkRunner.Run<MinMaxIntRangeContains10_000to100_000>();
BenchmarkRunner.Run<MinMaxIntRangeContains100_000to1_000_000>();
