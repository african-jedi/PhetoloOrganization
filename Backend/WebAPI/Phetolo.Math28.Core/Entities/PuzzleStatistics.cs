using System;

namespace Phetolo.Math28.Core.Entities;

public class PuzzleStatistics
{
    public long Id { get; set; }
    public required Puzzle Puzzle { get; set; }
    public required User User { get; set; }
    public bool Completed { get; set; }
    public int Attempts { get; set; }
    public TimeOnly CompletedTime { get; set; }
}
