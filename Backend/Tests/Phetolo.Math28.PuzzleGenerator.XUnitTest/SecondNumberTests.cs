using System;
using Phetolo.Math28.PuzzleGenerator.Helper;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class SecondNumberTests
{
    private int _highestNumber = 14;

    [Fact]
    public void SecondNumber_ShouldReturnException()
    {
        try
        {
            NumberGeneratorHelper.SecondNumber((OperatorType)5, 2, highestNumber: _highestNumber, out int sum);
        }
        catch (Exception ex)
        {
            Assert.Contains("Cannot find random number", ex.Message);
        }
    }
}
