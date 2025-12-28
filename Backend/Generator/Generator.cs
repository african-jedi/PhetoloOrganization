using System.Text;
using Phetolo.Math28.PuzzleGenerator.Constants;
using Phetolo.Math28.PuzzleGenerator.Helper;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator;

public class Generator
{
    //todo: change all variables to be readOnly so that app is configurable
    private const int TOTAL = 28;
    //generate 5 numbers that equal to 28 when operated
    private const int NUMBERS = 5;
    //maximum number allowed in puzzle
    private const int MAX = 14;
    private readonly NumberGeneratorHelper _helper;

    public Generator(NumberGeneratorHelper helper)
    {
        _helper = helper;
    }

    public async Task<ResultDTO> GeneratePuzzle()
    {
        List<Phetolo.Math28.PuzzleGenerator.Model.NumberPuzzle> puzzle = await RandomNumbersEqualTo28();

        StringBuilder rawPuzzle = new StringBuilder();
        var _random = new Random();

        foreach (var item in puzzle)
            rawPuzzle.Append(item.ToString());

        return new ResultDTO
        {
            RawPuzzle = rawPuzzle.ToString().ReplaceOperatorsWithColon(),
            Scramble = rawPuzzle.ToString().Scramble(),
            Answer = rawPuzzle.ToString()
        };
    }

    private static OperatorType RandomOperator(Random _random)
    {
        int opType = _random.Next(1, Enum.GetValues(typeof(OperatorType)).Length + 1);
        OperatorType numerator = (OperatorType)opType;
        return numerator;
    }

    #region Private Methods
    private async Task<List<NumberPuzzle>> RandomNumbersEqualTo28()
    {
        var puzzle = new List<NumberPuzzle>();

        int[] randomOperators = GenerateRandomOperators();

        int sum = await CalculateMiddleNumbers(puzzle, (OperatorType)randomOperators[0], (OperatorType)randomOperators[1], randomOperators);
        await CalculateLastTwoNumbers(puzzle, sum, randomOperators);

        return puzzle;
    }

    private async Task CalculateLastTwoNumbers(List<NumberPuzzle> puzzle, int sum, int[] randomOperators)
    {
        int[] lastTwoAndSum = await _helper.LastTwoNumbers(randomOperators.Skip(2).ToArray(), total: sum, highestNumber: MAX);
        if(lastTwoAndSum.Length != 3)
          throw new Exception($"LastTwoAndSum array must contain 3 items not {lastTwoAndSum.Length}");

        if (lastTwoAndSum.Take(2).Any(c => c > 14))
            throw new Exception("Selected numbers cannot be greater than 14");

        puzzle.Add(NumberPuzzle.CreateRandomOperator(randomOperators[2]));
        puzzle.Add(NumberPuzzle.CreateUsingTotal(lastTwoAndSum[0]));
        puzzle.Add(NumberPuzzle.CreateRandomOperator(randomOperators[3]));
        puzzle.Add(NumberPuzzle.CreateUsingTotal(lastTwoAndSum[1]));

        if (lastTwoAndSum[2] != TOTAL)
            throw new Exception($"Calculation must be equal to: {TOTAL} and not equal to: {sum}");
    }

    private async Task<int> CalculateMiddleNumbers(List<NumberPuzzle> puzzle, OperatorType op1, OperatorType op2, int[] randomOperators)
    {
        var random = new Random();

        //generate first random number higher than 2
        int sum = random.Next(7, MAX + 1);
        puzzle.Add(NumberPuzzle.CreateUsingTotal(sum));//generate first random number higher than 2

        int numbersCount = 1;
        for (int i = 0; i < randomOperators.Length - 2; i++)
        {
            puzzle.Add(NumberPuzzle.CreateRandomOperator(randomOperators[i]));
            numbersCount++;
            int selectedNumber = numbersCount switch
            {
                2 => await _helper.SecondNumber((OperatorType)randomOperators[i], total: sum, highestNumber: MAX),
                3 => await _helper.ThirdNumber((OperatorType)randomOperators[i], total: sum, highestNumber: MAX, randomOperators.Skip(2).ToArray()),
                _ => throw new Exception("Cannot generate more than 3 numbers"),
            };
            if (selectedNumber > 14)
                throw new Exception("Selected number cannot be greater than 14");
                
            sum = CalculateSum((OperatorType)randomOperators[i], sum: sum, selectedNumber: selectedNumber);
            puzzle.Add(NumberPuzzle.CreateUsingTotal(selectedNumber));
        }

        if (sum <= 1)
            throw new Exception("Middle number total should not be less or equal to 1");

        return sum;
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

    private int CalculateSum(OperatorType op, int sum, int selectedNumber)
    {
        return op switch
        {
            OperatorType.plus => sum + selectedNumber,
            OperatorType.minus => sum - selectedNumber,
            OperatorType.multiply => sum * selectedNumber,
            OperatorType.division => sum / selectedNumber,
            _ => throw new Exception($"Unknown enum: {op.ToString()}")
        };
    }
    #endregion
}