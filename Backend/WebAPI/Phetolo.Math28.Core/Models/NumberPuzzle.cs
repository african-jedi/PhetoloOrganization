using System;
using System.Linq;

namespace Phetolo.Math28.Core.Models;

public class NumberPuzzle
{
    public Guid Id { get; init; }
    public required string Value { get; init; }
    public required NumberPuzzleItem[] Items { get; init; }
    public bool IsTodaysPuzzle { get; init; }
    public DateTime Generate { get; init; }

    public static NumberPuzzle MapToModel(string puzzleValue, bool isTodaysPuzzle, DateTime generate)
    {
        return new NumberPuzzle
        {
            Items = [.. puzzleValue.Split(':').Select((c,i) => new NumberPuzzleItem
            {
                Id = Guid.NewGuid(),
                Value = c,
                Position = i,
                DisabledField = false,
                IsNumber = IsNumber(c)
            })],
            Value = puzzleValue,
            //this Id will be replaced when saved to DB
            Id = Guid.NewGuid(),
            IsTodaysPuzzle = isTodaysPuzzle,
            Generate = generate
        };
    }

    public static bool IsNumber(string value)
       => int.TryParse(value, out _);

}
