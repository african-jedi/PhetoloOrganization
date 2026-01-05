using System;
using System.Runtime.CompilerServices;

namespace Phetolo.Math28.Core.Entities;

public class Puzzle
{
    public required long Id { get; set; }
    public required Guid RowGuid { get; set; }
    public required string Scramble { get; set; }
    public required string Answer { get; set; }
    public required DateTime ExpiryDate { get; set; }
    public required bool TodaysPuzzle { get; set; }
    public int? Stage{get;set;}
}
