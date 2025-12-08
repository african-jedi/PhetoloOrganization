using System;
using Phetolo.Math28.Application.DTOs;
using Phetolo.Math28.Application.Interface;
using Phetolo.Math28.PuzzleGenerator;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.Infrastructure.Service;

public class PuzzleGeneratorService(Generator generator) : IPuzzleGeneratorService
{
    public PuzzleGeneratorDTO GetPuzzle()
    {
        ResultDTO result = generator.GeneratePuzzle();
        return new PuzzleGeneratorDTO
        {
            Scramble = result.Scramble,
            Answer = result.Answer
        };
    }
}
