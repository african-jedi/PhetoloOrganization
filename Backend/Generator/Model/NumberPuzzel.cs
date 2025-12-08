using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Phetolo.Math28.PuzzleGenerator.Model;

public class NumberPuzzle
{
    private int? _total;
    public int? Total
    {
        get => _total;
        set
        {
            if (value.HasValue && (value < 0 || value > 14))
                throw new Exception("Total must be between 0 and 14.");
            _total = value;
        }
    }
    public bool IsOperator { get; set; }

    public OperatorType operatorType { get; set; }

    public static NumberPuzzle CreateUsingTotal(int total)
        => new()
        { Total = total, IsOperator = false };

    public static NumberPuzzle CreateRandomOperator(int opType)
        => new() { operatorType = (OperatorType)opType, IsOperator = true };

    public override string ToString()
    {
        if (IsOperator)
            //switch expression for operatorType
            return GetOperatorString();

        return Total.HasValue ? Total.Value.ToString() : "";
    }

     private string GetOperatorString()
    {
        return operatorType switch
        {
            OperatorType.plus => "+",
            OperatorType.minus => "-",
            OperatorType.multiply => "*",
            OperatorType.division => "/",
            _ => throw new InvalidEnumArgumentException($"{nameof(operatorType)} of value {operatorType} is not valid."),   
        };
    }
}