namespace YieldResultTest;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Execute();
    }

    public static async Task Execute()
    {
        MetricTool tool = new(100, 10);

        // Mensura o tempo de execução usando yield return
        await tool.ExecuteYieldAsync();

        // Mensura o tempo de execução sem yield return
        await tool.ExecuteWithoutAsync();
    }

    // TODO: Implementar
    public static async Task ExecuteCancellation()
    {
        MetricTool tool = new(100, 1);

        // Mensura o tempo de execução usando yield return
        await tool.ExecuteYieldAsync();

        // Mensura o tempo de execução sem yield return
        await tool.ExecuteWithoutAsync();
    }
}