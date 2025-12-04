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
                num = CalcPlusNumber(total: total, highestNumber: highestNumber, lastTwoOperators);

                sum = total + num;
                return num;
            //generate number higher than 28
            case OperatorType.multiply:
                //num = random.Next(28 / total > 10 ? 10 : 28 / total, highestNumber + 1);
                num = CalcMultiplyNumber(total: total, highestNumber: highestNumber, lastTwoOperators);

                sum = total * num;
                return num;
            case OperatorType.division:
                num = 0;

                //mod high numbers first allow num to be lower than highest number
                num = CalcDivisionNumber(total, highestNumber, lastTwoOperators);

                sum = total / num;
                return num;
            case OperatorType.minus:
                if (total <= 4)
                    num = 0;
                else
                {
                    if (total > 4 && total <= 7)
                        num = total % 4;
                    else if (total > 7 && total <= 14)
                        num = total % 7;
                    else if (total > 14 && total < 28)
                        num = total % 14;
                    else if (total == 28)
                    {
                        int randomNumber = random.Next(0, 2);
                        if (randomNumber == 0)
                            num = 14;
                        else
                            num = 7;
                    }
                    else if (total > 28)
                        if (total % TOTAL <= highestNumber)
                            num = total % TOTAL;
                        else
                        {
                            //get closer to factor of 28 by subtracting number which will 
                            //result in mod not being less than 14
                            int max = (total % TOTAL) - highestNumber;
                            num = _random.Next(0, max);
                        }
                    else
                        num = 0;
                }

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
        {
            if (total < TOTAL && TOTAL - total <= highestNumber)
            {
                int firstNumber = random.Next(TOTAL - total, highestNumber);
                int secondNumber = TOTAL - (total + firstNumber);
                if (secondNumber < 0)
                    secondNumber *= -1;

                sum = total + firstNumber - secondNumber;
                return [firstNumber, secondNumber];
            }
            else if (total >= TOTAL && total <= TOTAL + highestNumber)
            {
                int firstNumber = 14;
                int secondNumber = (total - firstNumber) - TOTAL;
                if (secondNumber < 0)
                    secondNumber *= -1;

                sum = total - firstNumber + secondNumber;
                return [firstNumber, secondNumber];
            }
        }
        else if (op1 == OperatorType.minus && op2 == OperatorType.division
        || op1 == OperatorType.division && op2 == OperatorType.minus)
        {
            if (total >= TOTAL)
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
            if (total % 2 == 0 && total % 4 <= 2)
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
                sum = (total - (total % 7)) * 4;
                return [total % 7, 4];
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
        //if * and divide: divide answer must be a multiple of 28
        //if divide and minus: divide by final number must be equal to 28

        //if * and divide: divide answer must be a multiple of 28
        //if divide and minus: divide by final number must be equal to 28
        //throw new Exception($"Cannot find last two numbers for {op1} and {op2}");
        sum = 0;
        return [1, 1];
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

    private static int CalcMultiplyNumber(int total, int highestNumber, int[] lastTwoOperators)
    {
        OperatorType op1 = (OperatorType)lastTwoOperators[0];
        OperatorType op2 = (OperatorType)lastTwoOperators[1];
        //potential block - unit test all options
        while (true)
        {
            int num = _random.Next(28 / total > 10 ? 10 : 28 / total, highestNumber + 1);
            int sum = total * num;

            //true if next number is minus and division
            if (op1 == OperatorType.minus && op2 == OperatorType.division
                || op1 == OperatorType.division && op2 == OperatorType.minus)
            {
                if (sum % TOTAL <= highestNumber)
                    return num;
            }

            //if next number is plus and division
            if (op1 == OperatorType.plus && op2 == OperatorType.division
                || op1 == OperatorType.division && op2 == OperatorType.plus)
            {
                if (sum % TOTAL >= highestNumber)
                    return num;
            }

            //if next number is plus and mins
            if (op1 == OperatorType.plus && op2 == OperatorType.minus
               || op1 == OperatorType.minus && op2 == OperatorType.plus)
            {
                if (total < highestNumber)
                {
                    for (int i = 1; i <= 14; i++)
                        if (total * i < TOTAL + highestNumber && total * i > TOTAL - 2)
                            return i;
                }
                else
                    return 2;
            }
        }

        throw new Exception($"{total} cannot be multiple as value is too high");
    }

    private static int CalcPlusNumber(int total, int highestNumber, int[] lastTwoOperators)
    {
        OperatorType op1 = (OperatorType)lastTwoOperators[0];
        OperatorType op2 = (OperatorType)lastTwoOperators[1];

        if (op1 == OperatorType.minus || op2 == OperatorType.minus)
        {
            int remainder = total % TOTAL;
            if (remainder >= highestNumber)
                return 14;
            else if (remainder > 7)
                return _random.Next(0, highestNumber - remainder);
            else
                return _random.Next(remainder + 1, highestNumber - remainder);
        }

        if (total >= 14 && total < TOTAL)
            return IncrementUntilMax(total, TOTAL);
        if (total >= 7 && total < 14)
            return IncrementUntilMax(total, 14);
        if (total >= 4 && total < 7)
            return IncrementUntilMax(total, 7);
        if (total >= 2 && total < 4)
            return IncrementUntilMax(total, 4);
        if (total > 0 && total < 2)
            return IncrementUntilMax(total, 2);

        return 0;
    }

    private static int CalcDivisionNumber(int total, int highestNumber, int[] lastTwoOperators)
    {
        OperatorType op1 = (OperatorType)lastTwoOperators[0];
        OperatorType op2 = (OperatorType)lastTwoOperators[1];

        if (op1 == OperatorType.plus && op2 == OperatorType.minus
           || op1 == OperatorType.minus && op2 == OperatorType.plus)
        {
            //number must be as close as possible to highest number
            for (int i = 14; i > 0; i--)
                if (total > i && total % i == 0 && total / i > 14)
                    return i;
        }
        //mod high numbers first allow num to be lower than highest number
        for (int i = 14; i > 0; i--)
            if (total > i && total % i == 0)
                return i;

        throw new Exception("Division method cannot calculate third number");
    }
    private static int IncrementUntilMax(int total, int max)
    {
        int increment = 0;
        while (total < max)
        {
            increment++;
            total += 1;
        }
        return increment;
    }
    #endregion
}

