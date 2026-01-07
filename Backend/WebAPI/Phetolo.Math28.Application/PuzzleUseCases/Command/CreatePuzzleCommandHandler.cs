using System;
using System.Globalization;
using MediatR;

namespace Phetolo.Math28.Application.PuzzleUseCases.Command;

public class CreatePuzzleCommandHandler: IRequestHandler<CreatePuzzleCommand, NumberPuzzle>
{
    public readonly IPuzzleRepository _puzzleRepository;
    public readonly ILogger<CreatePuzzleCommandHandler> _logger;
    public CreatePuzzleCommandHandler(IPuzzleRepository puzzleRepository, ILogger<CreatePuzzleCommandHandler> logger)
    {
        _puzzleRepository = puzzleRepository;
        _logger = logger;
    }

    public async Task<NumberPuzzle> Handle(CreatePuzzleCommand request, CancellationToken cancellationToken)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
            _logger.LogDebug("Call CreatePuzzleCommandHandler");

        if (!request.IsTodayPuzzle && request.Stage.HasValue)
            return await _puzzleRepository.GetNewPuzzleAsync(request.Stage.Value, cancellationToken);

        return await _puzzleRepository.GetPuzzleAsync(cancellationToken);
    }
}
