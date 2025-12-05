namespace Phetolo.Math28.PuzzleGenerator.Helper;

public class LastTwoNumberGeneratorHelper
{
    private const int TOTAL = 28;
    private static Random _random = new();
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
    public static int[] MinusDivideNumber(int total, out int sum)
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
}