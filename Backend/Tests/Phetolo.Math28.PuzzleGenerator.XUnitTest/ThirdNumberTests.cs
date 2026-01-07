using System.Threading.Tasks;
using Phetolo.Math28.PuzzleGenerator.Helper;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class ThirdNumberTests
{
    private int _highestNumber = 14;
    private readonly NumberGeneratorHelper _helper;

    public ThirdNumberTests() => _helper = new NumberGeneratorHelper();

    [Fact]
    public async Task ThirdNumberNumber_ShouldReturnException()
    {
        try
        {
           await _helper.ThirdNumber((OperatorType)5, 2, highestNumber: _highestNumber, [1, 2]);
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
    public async Task CalcPlusThirdNumber_ShouldReturnValue(int total)
    {
        int num = await _helper.ThirdNumber(OperatorType.plus, total, highestNumber: _highestNumber, [3, 4]);
        Assert.True(num + total >= 2);
    }

    [Fact]
    public void CalcDivisionThirdNumber_ShouldReturnException()
    {
        try
        {
            int sum = _helper.CalcDivisionThirdNumber(0, highestNumber: _highestNumber, [3, 4]);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("Division method cannot calculate third number", ex.Message);
        }
    }
}
