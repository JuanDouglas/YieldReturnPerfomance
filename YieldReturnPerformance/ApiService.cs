using System.Runtime.CompilerServices;

namespace YieldResultTest;

public class ApiService(int pageSize, int totalPages)
{
    private readonly Random _random = new();

    // Método para obter dados paginados usando yield return
    public async IAsyncEnumerable<string> GetPagedDataWithYieldAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        for (int page = 1; page <= totalPages; page++)
        {
            await Task.Delay(_random.Next(50, 150), cancellationToken); // Simulação de carregamento de página

            for (int items = 0; items < pageSize; items++)
            {
                yield return $"Yield return: Page {page}";
            }
        }
    }

    // Método para obter todos os dados sem usar yield return
    public async Task<List<string>> GetPagedDataWithoutYieldAsync(CancellationToken cancellationToken = default)
    {
        List<string> allItems = [];

        for (int page = 1; page <= totalPages; page++)
        {
            await Task.Delay(_random.Next(50, 150), cancellationToken); // Simulação de carregamento de página

            for (int items = 0; items < pageSize; items++)
            {
                allItems.Add($"Yield return: Page {page}");
            }
        }

        return allItems;
    }
}

public record DataItem(int Id, string Name);
public record PagedResponse(List<DataItem> Items, int TotalCount, int PageSize);