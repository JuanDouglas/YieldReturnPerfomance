using System.Diagnostics;

namespace YieldResultTest;

public class MetricTool(int pageSize, int pages)
{
    readonly ApiService apiService = new(pageSize, pages);
    readonly Stopwatch stopwatch = new();

    public async Task ExecuteYieldAsync(CancellationToken cancellationToken = default)
    {
        stopwatch.Reset();
        stopwatch.Start();
        await foreach (var item in apiService.GetPagedDataWithYieldAsync(cancellationToken))
        {
            _ = item;
            Thread.Sleep(100);
        }
        stopwatch.Stop();
        Console.WriteLine($"Yield return time: {stopwatch.ElapsedMilliseconds} ms");
    }

    public async Task ExecuteWithoutAsync(CancellationToken cancellationToken = default)
    {
        stopwatch.Reset();
        stopwatch.Start();
        var allItems = await apiService.GetPagedDataWithoutYieldAsync(cancellationToken);
        foreach (var item in allItems)
        {
            _ = item;
            Thread.Sleep(100);
        }
        stopwatch.Stop();
        Console.WriteLine($"Without yield return time: {stopwatch.ElapsedMilliseconds} ms");
    }
}