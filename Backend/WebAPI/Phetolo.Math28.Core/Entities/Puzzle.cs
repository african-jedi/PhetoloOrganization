using System;
using System.Runtime.CompilerServices;

namespace Phetolo.Math28.Core.Entities;

public class Puzzle
{
    public long Id { get; set; }
    public Guid RowGuid { get; set; }= Guid.NewGuid();
    public required string Scramble { get; set; }
    public required string Answer { get; set; }
    public required DateTime ExpiryDate { get; set; }
    public required bool TodaysPuzzle { get; set; }
    public int? Stage{get;set;}
}
