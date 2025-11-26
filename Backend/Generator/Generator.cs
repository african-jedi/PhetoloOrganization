using System.ComponentModel;
using System.Text;
using Phetolo.Math28.PuzzleGenerator.Constants;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator;

public class Generator
{
    //todo: change all variables to be readOnly so that app is configurable
    private const int _total = 28;
    //generate 5 numbers that equal to 28 when operated
    private const int _count = 5;
    private const int _MaxNumber = 10;
    public ResultDTO GeneratePuzzle()
    {
        var puzzle = RandomNumbersEqualTo28();

        StringBuilder rawPuzzle = new StringBuilder();
        StringBuilder numberPuzzle = new StringBuilder();
        var _random = new Random();

        foreach (var item in puzzle)
        {
            rawPuzzle.Append(item.ToString());

            OperatorType numerator = RandomOperator(_random);
            item.CalculateSumNumber(_MaxNumber, numerator);

            numberPuzzle.Append(item.ToString());
        }

        return new ResultDTO
        {
            Puzzle = numberPuzzle.ToString()
                                 .ReplaceOperatorsWithColon(),
            RawPuzzle = rawPuzzle.ToString(),
            Answer = numberPuzzle.ToString()
        };
    }

    private static OperatorType RandomOperator(Random _random)
    {
        int opType = _random.Next(1, Enum.GetValues(typeof(OperatorType)).Length + 1);
        OperatorType numerator = (OperatorType)opType;
        return numerator;
    }

    #region Private Methods
    private List<NumberPuzzle> RandomNumbersEqualTo28()
    {
        var puzzle = new List<NumberPuzzle>();

         var random = new Random();
         //generate first random number
        int sum = random.Next(0, _MaxNumber + 1);

        int[] randomOperators = GenerateRandomOperators();

        for (int i = _count; i > 0; i--)
        {
           
            int number = 0;


            //generate random number
            number = random.Next(0, _MaxNumber + 1);


            puzzle.Add(NumberPuzzle.CreateUsingTotal(number));

            if (i > 1)
            {
                NumberPuzzle operatorPuzzle = NumberPuzzle.CreateRandomOperator(randomOperators[i - 2]);
                puzzle.Add(operatorPuzzle);

                if (operatorPuzzle.operatorType == OperatorType.minus)
                    sum += number;
                else if (operatorPuzzle.operatorType == OperatorType.multiply)
                    sum /= number;
                else if (operatorPuzzle.operatorType == OperatorType.division)
                    sum *= number;
                else
                    sum -= number;
            }

        }
        return puzzle;
    }

    private int[] GenerateRandomOperators()
    {
        var random = new Random();
        List<int> operators = new List<int> { 1, 2, 3, 4 };
        List<int> randomOperators = new List<int>();
        for (int i = 1; i <= 4; i++)
        {
            int number = random.Next(1, operators.Count + 1);
            randomOperators.Add(operators[number - 1]);
            operators.RemoveAt(number - 1);
        }
        return randomOperators.ToArray();
    }
    #endregion
}