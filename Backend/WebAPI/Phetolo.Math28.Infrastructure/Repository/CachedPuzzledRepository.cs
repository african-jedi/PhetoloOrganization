using Microsoft.Extensions.Caching.Distributed;

namespace Phetolo.Math28.Infrastructure.Repository;

public class CachedPuzzleRepository : IPuzzleRepository
{
    //decorator pattern
    private readonly IPuzzleRepository _decorated;
    private readonly IDistributedCache _distributedCache;

    public CachedPuzzleRepository(IPuzzleRepository decorated, IDistributedCache distributedCache)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
    }

    public async Task<NumberPuzzle> GetPuzzleAsync(CancellationToken cancellationToken = default)
    {
        string cacheKey = "puzzle:0";
        string? puzzle = await _distributedCache.GetStringAsync(
           cacheKey,
           cancellationToken);

        if (!string.IsNullOrEmpty(puzzle))
        {
            NumberPuzzle cachedPuzzle = JsonSerializer.Deserialize<NumberPuzzle>(puzzle)!;
            if (cachedPuzzle != null)
                return cachedPuzzle;
        }

        return await GeneratePuzzle(cacheKey, cancellationToken);
    }

    public async Task<NumberPuzzle> GetNewPuzzleAsync(int id, CancellationToken cancellationToken = default)
    {
        string cacheKey = $"puzzle:{id}";

        string? puzzle = await _distributedCache.GetStringAsync(
            cacheKey,
            cancellationToken);

        if (!string.IsNullOrEmpty(puzzle))
        {
            NumberPuzzle cachedPuzzle = JsonSerializer.Deserialize<NumberPuzzle>(puzzle)!;
            if (cachedPuzzle != null)
                return cachedPuzzle;
        }

        return await GeneratePuzzle(cacheKey, cancellationToken);
    }

    private async Task<NumberPuzzle> GeneratePuzzle(string cacheKey, CancellationToken cancellationToken)
    {
        var newPuzzle = await _decorated.GetPuzzleAsync(cancellationToken);
        var serializedPuzzle = JsonSerializer.Serialize(newPuzzle);
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24 - DateTime.Now.Hour)
        };
        await _distributedCache.SetStringAsync(
            cacheKey,
            serializedPuzzle,
            options,
            cancellationToken);

        return newPuzzle;
    }
}
