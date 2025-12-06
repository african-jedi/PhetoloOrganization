namespace Phetolo.Math28.PuzzleGenerator.Helper;
public partial class NumberGeneratorHelper
{
    public static int CalcMultiplyThirdNumber(int total, int highestNumber, int[] lastTwoOperators)
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

    public static int CalcPlusThirdNumber(int total, int highestNumber, int[] lastTwoOperators)
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
                return highestNumber - remainder;
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

    public static int CalcDivisionThirdNumber(int total, int highestNumber, int[] lastTwoOperators)
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

    public static int CalcMinusThirdNumber(int total, int highestNumber, int[] lastTwoOperators)
    {
        if (total <= 4)
            return 0;
        else if (total > 4 && total <= 7)
            return total % 4;
        else if (total > 7 && total <= 14)
            return total % 7;
        else if (total > 14 && total < 28)
            return total % 14;
        else if (total == 28)
        {
            int randomNumber = _random.Next(0, 2);
            if (randomNumber == 0)
                return 14;
            else
                return 7;
        }
        else if (total > 28)
            if (total % TOTAL <= highestNumber)
                return total % TOTAL;
            else
            {
                //get closer to factor of 28 by subtracting number which will 
                //result in mod not being less than 14
                int max = (total % TOTAL) - highestNumber;
                return _random.Next(0, max);
            }
        else
            return 0;

    }

    #region Private methods

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