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
                num = _random.Next(total, highestNumber + 1);
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
                    sum = num / total;
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

    public static int ThirdNumber(OperatorType op, int total, int highestNumber, out int sum)
    {
        Random random = new Random();
        int num = 0;
        switch (op)
        {
            //generate higher number because only 2 operator increase the number
            case OperatorType.plus:
                num = random.Next(5, highestNumber + 1);
                sum = total + num;
                return num;
            //generate number higher than 28
            case OperatorType.multiply:
                num = random.Next(28 / total > 10 ? 10 : 28 / total, highestNumber + 1);
                sum = total * num;
                return num;
            case OperatorType.division:
                num = 0;

                //mod high numbers first allow num to be lower than highest number
                if (total > 9 && total % 9 == 0)
                    num = total / 9;
                else if (total > 8 && total % 8 == 0)
                    num = total / 8;
                else if (total > 7 && total % 7 == 0)
                    num = total / 7;
                else if (total > 6 && total % 6 == 0)
                    num = total / 6;
                else if (total > 5 && total % 5 == 0)
                    num = total / 5;
                else if (total > 4 && total % 4 == 0)
                    num = total / 4;
                else if (total > 2 && total % 2 == 0)
                    num = total / 2;
                else if (total > 3 && total % 3 == 0)
                    num = total / 3;
                else
                    num = 1;

                sum = total / num;
                return num;
            case OperatorType.minus:
                if (total <= 4)
                    num = 0;
                else
                {
                    if (total > 4 && total <= 7)
                        num = total - (total % 4) + 1;
                    else if (total > 7 && total <= 14)
                        num = total - (total % 7) + 1;
                    else if (total > 14)
                        num = total - (total % 14) + 1;
                    else
                        num = sum = 0;
                }
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
        {
            if (total < TOTAL && TOTAL - total <= highestNumber)
            {
                int firstNumber = random.Next(TOTAL - total, highestNumber + 1);
                int secondNumber = TOTAL - (total + firstNumber);
                sum = total + firstNumber - secondNumber;
                return [firstNumber, secondNumber];
            }
            else if (total >= TOTAL && total <= TOTAL + highestNumber)
            {
                int firstNumber = random.Next(1, highestNumber + 1);
                int secondNumber = (total + firstNumber) - TOTAL;
                sum = total + firstNumber - secondNumber;
                return [firstNumber, secondNumber];
            }
        }
        else if (op1 == OperatorType.minus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.minus)
        {
            if (total > TOTAL)
            {
                int num = total % TOTAL;
                int firstNumber = num;
                int secondNumber = (total - num) / TOTAL;
                sum = (total - firstNumber) / secondNumber;
                return [firstNumber, secondNumber];
            }
        }
        else if (op1 == OperatorType.multiply && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.multiply)
        {
            int firstNumber = 0;
            if (((double)total / 3) == 4 || ((double)total / 3) == 7 || ((double)total / 3) == 14)
            {
                total = total / 3;
                firstNumber = 3;
            }
            else if (((double)total / 4) == 7 || ((double)total / 4) == 4 || ((double)total / 4) == 14)
            {
                total = total / 3;
                firstNumber = 3;
            }
            else if (((double)total / 2) == 14 || ((double)total / 2) == 7 || ((double)total / 2) == 4)
            {
                total = total / 2;
                firstNumber = 2;
            }
            else if (((double)total / 7) == 7 || ((double)total / 7) == 14 || ((double)total / 7) == 4)
            {
                total = total / 7;
                firstNumber = 7;
            }

            if (total == 4)
            {
                sum = firstNumber != 0 ? (total + firstNumber) * 7 : (total * 7);
                return firstNumber != 0 ? [firstNumber, 7] : [7, 1];
            }
            else if (total == 7)
            {
                sum = firstNumber != 0 ? (total + firstNumber) * 4 : (total * 4);
                return firstNumber != 0 ? [firstNumber, 4] : [4, 1];
            }
            else if (total == 14)
            {
                sum = firstNumber != 0 ? (total + firstNumber) * 2 : (total * 2);
                return firstNumber != 0 ? [firstNumber, 2] : [2, 1];
            }
            else if (total == 28)
            {
                sum = firstNumber != 0 ? (total + firstNumber) * 1 : (total * 1);
                return firstNumber != 0 ? [firstNumber, 1] : [1, 1];
            }
            else
            {
                throw new Exception("Cannot find last two numbers for multiply and divide");
            }
        }
        else if (op1 == OperatorType.plus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.plus)
        {
            //this calculation is incorrect
            if (total > TOTAL)
            {
                int firstNumber = total % TOTAL;
                int secondNumber = (total + firstNumber) / TOTAL;
                sum = (total + firstNumber) / secondNumber;
                return [firstNumber, secondNumber];
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
            if (total % 4 != 0 && total % 4 < highestNumber && total <= 7)
            {
                sum = (total - (total % 4)) * 7;
                return [total % 4, 7];
            }
            else if (total % 7 != 0 && total % 7 < highestNumber && total > 7 && total <= 14)
            {
                sum = (total - (total % 7)) * 4;
                return [total % 7, 4];
            }
            else if (total % 14 != 0 && total % 14 < highestNumber && total > 14 && total < 28)
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
        //if * and divide: divide answer must be a multiple of 28
        //if divide and minus: divide by final number must be equal to 28

        //if * and divide: divide answer must be a multiple of 28
        //if divide and minus: divide by final number must be equal to 28
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

