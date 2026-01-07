using System;
using MediatR;

namespace Phetolo.Math28.Application.PuzzleUseCases.Command;

public sealed record CreatePuzzleCommand(
    bool IsTodayPuzzle,
    int? Stage) : IRequest<NumberPuzzle>;
