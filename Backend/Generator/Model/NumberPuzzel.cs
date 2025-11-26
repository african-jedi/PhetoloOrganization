using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class NumberPuzzle
{
    private static readonly Random _random = new Random();

    private int? _total;
    public int? Total
    {
        get => _total;
        set
        {
            if (value.HasValue && (value < 0 || value > 10))
                throw new Exception("Total must be between 0 and 10.");
            _total = value;
        }
    }
    public bool IsOperator { get; set; }
     
    private int? _firstNumber;
    public int? FirstNumber
    {
        get => _firstNumber;
        set
        {
            if (value.HasValue && (value < 0 || value > 10))
                throw new Exception("FirstNumber must be between 0 and 10.");
            _firstNumber = value;
        }
    }
    public int? _secondNumber;
    public int? SecondNumber
    {
        get => _secondNumber;
        set
        {
            if (value.HasValue && (value < 0 || value > 10))
                throw new Exception("SecondNumber must be between 0 and 10.");
            _secondNumber = value;
        }
    }
    public OperatorType operatorType { get; set; }

    public static NumberPuzzle CreateUsingTotal(int total)
        => new()
        { Total = total, IsOperator = false };

    public static NumberPuzzle CreateRandomOperator(int opType)
        => new(){ operatorType = (OperatorType)opType, IsOperator = true };

    /// <summary>
    /// Calculate the FirstNumber and SecondNumber
    /// </summary>
    /// <param name="maxNumber">hihest number that can be generated</param>
    /// <exception cref="Exception"></exception>
    public void CalculateSumNumber(int maxNumber,OperatorType numerator)
    {
        if (IsOperator)
            return;
            
        if (!Total.HasValue)
            throw new Exception("Total is null");

        switch (numerator)
        {
            case OperatorType.plus:
                operatorType = OperatorType.plus;
                FirstNumber = _random.Next(0, Total.Value);
                SecondNumber = Total - FirstNumber;
                return;
            case OperatorType.minus:
                operatorType = OperatorType.minus;
                FirstNumber = _random.Next(Total.Value, maxNumber + 1);
                SecondNumber = FirstNumber - Total;
                return;
            case OperatorType.multiply:
                operatorType = OperatorType.multiply;
                if (Total % 2 == 0)
                {
                    FirstNumber = 2;
                    SecondNumber = Total / 2;
                }
                else if (Total % 3 == 0)
                {
                    FirstNumber = 3;
                    SecondNumber = Total / 3;
                }
                return;
            case OperatorType.division:
                operatorType = OperatorType.division;
                if (Total % 2 == 0 && Total * 2 <= maxNumber)
                {
                    FirstNumber = Total * 2;
                    SecondNumber = 2;
                }
                else if (Total % 3 == 0 && Total * 3 <= maxNumber)
                {
                    FirstNumber = Total * 3;
                    SecondNumber = 3;
                }
                else
                {
                    FirstNumber = Total;
                    SecondNumber = 1;
                }
                return;
        }
    }

    public override string ToString()
    {
        if (IsOperator)
            //switch expression for operatorType
            return GetOperatorString();

        if (FirstNumber.HasValue && SecondNumber.HasValue)
            return $"{FirstNumber.Value.ToString()}{GetOperatorString()}{SecondNumber.Value}";

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