using System;

namespace Phetolo.Math28.API.Models;

public class PuzzleDetailsDTO
{
    public bool IsTodaysPuzzle { get; init; }
    public DateTime Generate { get; init; }
    public required PuzzleDTO PuzzleNumbers { get; init; }
}
