using Phetolo.Math28.Core.Models;

namespace Phetolo.Math28.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PuzzleController : ControllerBase
{
    private readonly GetTodayPuzzleUseCase getTodayPuzzleUseCase;
    public PuzzleController(GetTodayPuzzleUseCase getTodayPuzzleUseCase)
    {
        this.getTodayPuzzleUseCase = getTodayPuzzleUseCase;
    }

    [HttpGet]
    public Phetolo.Math28.Core.Models.NumberPuzzle TodaysPuzzle()
    {
       return getTodayPuzzleUseCase.GetPuzzle();
    }
}