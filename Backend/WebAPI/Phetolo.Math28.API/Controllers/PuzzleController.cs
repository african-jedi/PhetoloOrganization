using MediatR;
using Phetolo.Math28.API.Controllers.Base;
using Phetolo.Math28.Application.PuzzleUseCases.Command;

namespace Phetolo.Math28.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PuzzleController : ApiController
{
    private readonly ILogger<PuzzleController> _logger;
    public PuzzleController(ISender sender, ILogger<PuzzleController> logger) : base(sender)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<Phetolo.Math28.Core.Models.NumberPuzzle> TodaysPuzzle(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching today's puzzle");
        return await Sender.Send(new CreatePuzzleCommand(true, null), cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<Phetolo.Math28.Core.Models.NumberPuzzle> GetPuzzle(int id, CancellationToken cancellationToken)
    {
        return await Sender.Send(new CreatePuzzleCommand(false, id), cancellationToken);
    }
}