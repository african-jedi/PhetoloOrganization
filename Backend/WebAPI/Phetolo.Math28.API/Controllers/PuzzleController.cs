namespace Phetolo.Math28.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PuzzleController : ControllerBase
{
    private readonly GetTodayPuzzleUseCase _TodayPuzzleUseCase;
    private readonly GetNextPuzzleUseCase _NextPuzzleUseCase;
    public PuzzleController(GetTodayPuzzleUseCase getTodayPuzzleUseCase, GetNextPuzzleUseCase getNextPuzzleUseCase)
    {
        this._TodayPuzzleUseCase = getTodayPuzzleUseCase;
        this._NextPuzzleUseCase = getNextPuzzleUseCase;
    }

    [HttpGet]
    public async Task<Phetolo.Math28.Core.Models.NumberPuzzle> TodaysPuzzle(CancellationToken cancellationToken)
    {
       return await _TodayPuzzleUseCase.GetPuzzle(cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<Phetolo.Math28.Core.Models.NumberPuzzle> GetPuzzle(int id, CancellationToken cancellationToken)
    {
       return await _NextPuzzleUseCase.GetPuzzle(id, cancellationToken);
    }
}