namespace Phetolo.Math28.Application.UseCases;

public class GetNextPuzzleUseCase(IPuzzleRepository puzzleRepository, ILogger<GetNextPuzzleUseCase> logger)
{
    public async Task<NumberPuzzle> GetPuzzle(int id, CancellationToken token)
    {
        if (logger.IsEnabled(LogLevel.Debug))
            logger.LogDebug("Generate today puzzle");
        //check cached value first
        //else use generator service and save to db
        return await puzzleRepository.GetNewPuzzleAsync(id, token);
    }
}
