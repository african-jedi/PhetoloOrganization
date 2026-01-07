using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator.Helper;

public partial class NumberGeneratorHelper
{
    private const int TOTAL = 28;
    private static Random _random = new();
    public Task<int> SecondNumber(OperatorType op, int total, int highestNumber)
    {
        int num = 0;
        switch (op)
        {
            //generate higher number because only 2 operator increase the number
            //number must not be a prime number
            case OperatorType.plus:
                return Task.FromResult(_random.Next(5, highestNumber + 1));
            //generate number higher than 28
            case OperatorType.multiply:
                if (total > 10)
                    return Task.FromResult(_random.Next(1, 4) * 2);
                else
                    return Task.FromResult(_random.Next(2, 6) * 2);
            case OperatorType.division:
                //divide for second number must not equal 1
                if (total % 2 == 0)
                    return Task.FromResult(total / 2);
                else if (total % 3 == 0)
                    return Task.FromResult(total / 3);
                else
                {
                    num = 1;
                    return Task.FromResult(num);
                }
            case OperatorType.minus:
                //number must not be a prime number
                return Task.FromResult(GenerateNonePrimeNumber(total));
            default:
                throw new Exception("Cannot find random number");
        }
    }

    public Task<int> ThirdNumber(OperatorType op, int total, int highestNumber, int[] lastTwoOperators)
    {
        return op switch
        {
            //generate higher number because only 2 operator increase the number
            OperatorType.plus => Task.FromResult(CalcPlusThirdNumber(total: total, highestNumber: highestNumber, lastTwoOperators)),
            //generate number higher than 28
            OperatorType.multiply => Task.FromResult(CalcMultiplyThirdNumber(total: total, highestNumber: highestNumber, lastTwoOperators)),//num = random.Next(28 / total > 10 ? 10 : 28 / total, highestNumber + 1);
            OperatorType.division => Task.FromResult(CalcDivisionThirdNumber(total, highestNumber, lastTwoOperators)),//mod high numbers first allow num to be lower than highest number
            OperatorType.minus => Task.FromResult(CalcMinusThirdNumber(total, highestNumber, lastTwoOperators)),
            _ => throw new Exception("Cannot find random number"),
        };
    }

    public async Task<int[]> LastTwoNumbers(int[] operators, int total, int highestNumber)
    {
        Random random = new Random();
        if (operators.Length != 2)
            throw new ArgumentException("Only 2 operators must be left");

        OperatorType op1 = (OperatorType)operators[0];
        OperatorType op2 = (OperatorType)operators[1];

        if (op1 == OperatorType.plus && op2 == OperatorType.minus
           || op1 == OperatorType.minus && op2 == OperatorType.plus)
           return await MinusPlusNumbers(total: total, highestNumber: highestNumber);

        else if (op1 == OperatorType.minus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.minus)
           return await MinusDivideNumbers(total, highestNumber: highestNumber);
            
        else if (op1 == OperatorType.multiply && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.multiply)
            return await MultiplyDivideNumbers(total);

        else if (op1 == OperatorType.plus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.plus)
           return await DividePlusNumbers(total);

        else if (op1 == OperatorType.multiply && op2 == OperatorType.minus
        || op1 == OperatorType.minus && op2 == OperatorType.multiply)
            return await MinusMultiplyNumbers(total: total, highestNumber: highestNumber);

        else if (op1 == OperatorType.multiply && op2 == OperatorType.plus
       || op1 == OperatorType.plus && op2 == OperatorType.multiply)
            return await MultiplyPlusNumbers(total);

        throw new Exception($"Cannot find last two numbers for {op1} and {op2}");
    }

    #region Private Methods

    private static int GenerateNonePrimeNumber(int total)
    {
        while (true)
        {
            int num = _random.Next(0, total);
            int sum = total - num;
            if (!IsPrimeBiggerThanTwo(sum))
                return num;
        }
    }

    private static bool IsPrimeBiggerThanTwo(int number)
    {
        if (number <= 1 || number == 2)
            return true;

        if (number > 2 && number % 2 == 0)
            return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
    
    #endregion
}