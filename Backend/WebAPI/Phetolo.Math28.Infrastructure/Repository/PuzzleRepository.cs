using System;
using Phetolo.Math28.Application.Interface;
using Phetolo.Math28.Core.Interfaces;
using Phetolo.Math28.Core.Models;

namespace Phetolo.Math28.Infrastructure.Repository;

public class PuzzleRepository : IPuzzleRepository
{
    private readonly IPuzzleGeneratorService _puzzleGeneratorService;

    public PuzzleRepository(IPuzzleGeneratorService puzzleGeneratorService)
    {
        _puzzleGeneratorService = puzzleGeneratorService;
    }

    public async Task<NumberPuzzle> GetPuzzleAsync(CancellationToken cancellationToken = default)
    {
        var puzzle = await _puzzleGeneratorService.GetPuzzleAsync();
        return await Task.FromResult(NumberPuzzle.MapToModel(puzzle.Scramble, true, DateTime.Now));
    }

    public async Task<NumberPuzzle> GetNewPuzzleAsync(int id, CancellationToken cancellationToken = default)
    {
        var puzzle = await _puzzleGeneratorService.GetPuzzleAsync();
        return await Task.FromResult(NumberPuzzle.MapToModel(puzzle.Scramble, true, DateTime.Now));
    }
}
