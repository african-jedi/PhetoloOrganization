namespace Phetolo.Math28.PuzzleGenerator.Helper;

public partial class NumberGeneratorHelper
{
    public static int[] DividePlusNumbers(int total, out int sum)
    {
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
                throw new Exception("DividePlusNumbers: Number cannot be added and divided to make 28");
        }
        else
        {
            int firstNumber = TOTAL - total;
            int secondNumber = (total + firstNumber) / TOTAL;
            sum = (total + firstNumber) / secondNumber;
            return [firstNumber, secondNumber];
        }
    }
    public static int[] MinusPlusNumbers(int total, int highestNumber, out int sum)
    {
        if (total < TOTAL && TOTAL - total <= highestNumber)
        {
            int firstNumber = _random.Next(TOTAL - total, highestNumber);
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

        throw new Exception("MinusPlusNumbers method: failed to calculate last two numbers.");
    }
    public static int[] MinusDivideNumbers(int total, out int sum)
    {
        if (total >= TOTAL)
        {
            int num = total % TOTAL;
            int firstNumber = num;
            int secondNumber = (total - num) / TOTAL;
            sum = (total - firstNumber) / secondNumber;
            return [firstNumber, secondNumber];
        }

        throw new Exception("MinusDivideNumber method: cannot fin last two numbers");
    }

    public static int[] MinusMultiplyNumbers(int total, int highestNumber, out int sum)
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

        throw new Exception("MinusMultiplyNumbers: Cannot find minus and multiply numbers");
    }
    public static int[] MultiplyDivideNumbers(int total, out int sum)
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

        throw new Exception("MultiplyDivideNumbers: Cannot find last two numbers for multiply and divide");
    }
    public static int[] MultiplyPlusNumbers(int total, out int sum)
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

        throw new Exception("MultiplyPlusNumbers: Cannot find numbers for multiply and plus");
    }
}