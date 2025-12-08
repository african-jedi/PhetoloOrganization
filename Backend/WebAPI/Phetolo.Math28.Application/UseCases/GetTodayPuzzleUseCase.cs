using Phetolo.Math28.Core.Models;

namespace Phetolo.Math28.Application.UseCases;

public class GetTodayPuzzleUseCase(IPuzzleGeneratorService generatorService, ILogger<GetTodayPuzzleUseCase> logger)
{
    public NumberPuzzle GetPuzzle()
    {
        //check cached value first

        //else use generator service and save to db
        var puzzle = generatorService.GetPuzzle();
        logger.LogInformation("Generated new puzzle with answer {Answer}", puzzle.Answer);
        
        //todo: get id and date from db once implemented
        return NumberPuzzle.MapToModel(puzzle.Scramble, true, DateTime.Now);
    }
}
