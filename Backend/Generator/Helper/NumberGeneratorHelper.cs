namespace Phetolo.Math28.PuzzleGenerator.Helper;

public class NumberGeneratorHelper
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
                num = ThirdNumberGeneratorHelper.CalcPlusThirdNumber(total: total, highestNumber: highestNumber, lastTwoOperators);

                sum = total + num;
                return num;
            //generate number higher than 28
            case OperatorType.multiply:
                //num = random.Next(28 / total > 10 ? 10 : 28 / total, highestNumber + 1);
                num = ThirdNumberGeneratorHelper.CalcMultiplyThirdNumber(total: total, highestNumber: highestNumber, lastTwoOperators);

                sum = total * num;
                return num;
            case OperatorType.division:
                num = 0;

                //mod high numbers first allow num to be lower than highest number
                num = ThirdNumberGeneratorHelper.CalcDivisionThirdNumber(total, highestNumber, lastTwoOperators);

                sum = total / num;
                return num;
            case OperatorType.minus:
                num = ThirdNumberGeneratorHelper.CalcMinusThirdNumber(total, highestNumber, lastTwoOperators);

                sum = total - num;
                if (sum == 1 && num == 14)
                {
                    num -= 1;
                    sum = total - num;
                }

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
           return LastTwoNumberGeneratorHelper.MinusPlusNumbers(total: total, highestNumber: highestNumber, out sum);

        else if (op1 == OperatorType.minus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.minus)
           return LastTwoNumberGeneratorHelper.MinusDivideNumber(total, out sum);
            

        else if (op1 == OperatorType.multiply && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.multiply)
        {
            int firstNumber = 0;
            if (((double)total / 3) == 4 || ((double)total / 3) == 7 || ((double)total / 3) == 14)
            {
                total = total / 3;
                firstNumber = 3;
            }
            else if (((double)total / 4) == 7 || ((double)total / 4) == 4)
            {
                total = total / 4;
                firstNumber = 4;
            }
            else if (((double)total / 2) == 14 || ((double)total / 2) == 7)
            {
                total = total / 2;
                firstNumber = 2;
            }
            else if (((double)total / 7) == 7 || ((double)total / 7) == 14)
            {
                total = total / 7;
                firstNumber = 7;
            }

            if (total == 4)
            {
                sum = total * 7;
                return firstNumber != 0 ? [firstNumber, 7] : [7, 1];
            }
            else if (total == 7)
            {
                sum = total * 4;
                return firstNumber != 0 ? [firstNumber, 4] : [4, 1];
            }
            else if (total == 14)
            {
                sum = total * 2;
                return firstNumber != 0 ? [firstNumber, 2] : [2, 1];
            }
            else if (total == 28)
            {
                sum = total * 1;
                return firstNumber != 0 ? [firstNumber, 1] : [1, 1];
            }

            throw new Exception("Cannot find last two numbers for multiply and divide");
        }
        else if (op1 == OperatorType.plus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.plus)
        {
            //this calculation is incorrect
            if (total > TOTAL)
            {
                int num = total % TOTAL;
                if (num == 0)
                {
                    int firstNumber = 0;

                    int secondNumber = (total + firstNumber) / TOTAL;
                    sum = (total + firstNumber) / secondNumber;
                    return [firstNumber, secondNumber];
                }
                if (num >= 14)
                {
                    int firstNumber = TOTAL - (total % TOTAL);

                    int secondNumber = (total + firstNumber) / TOTAL;
                    sum = (total + firstNumber) / secondNumber;
                    return [firstNumber, secondNumber];
                }
                else
                    throw new Exception("Number cannot be added and divided to make 28");
            }
            else
            {
                int firstNumber = TOTAL - total;
                int secondNumber = (total + firstNumber) / TOTAL;
                sum = (total + firstNumber) / secondNumber;
                return [firstNumber, secondNumber];
            }
        }
        else if (op1 == OperatorType.multiply && op2 == OperatorType.minus
        || op1 == OperatorType.minus && op2 == OperatorType.multiply)
        {
            if (total % 2 >= 0 && total % 2 <= 2 && total <= 3)
            {
                sum = (total - (total % 2)) * 14;
                return [total % 2, 14];
            }
            else if (total % 4 >= 0 && total % 4 < highestNumber && total <= 7)
            {
                sum = (total - (total % 4)) * 7;
                return [total % 4, 7];
            }
            else if (total % 7 >= 0 && total % 7 < highestNumber && total > 7 && total <= 14)
            {
                int minusNum = 0;
                if (total % 7 == 0 && total / 7 == 2)
                    minusNum = total - 7;
                else
                    minusNum = total % 7;

                sum = (total - minusNum) * 4;
                return [minusNum, 4];
            }
            else if (total % 14 >= 0 && total % 14 < highestNumber && total > 14 && total < 28)
            {
                sum = (total - (total % 14)) * 2;
                return [total % 14, 2];
            }
            else if (total > 28)
            {
                sum = total - TOTAL;
                return [total - TOTAL, 1];
            }
        }
        else if (op1 == OperatorType.multiply && op2 == OperatorType.plus
       || op1 == OperatorType.plus && op2 == OperatorType.multiply)
        {
            if (total < 4)
            {
                sum = (total + (4 - total)) * 7;
                return [4 - total, 7];
            }
            else if (total < 7)
            {
                sum = (total + (7 - total)) * 4;
                return [7 - total, 4];
            }
            else if (total <= 14)
            {
                sum = (total + (14 - total)) * 2;
                return [14 - total, 2];
            }
            else if (total > 14 && total <= TOTAL)
            {
                sum = total + (TOTAL - total);
                return [TOTAL - total, 1];
            }
        }

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

