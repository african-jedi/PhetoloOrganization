using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator.Helper;

public partial class NumberGeneratorHelper
{
    private const int TOTAL = 28;
    private static Random _random = new();
    public static int SecondNumber(OperatorType op, int total, int highestNumber, out int sum)
    {
        int num = 0;
        switch (op)
        {
            //generate higher number because only 2 operator increase the number
            //number must not be a prime number
            case OperatorType.plus:
                num = _random.Next(5, highestNumber + 1);
                sum = total + num;
                return num;
            //generate number higher than 28
            case OperatorType.multiply:
                if (total > 10)
                    num = _random.Next(1, 4) * 2;
                else
                    num = _random.Next(2, 6) * 2;

                sum = total * num;
                return num;
            case OperatorType.division:
                //divide for second number must not equal 1
                if (total % 2 == 0)
                    num = total / 2;
                else if (total % 3 == 0)
                    num = total / 3;
                else
                {
                    num = 1;
                    sum = total;
                    return num;
                }
                sum = total / num;
                return num;
            case OperatorType.minus:
                //number must not be a prime number
                num = GenerateNonePrimeNumber(total);
                sum = total - num;
                return num;
            default:
                throw new Exception("Cannot find random number");
        }
    }

    public static int ThirdNumber(OperatorType op, int total, int highestNumber, int[] lastTwoOperators, out int sum)
    {
        Random random = new Random();
        int num = 0;
        switch (op)
        {
            //generate higher number because only 2 operator increase the number
            case OperatorType.plus:
                num = CalcPlusThirdNumber(total: total, highestNumber: highestNumber, lastTwoOperators);

                sum = total + num;
                return num;
            //generate number higher than 28
            case OperatorType.multiply:
                //num = random.Next(28 / total > 10 ? 10 : 28 / total, highestNumber + 1);
                num = CalcMultiplyThirdNumber(total: total, highestNumber: highestNumber, lastTwoOperators);
                sum = total * num;
                return num;
            case OperatorType.division:
                num = 0;

                //mod high numbers first allow num to be lower than highest number
                num = CalcDivisionThirdNumber(total, highestNumber, lastTwoOperators);

                sum = total / num;
                return num;
            case OperatorType.minus:
                num = CalcMinusThirdNumber(total, highestNumber, lastTwoOperators);

                sum = total - num;
                return num;
            default:
                throw new Exception("Cannot find random number");
        }
    }

    public static int[] LastTwoNumbers(int[] operators, int total, int highestNumber, out int sum)
    {
        Random random = new Random();
        if (operators.Length != 2)
            throw new ArgumentException("Only 2 operators must be left");

        OperatorType op1 = (OperatorType)operators[0];
        OperatorType op2 = (OperatorType)operators[1];

        if (op1 == OperatorType.plus && op2 == OperatorType.minus
           || op1 == OperatorType.minus && op2 == OperatorType.plus)
           return MinusPlusNumbers(total: total, highestNumber: highestNumber, out sum);

        else if (op1 == OperatorType.minus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.minus)
           return MinusDivideNumbers(total, highestNumber: highestNumber, out sum);
            
        else if (op1 == OperatorType.multiply && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.multiply)
            return MultiplyDivideNumbers(total, out sum);

        else if (op1 == OperatorType.plus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.plus)
           return DividePlusNumbers(total, out sum);

        else if (op1 == OperatorType.multiply && op2 == OperatorType.minus
        || op1 == OperatorType.minus && op2 == OperatorType.multiply)
            return MinusMultiplyNumbers(total: total, highestNumber: highestNumber, out sum);

        else if (op1 == OperatorType.multiply && op2 == OperatorType.plus
       || op1 == OperatorType.plus && op2 == OperatorType.multiply)
            return MultiplyPlusNumbers(total, out sum);

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