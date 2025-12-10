using System;
using Phetolo.Math28.Application.DTOs;
using Phetolo.Math28.Application.Interface;
using Phetolo.Math28.PuzzleGenerator;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.Infrastructure.Service;

public class PuzzleGeneratorService(Generator generator) : IPuzzleGeneratorService
{
    public async Task<PuzzleGeneratorDTO> GetPuzzleAsync()
    {
        ResultDTO result = await Task.FromResult(generator.GeneratePuzzle());
        return new PuzzleGeneratorDTO
        {
            Scramble = result.Scramble,
            Answer = result.Answer
        };
    }
}
