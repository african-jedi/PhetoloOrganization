using System;

namespace Phetolo.Math28.Core.Models;

public class NumberPuzzleItem
{
    public Guid Id { get; init; }
    public required string Value { get; init; }
    public required int Position { get; init; }
    public bool DisabledField { get; init; }
    public bool IsNumber { get; set; }
}
