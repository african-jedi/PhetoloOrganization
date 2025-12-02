using System;

namespace Phetolo.Math28.PuzzleGenerator.Model;

public class ResultDTO
{
    public required string Scramble { get; set; }
    public required string RawPuzzle { get; set; }
    public required string Answer { get; set; }
}