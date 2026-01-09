using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Phetolo.Math28.Infrastructure.Repository;

public class CachedPuzzleRepository : IPuzzleRepository
{
    //decorator pattern
    private readonly IPuzzleRepository _decorated;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CachedPuzzleRepository> _logger;

    public CachedPuzzleRepository(IPuzzleRepository decorated, IDistributedCache distributedCache, ILogger<CachedPuzzleRepository> logger)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
        _logger = logger;
    }

    public async Task<NumberPuzzle> GetPuzzleAsync(CancellationToken cancellationToken = default)
    {
        string cacheKey = "puzzle:0";
        string? puzzle = string.Empty;
        try
        {
            puzzle = await _distributedCache.GetStringAsync(
               cacheKey,
               cancellationToken);

            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug("Using cached puzzle with key {CacheKey}", cacheKey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving puzzle from cache with key {CacheKey}", cacheKey);
        }

        if (!string.IsNullOrEmpty(puzzle))
        {
            NumberPuzzle cachedPuzzle = JsonSerializer.Deserialize<NumberPuzzle>(puzzle)!;
            if (cachedPuzzle != null)
                return cachedPuzzle;
        }

        return await GeneratePuzzle(cacheKey, null, cancellationToken);
    }

    public async Task<NumberPuzzle> GetNewPuzzleAsync(int id, CancellationToken cancellationToken = default)
    {
        string cacheKey = $"puzzle:{id}";

        string? puzzle = string.Empty;
        try
        {
            puzzle = await _distributedCache.GetStringAsync(
               cacheKey,
               cancellationToken);

            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug("Using cached puzzle with key {CacheKey}", cacheKey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving puzzle from cache with key {CacheKey}", cacheKey);
        }

        if (!string.IsNullOrEmpty(puzzle))
        {
            NumberPuzzle cachedPuzzle = JsonSerializer.Deserialize<NumberPuzzle>(puzzle)!;
            if (cachedPuzzle != null)
                return cachedPuzzle;
        }

        return await GeneratePuzzle(cacheKey, id, cancellationToken);
    }

    private async Task<NumberPuzzle> GeneratePuzzle(string cacheKey, int? stage, CancellationToken cancellationToken)
    {
        NumberPuzzle newPuzzle = null!;
        if (stage.HasValue)
            newPuzzle = await _decorated.GetNewPuzzleAsync(stage.Value, cancellationToken);
        else
            newPuzzle = await _decorated.GetPuzzleAsync(cancellationToken);

        var serializedPuzzle = JsonSerializer.Serialize(newPuzzle);
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24 - DateTime.Now.Hour)
        };

        try
        {
            await _distributedCache.SetStringAsync(
                cacheKey,
                serializedPuzzle,
                options,
                cancellationToken);

            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug("Set cached puzzle with key {CacheKey}", cacheKey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error caching puzzle with key {CacheKey}", cacheKey);
        }

        return newPuzzle;
    }
}
