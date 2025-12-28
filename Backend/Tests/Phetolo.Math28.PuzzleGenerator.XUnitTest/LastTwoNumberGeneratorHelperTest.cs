using System.Threading.Tasks;
using Phetolo.Math28.PuzzleGenerator.Helper;
namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class LastTwoNumberGeneratorHelperTests
{
    private int _total = 28;
    private int _highestNumber = 14;

      private readonly NumberGeneratorHelper _helper;

    public LastTwoNumberGeneratorHelperTests() => _helper = new NumberGeneratorHelper();

    [Theory]
    [InlineData(15)]
    [InlineData(80)]
    public async Task DividePlusNumbers_ShouldEqual28(int total)
    {
        var result = await _helper.DividePlusNumbers(total);
        Assert.Equal(_total, result[2]);
    }

    [Theory]
    [InlineData(90)]
    public async Task DividePlusNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = await _helper.DividePlusNumbers(total);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("DividePlusNumbers", ex.Message);
        }
    }

    [Theory]
    [InlineData(15)]
    [InlineData(35)]
    public async Task MinusPlusNumbers_ShouldEqual28(int total)
    {
        var result = await _helper.MinusPlusNumbers(total, highestNumber: _highestNumber);
        Assert.Equal(_total, result[2]);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(80)]
    public async Task MinusPlusNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = await _helper.MinusPlusNumbers(total, highestNumber: _highestNumber);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("MinusPlusNumbers", ex.Message);
        }
    }

    [Theory]
    [InlineData(40)]
    [InlineData(35)]
    public async Task MinusDivideNumbers_ShouldEqual28(int total)
    {
        var result = await _helper.MinusDivideNumbers(total, highestNumber: _highestNumber);
        Assert.Equal(_total, result[2]);
    }

    [Theory]
    [InlineData(47)]
    [InlineData(23)]
    public async Task MinusDivideNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = await _helper.MinusDivideNumbers(total, highestNumber: _highestNumber);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("MinusDivideNumbers", ex.Message);
        }
    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(14)]
    [InlineData(28)]
    public async Task MultiplyDivideNumbers_ShouldEqual28(int total)
    {
        var result = await _helper.MultiplyDivideNumbers(total);
        Assert.Equal(_total, result[2]);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(29)]
    public async Task MultiplyDivideNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = await _helper.MultiplyDivideNumbers(total);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("MultiplyDivideNumbers", ex.Message);
        }
    }

    [Fact]
    public async Task LastTwoNumbers_ShouldArgumentException()
    {
        try
        {
            var result = await _helper.LastTwoNumbers([1, 2, 3], 10, highestNumber: _highestNumber);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("Only 2 operators must be left", ex.Message);
        }
    }

}