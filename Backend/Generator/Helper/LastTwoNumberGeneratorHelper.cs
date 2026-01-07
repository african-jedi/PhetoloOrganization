namespace Phetolo.Math28.PuzzleGenerator.Helper;

public partial class NumberGeneratorHelper
{
    public Task<int[]> DividePlusNumbers(int total)
    {
        if (total > TOTAL)
        {
            int num = total % TOTAL;
            if (num == 0)
            {
                int firstNumber = 0;

                int secondNumber = (total + firstNumber) / TOTAL;
                int sum = (total + firstNumber) / secondNumber;
                return Task.FromResult<int[]>([firstNumber, secondNumber, sum]);
            }
            if (num >= 14)
            {
                int firstNumber = TOTAL - (total % TOTAL);

                int secondNumber = (total + firstNumber) / TOTAL;
                int sum = (total + firstNumber) / secondNumber;
                return Task.FromResult<int[]>([firstNumber, secondNumber, sum]);
            }
            else
                throw new Exception("DividePlusNumbers: Number cannot be added and divided to make 28");
        }
        else
        {
            int firstNumber = TOTAL - total;
            int secondNumber = (total + firstNumber) / TOTAL;
            int sum = (total + firstNumber) / secondNumber;
            return Task.FromResult<int[]>([firstNumber, secondNumber, sum]);
        }
    }
    public Task<int[]> MinusPlusNumbers(int total, int highestNumber)
    {
        if (total < TOTAL && TOTAL - total <= highestNumber)
        {
            int firstNumber = _random.Next(TOTAL - total, highestNumber);
            int secondNumber = TOTAL - (total + firstNumber);
            if (secondNumber < 0)
                secondNumber *= -1;

            int sum = total + firstNumber - secondNumber;
            return Task.FromResult<int[]>([firstNumber, secondNumber, sum]);
        }
        else if (total >= TOTAL && total <= TOTAL + highestNumber)
        {
            int firstNumber = 14;
            int secondNumber = (total - firstNumber) - TOTAL;
            if (secondNumber < 0)
                secondNumber *= -1;

            int sum = total - firstNumber + secondNumber;
            return Task.FromResult<int[]>([firstNumber, secondNumber, sum]);
        }

        throw new Exception("MinusPlusNumbers method: failed to calculate last two numbers.");
    }
    public Task<int[]> MinusDivideNumbers(int total, int highestNumber)
    {
        if (total >= TOTAL && total % TOTAL <= highestNumber)
        {
            int num = total % TOTAL;
            int firstNumber = num;
            int secondNumber = (total - num) / TOTAL;
            int sum = (total - firstNumber) / secondNumber;
            return Task.FromResult<int[]>([firstNumber, secondNumber, sum]);
        }

        throw new Exception("MinusDivideNumbers method: cannot fin last two numbers");
    }

    public Task<int[]> MinusMultiplyNumbers(int total, int highestNumber)
    {
        int sum=0;
        if (total % 2 >= 0 && total % 2 <= 2 && total <= 3)
        {
            sum = (total - (total % 2)) * 14;
            return Task.FromResult<int[]>([total % 2, 14, sum]);
        }
        else if (total % 4 >= 0 && total % 4 < highestNumber && total <= 7)
        {
            sum = (total - (total % 4)) * 7;
            return Task.FromResult<int[]>([total % 4, 7, sum]);
        }
        else if (total % 7 >= 0 && total % 7 < highestNumber && total > 7 && total <= 14)
        {
            int minusNum = 0;
            if (total % 7 == 0 && total / 7 == 2)
                minusNum = total - 7;
            else
                minusNum = total % 7;

            sum = (total - minusNum) * 4;
            return Task.FromResult<int[]>([minusNum, 4, sum]);
        }
        else if (total % 14 >= 0 && total % 14 < highestNumber && total > 14 && total < 28)
        {
            sum = (total - (total % 14)) * 2;
            return Task.FromResult<int[]>([total % 14, 2, sum]);
        }
        else if (total > 28)
        {
            sum = total - TOTAL;
            return Task.FromResult<int[]>([total - TOTAL, 1, sum]);
        }

        throw new Exception("MinusMultiplyNumbers: Cannot find minus and multiply numbers");
    }
    public Task<int[]> MultiplyDivideNumbers(int total)
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

        if (total == 2)
            return Task.FromResult<int[]>([2, 14, total * 14]);
        else if (total == 4)
            return firstNumber != 0 ? Task.FromResult<int[]>([firstNumber, 7, total * 7]) : Task.FromResult<int[]>([7, 1, total * 7]);
        else if (total == 7)
            return firstNumber != 0 ? Task.FromResult<int[]>([firstNumber, 4, total * 4]) : Task.FromResult<int[]>([4, 1,total * 4]);
        else if (total == 14)
            return firstNumber != 0 ? Task.FromResult<int[]>([firstNumber, 2, total * 2]) : Task.FromResult<int[]>([2, 1, total * 2]);

        throw new Exception("MultiplyDivideNumbers: Cannot find last two numbers for multiply and divide");
    }
    public Task<int[]> MultiplyPlusNumbers(int total)
    {
        int sum=0;
        if (total < 4)
        {
            sum = (total + (4 - total)) * 7;
            return Task.FromResult<int[]>([4 - total, 7, sum]);
        }
        else if (total < 7)
        {
            sum = (total + (7 - total)) * 4;
            return Task.FromResult<int[]>([7 - total, 4, sum]);
        }
        else if (total <= 14)
        {
            sum = (total + (14 - total)) * 2;
            return Task.FromResult<int[]>([14 - total, 2, sum]);
        }
        else if (total > 14 && total <= TOTAL)
        {
            sum = total + (TOTAL - total);
            return Task.FromResult<int[]>([TOTAL - total, 1, sum]);
        }

        throw new Exception("MultiplyPlusNumbers: Cannot find numbers for multiply and plus");
    }
}