using Phetolo.Math28.PuzzleGenerator.Helper;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class ThirdNumberTests
{
    private int _highestNumber = 14;

    [Fact]
    public void ThirdNumberNumber_ShouldReturnException()
    {
        try
        {
            NumberGeneratorHelper.ThirdNumber((OperatorType)5, 2, highestNumber: _highestNumber, [1, 2], out int sum);
        }
        catch (Exception ex)
        {
            Assert.Contains("Cannot find random number", ex.Message);
        }
    }

    [Theory]
    [InlineData(5)]
    [InlineData(3)]
    [InlineData(1)]
    [InlineData(0)]
    public void CalcPlusThirdNumber_ShouldReturnValue(int total)
    {
        int num = NumberGeneratorHelper.ThirdNumber(OperatorType.plus, total, highestNumber: _highestNumber, [3, 4], out int sum);
        Assert.True(num + total >= 2);
    }

    [Fact]
    public void CalcDivisionThirdNumber_ShouldReturnException()
    {
        try
        {
            int sum = NumberGeneratorHelper.CalcDivisionThirdNumber(0, highestNumber: _highestNumber, [3, 4]);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("Division method cannot calculate third number", ex.Message);
        }
    }
}
