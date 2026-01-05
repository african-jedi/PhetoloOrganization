namespace Phetolo.Math28.Application.UseCases;

public class GetTodayPuzzleUseCase(IPuzzleRepository puzzleRepository, ILogger<GetTodayPuzzleUseCase> logger)
{
    public async Task<NumberPuzzle> GetPuzzle(CancellationToken token)
    {
        if (logger.IsEnabled(LogLevel.Debug))
            logger.LogDebug("Get today puzzle");
        //check cached value first
        //else use generator service and save to db
        return await puzzleRepository.GetPuzzleAsync(token);
    }
}
